using Eshop.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu.Commands
{
    internal class CreateOrderCommand(IServiceProvider sp, Cart cart, ApplicationContext context) : IMenuCommand
    {
        public string Description { get; } = "Create order";

        public void Execute()
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
                orderLine.Product = cartItem.Product;
                orderLine.Price = cartItem.Price;
                orderLine.Service = cartItem.Service;
                orderLine.Count = cartItem.Count;
                orderLine.Amount = cartItem.Amount;
            }

            sp.GetRequiredService<IRepository<Order>>().Save(order);
            cart.Clear();

            sp.GetRequiredService<ShowOrdersCommand>().Execute();
        }
    }
}
