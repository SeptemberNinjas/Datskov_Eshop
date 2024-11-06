namespace Eshop.Menu.Commands
{
    internal class ShowCartCommand(ApplicationContext context) : IMenuCommand
    {
        public string Description { get; } = "Show cart";

        public void Execute()
        {
            context.CurrentPage = new CartPage([]);
        }
    }
}
