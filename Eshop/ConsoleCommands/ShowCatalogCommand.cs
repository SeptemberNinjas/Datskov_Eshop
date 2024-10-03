using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.ConsoleCommands
{
    public class ShowCatalogCommand : IConsoleCommand
    {

        string? IConsoleCommand.Name { get; } = "Показать каталог";

        void IConsoleCommand.Execute()
        {
            Console.WriteLine("catalogggg");
        }
    }
}
