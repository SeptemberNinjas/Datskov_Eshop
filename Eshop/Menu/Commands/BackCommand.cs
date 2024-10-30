namespace Eshop.Menu.Commands
{
    internal class BackCommand(ApplicationContext context) : IMenuCommand
    {
        public string Description { get; } = "Back";

        public void Execute()
        {
            context.CurrentPage = context.CurrentPage?.PreviosPage ?? context?.CurrentPage ?? new(null, []);
        }
    }
}
