using Eshop.Application.CartHandlers;
using Eshop.Application.OrderHandlers;
using Eshop.Application.SaleItemHandlers;
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
                // Регистрация обработчиков
                .AddScoped<GetSaleItemHandler>()
                .AddScoped<AddItemToCartHandler>()
                .AddScoped<GetCartHandler>()
                .AddScoped<ClearCartHandler>()
                .AddScoped<CreateOrderFromCartHandler>()
                .AddScoped<GetOrderHandler>();
                
            return services;
        }
    }
}
