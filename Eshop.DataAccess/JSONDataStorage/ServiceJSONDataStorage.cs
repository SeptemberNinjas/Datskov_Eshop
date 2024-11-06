using Eshop.Core;
using System.Text.Json;

namespace Eshop.DataAccess.JSONDataStorage
{
    internal class ServiceJSONDataStorage : IRepository<Service>
    {
        public IReadOnlyCollection<Service> GetAll()
        {
            IEnumerable<Service>? services;
            using (var fs = new FileStream("JSONDataStorage\\data\\Services.json", FileMode.OpenOrCreate))
            {
                services = JsonSerializer.Deserialize<IEnumerable<Service>>(fs);
            }

            return (IReadOnlyCollection<Service>)(services ?? []);
        }

        public Task<IReadOnlyCollection<Service>> GetAllAsync(CancellationToken ct = default) => Task.FromResult(GetAll());

        public Service? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public Task<Service?> GetByIdAsync(int id, CancellationToken ct = default) => Task.FromResult(GetById(id));
        
        public Task<int> GetCountAsync(CancellationToken ct = default) => Task.FromResult(GetAll().Count);

        public void Save(Service obj)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Service obj, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
