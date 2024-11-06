using Eshop.Core;

namespace Eshop.DataAccess.MemmoryDataStorage
{
    public class ServiceMemmoryDataStorage : IRepository<Service>
    {
        public IReadOnlyCollection<Service> GetAll()
        {
            Service[] _services = [
                    new (8, "Update Android to version 1.2.1.45.85.1.9.7.33", 1000),
                    new (9, "Extra warranty 120 years", 3000),
                    new (10, "Watch in your eyes", 100),
                    new (11, "Some service1", 200)];

            return _services;
        }

        public Task<IReadOnlyCollection<Service>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Service? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Service?> GetByIdAsync(int Id, CancellationToken ct = default)
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
