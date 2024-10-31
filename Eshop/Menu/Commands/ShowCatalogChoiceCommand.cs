using Eshop.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogChoiceCommand(ApplicationContext context, IServiceProvider sp) : IMenuCommand
    {
        public string Description { get; } = "Show catalog";

        public void Execute()
        {
            Dictionary<int, IMenuCommand> catCommands = new()
            {
                { 1, sp.GetRequiredService<ShowCatalogCommand<Product>>() },
                { 2, sp.GetRequiredService<ShowCatalogCommand<Service>>() },
                { 0, sp.GetRequiredService<BackCommand>() }
            };

            context.CurrentPage = new(catCommands);
        }
    }
}
