using Eshop.Core;

namespace Eshop.DataAccess
{
    public abstract class RepositoryFactory
    {
        public abstract IRepository<Product> ProductManager();
        public abstract IRepository<Service> ServiceManager();

    }
}
