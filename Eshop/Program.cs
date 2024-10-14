using Eshop.Menu;
using Eshop.Menu.Commands;

namespace Eshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainMenuCommands = new Dictionary<int, IMenuCommand>
            {
                { 1, new ShowCatalogChoiceCommand() },
                { 4, new ShowCartCommand() },
                { 5, new ShowOrdersCommand() },
                { 0, new ExitCommand() }
            };

            MenuPage MainMenu = new(null, mainMenuCommands);
            MainMenu.Show();
        }
    }
}
