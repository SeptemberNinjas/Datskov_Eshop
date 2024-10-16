using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand(Type productType) : IMenuCommand
    {
        public string Description { get; } = productType == typeof(Product) ? "Products" : "Services";

        public void Execute()
        {
            var previosPage = Program.Context.CurrentPage;
            CatalogPage catalogPage = new(previosPage, [], productType) { SaleItems = productType == typeof(Service) ? ApplicationContext.Services : ApplicationContext.Products };

            Program.Context.CurrentPage = catalogPage;
        }
    }
}
