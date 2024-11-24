using Eshop.Application.CartHandlers;
using Eshop.Menu.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu
{
    internal class CartPage : MenuPage
    {
        public CartDto CartDto { get; set; } = new([]);
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
            Console.WriteLine("--// Cart // --");
            Console.WriteLine("----------------------------------------------------------");

            foreach (var cartItem in CartDto.Items)
            {
                Console.WriteLine("Name:   " + cartItem.SaleItem.Name);
                Console.WriteLine("Price:  " + cartItem.Price);
                Console.WriteLine("Count:  " + cartItem.Count);
                Console.WriteLine("Amount: " + cartItem.Amount);
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("{0} positions", CartDto.Count);
            Console.WriteLine("Total amount : {0} RUB", CartDto.TotalAmount);
            Console.WriteLine();

            DrawCommandInterface();
        }
    }
}
