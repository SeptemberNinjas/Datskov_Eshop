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
                return;
            }

            ApplicationContext.Orders.Add(new(ApplicationContext.Cart));
            ApplicationContext.Cart.Clear();

            new ShowOrdersCommand().Execute(currentPage);
        }
    }
}
