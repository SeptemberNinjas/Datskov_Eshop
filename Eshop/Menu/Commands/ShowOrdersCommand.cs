using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowOrdersCommand(ApplicationContext context, IRepository<Order> orderManager) : IMenuCommand
    {
        public string Description { get; } = "Show my orders";

        public void Execute()
        {
            var previosPage = context.CurrentPage;
            OrdersPage.Orders = [.. orderManager.GetAll()];
            OrdersPage ordersPage = new(previosPage, []);

            context.CurrentPage = ordersPage;
        }
    }
}
