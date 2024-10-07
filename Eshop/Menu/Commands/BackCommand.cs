using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class BackCommand : IMenuCommand
    {
        public string? Description { get;  } = "Back";

        public void Execute(MenuPage CurrentPage)
        {
            MenuPage? previosPage = CurrentPage.PreviosPage;
            previosPage?.Show();
        }
    }
}
