using Eshop.Core;

namespace Eshop.DataAccess.DatabaseStorage
{
    public class DatabaseStorageFactory : RepositoryFactory
    {
        private readonly string _connectionString;
        
        public DatabaseStorageFactory(string connectionString) => _connectionString = connectionString;

        public override IRepository<Order> OrderRepository() => new OrderDatabaseStorage(_connectionString);

        public override IRepository<Product> ProductRepository() => new ProductDatabaseStorage(_connectionString);

        public override IRepository<Service> ServiceRepository() => new ServiceDatabaseStorage(_connectionString);

        public override IRepository<Cart> CartRepository() => new CartDatebaseStorage(_connectionString, ProductRepository(), ServiceRepository());

        public override IRepository<SaleItem> SaleItemRepository() => new SaleItemDatabaseStorage(_connectionString);
    }
}
