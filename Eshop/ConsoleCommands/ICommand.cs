using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.ConsoleCommands
{
    public interface IConsoleCommand
    {
        public string? Name { get; }
        public void Execute();

    }
}
