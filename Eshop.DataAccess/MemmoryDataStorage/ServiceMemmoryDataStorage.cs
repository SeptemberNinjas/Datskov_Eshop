using Eshop.Core;

namespace Eshop.DataAccess.MemmoryDataStorage
{
    public class ServiceMemmoryDataStorage : IRepository<Service>
    {
        public IReadOnlyCollection<Service> GetAll()
        {
            Service[] _services = [
                    new (1, "Update Android to version 1.2.1.45.85.1.9.7.33", 1000),
                    new (2, "Extra warranty 120 years", 3000),
                    new (3, "Watch in your eyes", 100),
                    new (4, "Some service1", 200)];

            return _services;
        }
    }
}
