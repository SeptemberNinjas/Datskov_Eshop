using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand(ProductType productType) : IMenuCommand
    {
        public string? Description { get; } = productType.ToString();

        void IMenuCommand.Execute(MenuPage CurrentPage)
        {
            var CatalogCommands = new Dictionary<int, IMenuCommand> { };

            CatalogPage Catalog = new(CurrentPage, CatalogCommands);
            Catalog.Show();
        }
    }
}
