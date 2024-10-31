using Eshop.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand(IServiceProvider sp, Cart cart, ApplicationContext context) : IMenuCommand
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

            await sp.GetRequiredService<IRepository<Order>>().SaveAsync(order);
            cart.Clear();

            await sp.GetRequiredService<ShowOrdersCommand>().ExecuteAsync();
        }
    }
}
