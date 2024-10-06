using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogChoiceCommand : IMenuCommand
    {
        public string? Description { get; } = "Show catalog";

        public void Execute(MenuPage CurrentPage)
        {
            var CatalogCommands = new Dictionary<int, IMenuCommand>
            {
                { 1, new ShowCatalogCommand(ProductType.Product) },
                { 2, new ShowCatalogCommand(ProductType.Service) },
                { 0, new BackCommand() }
            };
            
            MenuPage Catalog = new(CurrentPage, CatalogCommands);
            Catalog.Show();
        }
    }
}
