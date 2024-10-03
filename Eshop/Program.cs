using Eshop.ConsoleCommands;
using System.Reflection;
using System.Reflection.Metadata;

namespace Eshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var Menu = MainMenu();
                foreach (var KeyValue in Menu)
                {
                    Console.WriteLine(KeyValue.Key + ". " + KeyValue.Value.Name);
                }
                Menu[0].Execute();

                Console.ReadLine();
            }
        }

        internal static Dictionary<int, IConsoleCommand> MainMenu()
        {
            var Commands = new Dictionary<int, IConsoleCommand>();
            Commands.Add(1, new ShowCatalogCommand());
            Commands.Add(0, new ExitCommand());

            return Commands;
        }



    }
}
