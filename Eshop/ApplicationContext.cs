using Eshop.Application.CartHandlers;
using Eshop.Application.OrderHandlers;
using Eshop.Application.SaleItemHandlers;
using Eshop.Core;
using Eshop.DataAccess;
using Eshop.DataAccess.DatabaseStorage;
using Eshop.Menu;
using Eshop.Menu.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop
{
    internal class ApplicationContext
    {
        private readonly IServiceProvider ServiceProvider;

        internal ApplicationContext(IConfiguration appconfig)
        {
            var services = new ServiceCollection()
                .AddSingleton<RepositoryFactory>(x => new DatabaseStorageFactory(appconfig["dbConnectionString"] ?? ""))
                .AddScoped<IRepository<Order>>(x => x.GetRequiredService<RepositoryFactory>().OrderRepository())
                .AddScoped<ApplicationContext>(x => this)
                .AddScoped<AddToCartCommand>()
                .AddScoped<BackCommand>()
                .AddScoped<ClearCartCommand>()
                .AddScoped<CreateOrderCommand>()
                .AddScoped<PreviosProductsCommand>()
                .AddScoped<NextProductsCommand>()
                .AddScoped<SetQtyDisplayedCommand>()
                .AddScoped<ShowCartCommand>()
                .AddScoped<ShowCatalogChoiceCommand>()
                .AddScoped<ShowCatalogCommand<Product>>()
                .AddScoped<ShowCatalogCommand<Service>>()
                .AddScoped<ShowOrdersCommand>()
                .AddScoped<OrderPayCommand>()
                .AddScoped<GetSaleItemHandler>()
                .AddScoped<AddItemToCartHandler>()
                .AddScoped<GetCartHandler>()
                .AddScoped<ClearCartHandler>()
                .AddScoped<CreateOrderFromCartHandler>()
                .AddScoped<GetOrderHandler>()
                ;

            ServiceProvider = services.BuildServiceProvider().CreateScope().ServiceProvider;
            MenuPage.ServiceProvider = ServiceProvider;

            var mainMenuCommands = new Dictionary<int, IMenuCommand>()
            {
                { 1, ServiceProvider.GetRequiredService<ShowCatalogChoiceCommand>() },
                { 4, ServiceProvider.GetRequiredService<ShowCartCommand>() },
                { 5, ServiceProvider.GetRequiredService<ShowOrdersCommand>() },
                { 0, new ExitCommand() }
            };
            CurrentPage = new(mainMenuCommands);
        }
        internal Stack<MenuPage> OpenPages = new();

        internal MenuPage CurrentPage { get => OpenPages.Peek(); set => OpenPages.Push(value); }
    }
}
