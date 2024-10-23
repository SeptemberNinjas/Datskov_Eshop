namespace Eshop.Menu.Commands
{
    internal class ShowCartCommand : IMenuCommand
    {
        public string Description { get; } = "Show cart";

        public void Execute(ApplicationContext app)
        {
            var previosPage = app.CurrentPage;

            app.CurrentPage = new CartPage(previosPage, []) { Cart = app.Cart };
        }
    }
}
