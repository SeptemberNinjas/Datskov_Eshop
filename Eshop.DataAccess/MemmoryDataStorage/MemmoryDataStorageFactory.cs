using Eshop.Core;

namespace Eshop.DataAccess.MemmoryDataStorage
{
    public class MemmoryDataStorageFactory : RepositoryFactory
    {
        public override IRepository<Product> ProductManager()
        {
            return new ProductMemmoryDataStorage();
        }

        public override IRepository<Service> ServiceManager()
        {
            return new ServiceMemmoryDataStorage();
        }
    }
}
