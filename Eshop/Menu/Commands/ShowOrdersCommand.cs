namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand : IMenuCommand
    {
        public string Description { get; } = "Show my orders";

        public void Execute()
        {
            var previosPage = Program.Context.CurrentPage;
            OrdersPage ordersPage = new(previosPage, []) { Orders = [.. ApplicationContext.Orders] };

            Program.Context.CurrentPage = ordersPage;
        }
    }
}
