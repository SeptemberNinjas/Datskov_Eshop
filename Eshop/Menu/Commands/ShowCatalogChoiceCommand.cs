using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogChoiceCommand : IMenuCommand
    {
        public string Description { get; } = "Show catalog";
        private readonly Dictionary<int, IMenuCommand> _catCommands = new()
            {
                { 1, new ShowCatalogCommand(typeof(Product)) },
                { 2, new ShowCatalogCommand(typeof(Service)) },
                { 0, new BackCommand() }
            };

        public void Execute()
        {
            var previosPage = Program.Context.CurrentPage;

            Program.Context.CurrentPage = new(previosPage, _catCommands);
        }
    }
}
