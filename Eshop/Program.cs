using Eshop.Menu.Commands;

namespace Eshop
{
    internal class Program
    {
        internal static Dictionary<int, IMenuCommand> mainMenuCommands = new()
            {
                { 1, new ShowCatalogChoiceCommand() },
                { 4, new ShowCartCommand() },
                { 5, new ShowOrdersCommand() },
                { 0, new ExitCommand() }
            };

        static void Main(string[] args)
        {

            var context = new ApplicationContext()
            {
                CurrentPage = new(null, mainMenuCommands)
            };
            while (true)
            {
                var command = context.CurrentPage.Show();
                command.Execute(context);
            }
        }
    }
}
