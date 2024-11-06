using Eshop.Core;
using System.Data;
using System.Text;

namespace Eshop.DataAccess.PGDataStorage
{
    public class CartPGDataStorage(string connectionString, 
        IRepository<Product> ProductManager, 
        IRepository<Service> ServiceManager) : DBContext(connectionString), IRepository<Cart>
    {
        public IReadOnlyCollection<Cart> GetAll() => GetAllAsync().Result;

        public async Task<IReadOnlyCollection<Cart>> GetAllAsync(CancellationToken ct = default)
        {
            var query =
                @"SELECT 
                    cl.saleitemid,
                    c.type as saleitemtype,
                    cl.count
                FROM 
                    cart_lines cl
                    JOIN catalog c
                    ON cl.saleitemid = c.id";

            using var connection = await GetConnectionAsync(ct);

            var command = GetCommand(query);

            using var reader = await command.ExecuteReaderAsync(ct);

            var cart = new Cart();
            
            while (await reader.ReadAsync(ct))
            {
                var saleitemid = await reader.GetFieldValueAsync<int>("saleitemid", ct);
                var count = Convert.ToUInt32(await reader.GetFieldValueAsync<int>("count", ct));
                var saleItemType = await reader.GetFieldValueAsync<int>("saleitemtype", ct);

                if (saleItemType == 1 && await ProductManager.GetByIdAsync(saleitemid, ct)! is Product product)
                    cart.Items.Add(new(product, count));

                else if (saleItemType == 2 && await ServiceManager.GetByIdAsync(saleitemid, ct)! is Service service)
                    cart.Items.Add(new(service));
            }

            var result = new List<Cart>
            {
                cart
            };

            return result;
        }

        public Cart? GetById(int id) => GetAllAsync().Result.FirstOrDefault();

        public Task<Cart?> GetByIdAsync(int Id, CancellationToken ct = default) => Task.FromResult(GetAllAsync(ct).Result.FirstOrDefault());

        public Task<int> GetCountAsync(CancellationToken ct = default) => Task.FromResult(GetAllAsync(ct).Result.Count);

        public void Save(Cart obj) => SaveAsync(obj).Wait();

        public async Task SaveAsync(Cart obj, CancellationToken ct = default)
        {

            var insertLinesStatement = string.Empty;

            if (obj.Items.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine("INSERT INTO cart_lines(saleitemid, count)");
                sb.AppendLine("VALUES");

                var values = new List<string>();
                foreach (var line in obj.Items)
                    values.Add($"({line.Product?.Id ?? line.Service?.Id ?? 0}, {line.Count})");

                sb.AppendJoin(", ", values);
                sb.Append(';');

                insertLinesStatement = sb.ToString();
            }

            var query =
                $@"DO $$DECLARE r record;
                BEGIN
                    DELETE FROM cart_lines
                    ;

                    {insertLinesStatement}
                END$$;";

            await ExecuteNonQueryAsync(query, ct);
        }
    }
}
