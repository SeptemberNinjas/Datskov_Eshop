using Eshop.Core;
using System.Text.Json;

namespace Eshop.DataAccess.JSONDataStorage
{
    internal class ProductJSONDataStorage : IRepository<Product>
    {
        public IReadOnlyCollection<Product> GetAll()
        {
            IEnumerable<Product>? products;
            using (var fs = new FileStream("JSONDataStorage\\data\\Products.json", FileMode.OpenOrCreate))
            {
                products = JsonSerializer.Deserialize<IEnumerable<Product>>(fs);
            }

            return (IReadOnlyCollection<Product>)(products ?? []);
        }

        public void Save(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
