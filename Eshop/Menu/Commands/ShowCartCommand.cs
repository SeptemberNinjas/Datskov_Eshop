namespace Eshop.Menu.Commands
{
    internal class ShowCartCommand : IMenuCommand
    {
        public string Description { get; } = "Show cart";

        public void Execute()
        {
            var previosPage = Program.Context.CurrentPage;

            Program.Context.CurrentPage = new CartPage(previosPage, []) { Cart = Program.Context.Cart };
        }
    }
}
