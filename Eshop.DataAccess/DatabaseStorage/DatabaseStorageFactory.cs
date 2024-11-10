using Eshop.Core;

namespace Eshop.DataAccess.DatabaseStorage
{
    public class DatabaseStorageFactory : RepositoryFactory
    {
        private readonly string _connectionString;
        
        public DatabaseStorageFactory(string connectionString) => _connectionString = connectionString;

        public override IRepository<Order> OrderManager() => new OrderDatabaseStorage(_connectionString);

        public override IRepository<Product> ProductManager() => new ProductDatabaseStorage(_connectionString);

        public override IRepository<Service> ServiceManager() => new ServiceDatabaseStorage(_connectionString);

        public override IRepository<Cart> CartManager() => new CartDatebaseStorage(_connectionString, ProductManager(), ServiceManager());
    }
}
