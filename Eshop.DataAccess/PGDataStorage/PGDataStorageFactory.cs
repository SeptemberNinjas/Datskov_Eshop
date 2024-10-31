using Eshop.Core;

namespace Eshop.DataAccess.PGDataStorage
{
    public class PGDataStorageFactory : RepositoryFactory
    {
        private readonly string _connectionString;
        
        public PGDataStorageFactory(string connectionString) => _connectionString = connectionString;

        public override IRepository<Order> OrderManager() => new OrderPGDataStorage(_connectionString);

        public override IRepository<Product> ProductManager() => new ProductPGDataStorage(_connectionString);

        public override IRepository<Service> ServiceManager() => new ServicePGDataStorage(_connectionString);
    }
}
