using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand(Type productType) : IMenuCommand
    {
        public string Description { get; } = productType == typeof(Product) ? "Products" : "Services";
        
        private readonly Dictionary<int, IMenuCommand> _catCommands = new()
        {
            { 1, new PreviosProductsCommand() },
            { 2, new NextProductsCommand() },
            { 3, new AddToCartCommand() },
            { 4, new ShowCartCommand() },
            { 9, new SetQtyDisplayedCommand() },
            { 0, new BackCommand() }
        };

        public void Execute(MenuPage currentPage)
        {
            CatalogPage Catalog = new(currentPage, _catCommands, productType);
            Catalog.Show();
        }
    }
}
