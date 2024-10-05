using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal interface IMenuCommand
    {
        string? Description { get; }

        void Execute(MenuPage CurrentPage);
    }
}
