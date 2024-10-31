using Eshop.Core;
using System.Text.Json;

namespace Eshop.DataAccess.JSONDataStorage
{
    internal class ServiceJSONDataStorage : IRepository<Service>
    {
        public IReadOnlyCollection<Service> GetAll()
        {
            Service[]? services;
            using (var fs = new FileStream("JSONDataStorage\\data\\Services.json", FileMode.OpenOrCreate))
            {
                services = JsonSerializer.Deserialize<Service[]>(fs);
            }

            services ??= [];

            return services;
        }

        public Task<IReadOnlyCollection<Service>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Service>? GetByIdAsync(int Id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

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
