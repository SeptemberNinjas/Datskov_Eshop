using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogChoiceCommand(
        ApplicationContext context,
        ShowCatalogCommand<Product> showProductCommand,
        ShowCatalogCommand<Service> showServiceCommand,
        BackCommand backCommand) : IMenuCommand
    {
        public string Description { get; } = "Show catalog";

        public void Execute()
        {
            Dictionary<int, IMenuCommand> catCommands = new()
            {
                { 1, showProductCommand },
                { 2, showServiceCommand },
                { 0, backCommand }
            };

            context.CurrentPage = new(catCommands);
        }
    }
}
