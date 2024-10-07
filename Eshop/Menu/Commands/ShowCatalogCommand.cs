using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand(Type productType) : IMenuCommand
    {
        public string? Description { get; } = productType == typeof(Product) ? "Products" : "Services";

        void IMenuCommand.Execute(MenuPage CurrentPage)
        {
            var CatalogCommands = new Dictionary<int, IMenuCommand> 
            {
                { 1, new PreviosProductsCommand() },
                { 2, new NextProductsCommand() },
                { 9, new SetQtyDisplayedCommand() },
                { 0, new BackCommand() }
            };

            CatalogPage Catalog = new(CurrentPage, CatalogCommands, productType);
            Catalog.Show();
        }
    }
}
