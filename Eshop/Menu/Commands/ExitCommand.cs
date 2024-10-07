using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class ExitCommand : IMenuCommand
    {
        string? IMenuCommand.Description { get;  } = "Exit";

        public void Execute(MenuPage CurrentPage) => Environment.Exit(0);
    }
}
