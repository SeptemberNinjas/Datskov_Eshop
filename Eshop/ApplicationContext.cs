using Eshop.Core;
using Eshop.DataAccess;
using Eshop.DataAccess.JSONDataStorage;
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

        internal ApplicationContext()
        {
            var services = new ServiceCollection()
                .AddScoped<RepositoryFactory, JSONDataStorageFactory>()
                ;

            using var sp = services.BuildServiceProvider();

            _sp = sp;
            var _repositoryFactory = _sp.GetRequiredService<RepositoryFactory>();
            ProductManager = _repositoryFactory.ProductManager();
            ServiceManager = _repositoryFactory.ServiceManager();
        }

        internal MenuPage CurrentPage { get; set; } = new(null, []);

        private static int _lastOrderNum = 0;
        public Cart Cart { get => GetCart(); }

        private Cart? _cart;
        public List<Order> Orders { get; } = [];

        public int GetNewOrderNumber() => ++_lastOrderNum;

        private Cart GetCart() 
        {
            if (_cart != null)
                return _cart;

            if (!File.Exists("CacheData\\Cart.json"))
                return new();

            var jsOptions = new JsonSerializerOptions();
            jsOptions.IncludeFields = true;
            jsOptions.PropertyNameCaseInsensitive = true;

            using var fs = new FileStream("CacheData\\Cart.json", FileMode.OpenOrCreate);
            _cart = JsonSerializer.Deserialize<Cart>(fs, jsOptions) ?? new();

            return _cart;
        }

        internal void BeforeExit()
        {
            if (_cart != null)
            {
                using var fs = new FileStream("CacheData\\Cart.json", FileMode.OpenOrCreate);
                JsonSerializer.Serialize(fs, _cart);
            }
        }
    }
}
