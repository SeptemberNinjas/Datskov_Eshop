namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand : IMenuCommand
    {
        public string Description { get; } = "Show my orders";

        public void Execute(ApplicationContext app)
        {
            var previosPage = app.CurrentPage;
            OrdersPage.Orders = [.. app.OrderManager.GetAll()];
            OrdersPage ordersPage = new(previosPage, []);
            
            app.CurrentPage = ordersPage;
        }
    }
}
