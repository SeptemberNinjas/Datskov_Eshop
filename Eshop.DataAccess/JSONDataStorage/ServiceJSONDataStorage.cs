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

        public void Save(Service obj)
        {
            throw new NotImplementedException();
        }
    }
}
