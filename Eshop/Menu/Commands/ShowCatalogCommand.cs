using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand(Type productType) : IMenuCommand
    {
        public string Description { get; } = productType == typeof(Product) ? "Products" : "Services";

        public void Execute(ApplicationContext app)
        {
            var previosPage = app.CurrentPage;
            CatalogPage catalogPage = new(previosPage, [], productType) { SaleItems = productType == typeof(Service) ? app.ServiceManager.GetAll().ToArray() : app.ProductManager.GetAll().ToArray() };

            app.CurrentPage = catalogPage;
        }
    }
}
