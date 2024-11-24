using Eshop.Application.CartHandlers;
using Eshop.Application.OrderHandlers;
using Eshop.Application.SaleItemHandlers;
using Eshop.Core;
using Eshop.DataAccess;
using Eshop.DataAccess.DatabaseStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Application
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<RepositoryFactory>(_ => new DatabaseStorageFactory(configuration["dbconnectionstring"] ?? ""))
                .AddScoped<IRepository<SaleItem>>(x => x.GetRequiredService<RepositoryFactory>().SaleItemRepository())
                .AddScoped<IRepository<Order>>(x => x.GetRequiredService<RepositoryFactory>().OrderRepository())
                .AddScoped<IRepository<Cart>>(x => x.GetRequiredService<RepositoryFactory>().CartRepository())
                // Регистрация обработчиков
                .AddScoped<GetSaleItemHandler>()
                .AddScoped<AddItemToCartHandler>()
                .AddScoped<GetCartHandler>()
                .AddScoped<ClearCartHandler>()
                .AddScoped<CreateOrderHandler>()
                .AddScoped<GetOrderHandler>();
                
            return services;
        }
    }
}
