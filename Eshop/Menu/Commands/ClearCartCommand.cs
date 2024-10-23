namespace Eshop.Menu.Commands
{
    internal class ClearCartCommand : IMenuCommand
    {
        public string Description { get; } = "Clear cart";

        public void Execute(ApplicationContext app)
        {
            var currentPage = app.CurrentPage;
            currentPage.InfoMessage = "Cart was cleared";

            app.Cart.Clear();
        }
    }
}
