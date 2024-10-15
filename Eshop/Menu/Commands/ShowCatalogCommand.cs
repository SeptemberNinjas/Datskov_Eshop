using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand(Type productType) : IMenuCommand
    {
        public string Description { get; } = productType == typeof(Product) ? "Products" : "Services";

        public void Execute(MenuPage currentPage)
        {
            CatalogPage Catalog = new(currentPage, [], productType) { SaleItems = productType == typeof(Service) ? ApplicationContext.Services : ApplicationContext.Products };

            Catalog.Show();
        }
    }
}
