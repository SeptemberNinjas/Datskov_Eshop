using Eshop.Core;
using Eshop.DataAccess;
using Eshop.DataAccess.MemmoryDataStorage;
using Eshop.Menu;

namespace Eshop
{
    internal class ApplicationContext()
    {
        internal MenuPage CurrentPage { get; set; } = new(null, []);

        internal IRepository<Product> ProductManager { get; } = _repositoryFactory.ProductManager();
        internal IRepository<Service> ServiceManager { get; } = _repositoryFactory.ServiceManager();

        private static readonly RepositoryFactory _repositoryFactory = new MemmoryDataStorageFactory();

        internal Product[] Products { get { return [.. ProductManager.GetAll()]; } }

        internal Service[] Services { get { return [.. ServiceManager.GetAll()]; } }

        internal Product? GetProductByID(int Id) => ProductManager.GetById(Id);

        internal Service? GetServiceByID(int Id) => ServiceManager.GetById(Id);

        private static int _lastOrderNum = 0;
        public Cart Cart { get; } = new();
        public List<Order> Orders { get; } = [];

        public int GetNewOrderNumber() => ++_lastOrderNum;
    }
}
