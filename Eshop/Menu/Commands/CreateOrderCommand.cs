using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand(
        ApplicationContext context,
        IRepository<Order> orderRepository,
        ShowOrdersCommand showOrdersCommand,
        Cart cart) : IMenuCommand
    {
        public string Description { get; } = "Create order";

        public void Execute() => ExecuteAsync().Wait();

        public async Task ExecuteAsync()
        {
            if (cart.Count == 0)
            {
                context.CurrentPage.InfoMessage = "Cart is empty!";
                return;
            }

            var order = new Order(context.GetNewOrderNumber());
            foreach (var cartItem in cart.Items)
            {
                var orderLine = order.Add();
                orderLine.SaleItemId = cartItem.Product?.Id ?? cartItem.Service?.Id ?? 0;
                orderLine.Price = cartItem.Price;
                orderLine.Count = cartItem.Count;
            }

            await orderRepository.SaveAsync(order);
            cart.Clear();

            await showOrdersCommand.ExecuteAsync();
        }
    }
}
