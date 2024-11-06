using Eshop.Core;
using Eshop.Menu.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu
{
    internal class CartPage : MenuPage
    {
        public CartPage(Dictionary<int, IMenuCommand> commands) : base(commands)
        {
            commands.Clear();
            commands.Add(1, ServiceProvider.GetRequiredService<CreateOrderCommand>());
            commands.Add(5, ServiceProvider.GetRequiredService<ShowOrdersCommand>());
            commands.Add(10, ServiceProvider.GetRequiredService<ClearCartCommand>());
            commands.Add(0, ServiceProvider.GetRequiredService<BackCommand>());
        }
        public override void DrawPage()
        {
            var cart = ServiceProvider.GetRequiredService<Cart>();

            Console.WriteLine("--// Cart // --");
            Console.WriteLine("----------------------------------------------------------");

            foreach (CartItem cartItem in cart.Items)
            {
                var name = cartItem.Product?.Name ?? cartItem.Service?.Name;
                Console.WriteLine("Name:   " + name);
                Console.WriteLine("Price:  " + cartItem.Price);
                Console.WriteLine("Count:  " + cartItem.Count);
                Console.WriteLine("Amount: " + cartItem.Amount);
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("{0} positions", cart.Count);
            Console.WriteLine("Total amount : {0} RUB", cart.TotalAmount);
            Console.WriteLine();

            DrawCommandInterface();
        }
    }
}
