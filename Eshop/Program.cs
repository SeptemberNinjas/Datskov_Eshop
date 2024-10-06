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
            var mainMenuCommands = new Dictionary<int, IMenuCommand>
            {
                { 1, new ShowCatalogChoiceCommand() },
                { 0, new ExitCommand() }
            };

            MenuPage MainMenu = new(null, mainMenuCommands);
            MainMenu.Show();
        }
    }
}
