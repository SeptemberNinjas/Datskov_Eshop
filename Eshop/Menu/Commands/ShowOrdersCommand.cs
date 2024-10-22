namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand : IMenuCommand
    {
        public string Description { get; } = "Show my orders";

        public void Execute(ApplicationContext app)
        {
            var previosPage = app.CurrentPage;
            OrdersPage ordersPage = new(previosPage, []) { Orders = [.. app.OrderManager.GetAll()] };

            app.CurrentPage = ordersPage;
        }
    }
}
