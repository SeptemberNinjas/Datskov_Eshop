using Eshop.Menu.Commands;

namespace Eshop
{
    internal class Program
    {
        private static readonly ApplicationContext _context = new();

        internal static Dictionary<int, IMenuCommand> mainMenuCommands = new()
            {
                { 1, new ShowCatalogChoiceCommand() },
                { 4, new ShowCartCommand() },
                { 5, new ShowOrdersCommand() },
                { 0, new ExitCommand() }
            };

        static void Main(string[] args)
        {
            _context.CurrentPage = new(null, mainMenuCommands);
            while (true)
            {
                var command = _context.CurrentPage.Show();
                command.Execute(_context);
            }
        }
    }
}
