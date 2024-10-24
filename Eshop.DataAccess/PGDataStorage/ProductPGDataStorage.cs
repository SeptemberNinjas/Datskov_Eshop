using Eshop.Core;
using Npgsql;
using System.Data;

namespace Eshop.DataAccess.PGDataStorage
{
    internal class ProductPGDataStorage : DatabaseContext, IRepository<Product>
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
                    type = 1");

            using var reader = command.ExecuteReader();

            var result = new List<Product>();

            while (reader.Read())
            {
                result.Add(GetProduct(reader));
            }

            return result;
        }

        public void Save(Product obj)
        {
            throw new NotImplementedException();
        }

        private static Product GetProduct(NpgsqlDataReader reader)
        {
            return new Product(
                    reader.GetFieldValue<int>("id"),
                    reader.GetFieldValue<string>("name"),
                    reader.GetFieldValue<decimal>("price"),
                    (uint)reader.GetFieldValue<int>("amount"),
                    reader.GetFieldValue<string>("description"));
        }
    }
}
