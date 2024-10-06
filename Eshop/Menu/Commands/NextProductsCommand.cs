using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    class NextProductsCommand : IMenuCommand
    {
        public string? Description { get; } = "Next page";

        public void Execute(MenuPage CurrentPage)
        {
            //(CatalogPage)CurrentPage = CurrentPage;

            //(CatalogPage)CurrentPage;
        }
    }
}
