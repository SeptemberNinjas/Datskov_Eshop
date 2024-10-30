using Eshop.Core;
using System.Data;
using System.Data.Common;

namespace Eshop.DataAccess.PGDataStorage
{
    internal class ProductPGDataStorage : DBContext, IRepository<Product>
    {
        public ProductPGDataStorage(string connectionString) : base(connectionString) { }

        public IReadOnlyCollection<Product> GetAll()
        {
            using var command = GetCommand(
                @"select 
                    c.*, 
                    COALESCE(s.amount, 0) as  amount
                from 
                    catalog c
                        left join stock s 
                        on c.Id = s.Id
                where 
                    type = 1
                order by 
                    Id");

            using var reader = command.ExecuteReader();

            var result = new List<Product>();

            while (reader.Read())
            {
                result.Add(GetProduct(reader));
            }

            return result;
        }

        public async Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken ct = default)
        {
            var query =
                @"select 
                    c.*, 
                    COALESCE(s.amount, 0) as  amount
                from 
                    catalog c
                        left join stock s 
                        on c.Id = s.Id
                where 
                    type = 1";

            return await ExecuteReaderListAsync<Product>(query, ct, GetProduct);
        }

        private static Product GetProduct(DbDataReader reader)
        {
            return new Product(
                    reader.GetFieldValue<int>("id"),
                    reader.GetFieldValue<string>("name"),
                    reader.GetFieldValue<decimal>("price"),
                    (uint)reader.GetFieldValue<int>("amount"),
                    reader.GetFieldValue<string>("description"));
        }

        public async Task<Product>? GetByIdAsync(int Id, CancellationToken ct = default)
        {
            var query =
                $@"select 
                    c.*, 
                    COALESCE(s.amount, 0) as  amount
                from 
                    catalog c
                        left join stock s 
                        on c.Id = s.Id
                where 
                    type = 1
                    and Id = {Id}";

            var list = await ExecuteReaderListAsync<Product>(query, ct, GetProduct);
            return list.FirstOrDefault(x => x.Id == Id)!;
        }

        public async Task<int> GetCountAsync(CancellationToken ct = default)
        {
            using var command = GetCommand(
                $@"select count(*) as count
                from 
                    catalog c
                where 
                    type = 1");

            var result = await command.ExecuteScalarAsync(ct);

            return int.TryParse(result?.ToString(), out int count) ? count : 0;
        }

        public void Save(Product obj)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
