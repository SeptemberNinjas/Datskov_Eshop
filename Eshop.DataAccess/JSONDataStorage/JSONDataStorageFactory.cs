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

        public override IRepository<Order> OrderManager()
        {
            return new OrderJSONDataStorage();
        }

        public override IRepository<Cart> CartManager()
        {
            throw new NotImplementedException();
        }
    }
}
