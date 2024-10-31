using Eshop.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand<T>(ApplicationContext context, IServiceProvider serviceProvider) : IMenuCommand where T : SaleItem
    {
        public string Description { get; } = typeof(T) == typeof(Product) ? "Products" : "Services";

        public void Execute()
        {
            var previosPage = context.CurrentPage;
            CatalogPage catalogPage = new([], typeof(T));

            var saleItemManager = serviceProvider.GetRequiredService<IRepository<T>>();

            catalogPage.SaleItems = [.. saleItemManager.GetAll()];

            context.CurrentPage = catalogPage;
        }

        public async Task ExecuteAsync(CancellationToken ct = default)
        {
            var previosPage = context.CurrentPage;
            CatalogPage catalogPage = new([], typeof(T));

            var saleItemManager = serviceProvider.GetRequiredService<IRepository<T>>();
            
            catalogPage.SaleItems = [.. await saleItemManager.GetAllAsync(ct)];

            context.CurrentPage = catalogPage;
        }
    }
}
