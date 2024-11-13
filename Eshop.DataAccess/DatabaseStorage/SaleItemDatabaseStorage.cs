using Eshop.Core;
using System.Data;
using System.Data.Common;

namespace Eshop.DataAccess.DatabaseStorage
{
    internal class SaleItemDatabaseStorage :DBContext, IRepository<SaleItem>
    {
        public SaleItemDatabaseStorage(string connectionString) : base(connectionString) { }

        public IReadOnlyCollection<SaleItem> GetAll()
        {
            using var command = GetCommand(
                @"select 
                    c.*, 
                    COALESCE(s.amount, 0) as amount
                from 
                    catalog c
                        left join stock s 
                        on c.id = s.id
                order by 
                    id");

            using var reader = command.ExecuteReader();

            var result = new List<SaleItem>();

            while (reader.Read())
            {
                result.Add(GetSaleItem(reader));
            }

            return result;
        }

        public async Task<IReadOnlyCollection<SaleItem>> GetAllAsync(CancellationToken ct = default)
        {
            var query =
                @"select 
                    c.*, 
                    COALESCE(s.amount, 0) as  amount
                from 
                    catalog c
                        left join stock s 
                        on c.Id = s.Id
                order by 
                    id";

            return await ExecuteReaderListAsync<SaleItem>(query, ct, GetSaleItem);
        }

        private static SaleItem GetSaleItem(DbDataReader reader)
        {
            var type = (SaleItemType)reader.GetFieldValue<int>("type");
            var id = reader.GetFieldValue<int>("id");
            var name = reader.GetFieldValue<string>("name");
            var price = reader.GetFieldValue<decimal>("price");

            return type switch
            {
                SaleItemType.Product => new Product(id, name, price,
                    (uint)reader.GetFieldValue<int>("amount")),
                SaleItemType.Service => new Service(id, name, price),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public SaleItem? GetById(int id) => GetByIdAsync(id).Result;

        public async Task<SaleItem?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var saleItems = await GetAllAsync(ct);
            return saleItems.FirstOrDefault(x => x.Id == id);
        }

        public Task<int> GetCountAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public void Save(SaleItem obj)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(SaleItem obj, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
