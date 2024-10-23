using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand : IMenuCommand
    {
        public string Description { get; } = "Create order";

        public void Execute(ApplicationContext app)
        {
            if (app.Cart.Count == 0)
            {
                var currentPage = app.CurrentPage;

                currentPage.InfoMessage = "Cart is empty!";
                return;
            }

            var order = new Order(app.GetNewOrderNumber());
            foreach (var cartItem in app.Cart.Items)
            {
                var orderLine = order.Add();
                orderLine.Product = cartItem.Product;
                orderLine.Price = cartItem.Price;
                orderLine.Service = cartItem.Service;
                orderLine.Count = cartItem.Count;
                orderLine.Amount = cartItem.Amount;
            }

            app.OrderManager.Save(order);
            app.Cart.Clear();

            new ShowOrdersCommand().Execute(app);
        }
    }
}
