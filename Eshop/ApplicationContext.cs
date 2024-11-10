﻿using Eshop.Core;
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
                .AddScoped<IRepository<Product>>(x => x.GetRequiredService<RepositoryFactory>().ProductRepository())
                .AddScoped<IRepository<Service>>(x => x.GetRequiredService<RepositoryFactory>().ServiceRepository())
                .AddScoped<IRepository<Order>>(x => x.GetRequiredService<RepositoryFactory>().OrderRepository())
                .AddScoped<IRepository<Cart>>(x => x.GetRequiredService<RepositoryFactory>().CartRepository())
                .AddScoped<Cart>(x => x.GetRequiredService<RepositoryFactory>().CartRepository().GetAllAsync().Result.FirstOrDefault() ?? new Cart())
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
                ;

            ServiceProvider = services.BuildServiceProvider().CreateScope().ServiceProvider;
            MenuPage.ServiceProvider = ServiceProvider;

            var cart = ServiceProvider.GetRequiredService<Cart>();
            cart.CartChangeNotyfy += UpdateCartCache;

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

        public int GetNewOrderNumber()
        {
            var lastId = ServiceProvider.GetRequiredService<IRepository<Order>>().GetAllAsync().Result.MaxBy(x => x.Id)?.Id ?? 0;
            return ++lastId;
        }

        internal async void UpdateCartCache()
        {
            var cart = ServiceProvider.GetRequiredService<Cart>();
            if (cart != null)
                await ServiceProvider.GetRequiredService<IRepository<Cart>>().SaveAsync(cart);
        }
    }
}
