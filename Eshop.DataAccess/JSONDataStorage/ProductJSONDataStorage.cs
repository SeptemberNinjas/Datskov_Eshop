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

        public Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken ct = default) => Task.FromResult(GetAll());

        public Product? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public Task<Product?> GetByIdAsync(int id, CancellationToken ct = default) => Task.FromResult(GetById(id));

        public Task<int> GetCountAsync(CancellationToken ct = default) => Task.FromResult(GetAll().Count);

        public void Save(Product obj)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Product obj, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
