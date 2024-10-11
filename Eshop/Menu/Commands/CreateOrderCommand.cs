using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand : IMenuCommand
    {
        public string Description { get; } = "Create order";

        public void Execute(MenuPage currentPage)
        {
            if (ApplicationContext.Cart.Count == 0)
            {
                currentPage.InfoMessage = "Cart is empty!";
                currentPage.Show();
            }

            ApplicationContext.Orders.Add(new(ApplicationContext.Cart));
            ApplicationContext.Cart.Clear();
            var ordersPage = new OrdersPage(currentPage, []);
            ordersPage.Show();
        }
    }
}
