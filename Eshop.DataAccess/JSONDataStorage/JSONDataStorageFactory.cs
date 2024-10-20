using Eshop.Core;

namespace Eshop.DataAccess.JSONDataStorage
{
    public class JSONDataStorageFactory : RepositoryFactory
    {
        public override IRepository<Product> ProductManager()
        {
            return new ProductJSONDataStorage();
        }

        public override IRepository<Service> ServiceManager()
        {
            return new ServiceJSONDataStorage();
        }
    }
}
