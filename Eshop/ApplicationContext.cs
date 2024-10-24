using Eshop.Core;
using Eshop.DataAccess;
using Eshop.DataAccess.JSONDataStorage;
using Eshop.DataAccess.PGDataStorage;
using Eshop.Menu;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Eshop
{
    internal class ApplicationContext
    {
        private readonly IServiceProvider _sp;

        internal IRepository<Product> ProductManager { get; }
        internal IRepository<Service> ServiceManager { get; }
        internal IRepository<Order> OrderManager { get; }

        internal ApplicationContext()
        {
            var services = new ServiceCollection()
                .AddScoped<RepositoryFactory, JSONDataStorageFactory>()
                ;

            using var sp = services.BuildServiceProvider();

            _sp = sp;
            var _repositoryFactory = _sp.GetRequiredService<RepositoryFactory>();
            ProductManager = new PGDataStorageFactory("Server=127.0.0.1;Port=5432;Database=eshop;Username=postgres;Password=password").ProductManager();//_repositoryFactory.ProductManager();
            ServiceManager = _repositoryFactory.ServiceManager();
            OrderManager = _repositoryFactory.OrderManager();
        }

        internal MenuPage CurrentPage { get; set; } = new(null, []);

        public Cart Cart { get => GetCart(); }

        private Cart? _cart;

        public int GetNewOrderNumber()
        {
            var lastId = OrderManager.GetAll().MaxBy(x => x.Id)?.Id ?? 0;
            return ++lastId;
        }

        private Cart GetCart()
        {
            if (_cart != null)
                return _cart;

            if (!File.Exists("CacheData\\Cart.json"))
                return new();

            using var fs = new FileStream("CacheData\\Cart.json", FileMode.OpenOrCreate);
            _cart = JsonSerializer.Deserialize<Cart>(fs) ?? new();
            _cart.CartChangeNotyfy += UpdateCartCache;

            return _cart;
        }

        internal void UpdateCartCache()
        {
            if (_cart != null)
            {
                using var fs = new FileStream("CacheData\\Cart.json", FileMode.Truncate);
                JsonSerializer.Serialize(fs, _cart);
            }
        }
    }
}
