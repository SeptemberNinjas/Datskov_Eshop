using Eshop.Core;
using Eshop.Menu.Commands;

namespace Eshop.Menu
{
    internal class CartPage : MenuPage
    {
        public Cart Cart { get; set; } = new();
        public CartPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands) : base(previosPage, commands)
        {
            commands.Clear();
            commands.Add(1, new CreateOrderCommand());
            commands.Add(5, new ShowOrdersCommand());
            commands.Add(10, new ClearCartCommand());
            commands.Add(0, new BackCommand());
        }
        public override void DrawPage()
        {
            Console.WriteLine("--// Cart // --");
            Console.WriteLine("----------------------------------------------------------");

            foreach (CartItem cartItem in Cart.Items)
            {
                Console.WriteLine("Name:   " + cartItem.Product?.Name + cartItem.Service?.Name);
                Console.WriteLine("Price:  " + cartItem.Price);
                Console.WriteLine("Count:  " + cartItem.Count);
                Console.WriteLine("Amount: " + cartItem.Amount);
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("{0} positions", Cart.Count);
            Console.WriteLine("Total amount : {0} RUB", Cart.TotalAmount);
            Console.WriteLine();

            DrawCommandInterface();
        }
    }
}
