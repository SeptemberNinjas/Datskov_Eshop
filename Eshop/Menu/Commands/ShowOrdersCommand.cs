namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand : IMenuCommand
    {
        public string Description { get; } = "Show my orders";

        public void Execute(MenuPage currentPage)
        {
            OrdersPage orderPage = new(currentPage, []);
            orderPage.Show();
        }
    }
}
