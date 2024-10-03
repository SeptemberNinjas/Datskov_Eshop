using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.ConsoleCommands
{
    public class ExitCommand : IConsoleCommand
    {
        string? IConsoleCommand.Name { get; } = "Выход";

        void IConsoleCommand.Execute()
        {
            Environment.Exit(0);
        }
    }
}
