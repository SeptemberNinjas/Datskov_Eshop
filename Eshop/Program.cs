using Eshop.Menu;
using Eshop.Menu.Commands;
using System.Reflection;
using System.Reflection.Metadata;

namespace Eshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainMenuCommands = new Dictionary<int, IMenuCommand>();
            mainMenuCommands.Add(1, new ShowCatalogCommand());
            mainMenuCommands.Add(0, new ExitCommand());

            MenuPage MainMenu = new MenuPage(null, mainMenuCommands);
            MainMenu.DrawPage();
            MainMenu.ActionProcessing();
        }
    }
}
