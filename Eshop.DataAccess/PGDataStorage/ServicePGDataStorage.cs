using Eshop.Core;

namespace Eshop.DataAccess.PGDataStorage
{
    public class ServicePGDataStorage : DatabaseContext, IRepository<Service>
    {
        public ServicePGDataStorage(string connectionString) : base(connectionString) { }

        public IReadOnlyCollection<Service> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Service obj)
        {
            throw new NotImplementedException();
        }
    }
}
