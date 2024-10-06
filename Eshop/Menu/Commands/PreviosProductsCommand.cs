using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class PreviosProductsCommand : IMenuCommand
    {
        public string? Description { get; } = "Previos page";

        public void Execute(MenuPage CurrentPage)
        {
            //(CatalogPage)CurrentPage;
        }
    }
}
