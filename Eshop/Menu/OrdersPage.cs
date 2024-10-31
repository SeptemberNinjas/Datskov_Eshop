using Eshop.Core;
using Eshop.Menu.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu
{
    internal class OrdersPage : MenuPage
    {
        public Order[] Orders { get; set; } = [];
        public OrdersPage(Dictionary<int, IMenuCommand> commands) : base(commands)
        {
            commands.Add(1, ServiceProvider.GetRequiredService<OrderPayCommand>());
            commands.Add(0, ServiceProvider.GetRequiredService<BackCommand>());
        }
        public override void DrawPage()
        {
            Console.WriteLine("--// My orders // --");
            Console.WriteLine("----------------------------------------------------------");

            foreach (Order order in Orders)
            {
                Console.WriteLine("Number: " + order.Number);
                Console.WriteLine("Status: " + order.Status);
                Console.WriteLine("Count:  " + order.Count);
                Console.WriteLine("Amount: " + order.TotalAmount);
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("You have {0} orders", Orders.Length);
            Console.WriteLine();

            DrawCommandInterface();
        }
    }
}
