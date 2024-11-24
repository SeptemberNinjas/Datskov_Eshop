using Eshop.Core;

namespace Eshop.DataAccess
{
    public abstract class RepositoryFactory
    {
        public abstract IRepository<Product> ProductRepository();
        public abstract IRepository<Service> ServiceRepository();
        public abstract IRepository<Order> OrderRepository();
        public abstract IRepository<Cart> CartRepository();
        public abstract IRepository<SaleItem> SaleItemRepository();
    }
}
