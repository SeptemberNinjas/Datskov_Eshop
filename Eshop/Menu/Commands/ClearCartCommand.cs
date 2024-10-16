namespace Eshop.Menu.Commands
{
    internal class ClearCartCommand : IMenuCommand
    {
        public string Description { get; } = "Clear cart";

        public void Execute()
        {
            var currentPage = Program.Context.CurrentPage;
            currentPage.InfoMessage = "Cart was cleared";

            Program.Context.Cart.Clear();
        }
    }
}
