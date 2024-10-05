using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand : IMenuCommand
    {
        public string? Description { get; } = "Show catalog";

        public void Execute(MenuPage CurrentPage)
        {
            var CatalogCommands = new Dictionary<int, IMenuCommand>();
            CatalogCommands.Add(0, new BackCommand());
            
            MenuPage Catalog = new MenuPage(CurrentPage, CatalogCommands);
            Catalog.DrawPage();
            Catalog.ActionProcessing();
        }
    }
}
