using Eshop.Application.OrderHandlers;
using Eshop.Menu.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu
{
    internal class OrdersPage : MenuPage
    {
        public OrderDto[] Orders { get; set; } = [];
        public OrdersPage(Dictionary<int, IMenuCommand> commands) : base(commands)
        {
            //commands.Add(1, ServiceProvider.GetRequiredService<OrderPayCommand>());
            commands.Add(0, ServiceProvider.GetRequiredService<BackCommand>());
        }
        public override void DrawPage()
        {
            Console.WriteLine("--// My orders // --");
            Console.WriteLine("----------------------------------------------------------");

            foreach (var order in Orders)
            {
                Console.WriteLine("Number: " + order.Number);
                Console.WriteLine("Status: " + order.StatusRepresentation);
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
