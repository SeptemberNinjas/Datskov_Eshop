using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand(Type productType) : IMenuCommand
    {
        public string Description { get; } = productType == typeof(Product) ? "Products" : "Services";
        
        public void Execute(MenuPage currentPage)
        {
            CatalogPage Catalog = new(currentPage, [], productType);
            if (productType == typeof(Product))
                Catalog.Products = ApplicationContext.Products;
            else if (productType == typeof(Service))
                Catalog.Services = ApplicationContext.Services;

            Catalog.Show();
        }
    }
}
