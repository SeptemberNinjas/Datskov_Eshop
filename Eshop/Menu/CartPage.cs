using Eshop.Core;
using Eshop.Menu.Commands;

namespace Eshop.Menu
{
    internal class CartPage : MenuPage
    {
        public CartPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands) : base(previosPage, commands)
        {
            commands.Add(1, new BackCommand()); // create order from cart

            commands.Add(9, new BackCommand()); // delete item
            commands.Add(10, new BackCommand()); // clear cart

            commands.Add(0, new BackCommand());
        }
        public override void DrawPage()
        {
            Console.Clear();

            Console.WriteLine("--// Cart // --");
            //DrawCartHeader();

            foreach (var cartItem in ApplicationContext.Cart)
            {
                Console.Write(cartItem.);
            }

            DrawCommandInterface();
        }

        //private static void DrawCartHeader(Dictionary<string, int> atribLength)
        //{
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
        //    Console.WriteLine("+");

        //    Console.Write("| ID " + DrawAddChar(" ", atribLength["Id"] - 2));
        //    Console.Write("| Name " + DrawAddChar(" ", atribLength["Name"] - 4));
        //    Console.Write("| Price " + DrawAddChar(" ", atribLength["Price"] - 5));
        //    Console.Write("| Description " + DrawAddChar(" ", atribLength["Description"] - 11));
        //    Console.WriteLine("|");

        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
        //    Console.WriteLine("+");
        //}

        //private static void DrawProductDescription(Product product, Dictionary<string, int> atribLength)
        //{
        //    Console.Write("| " + product.Id + DrawAddChar(" ", int.Max(atribLength["Id"], 2) - product.Id.ToString().Length + 1));
        //    Console.Write("| " + product.Name + DrawAddChar(" ", int.Max(atribLength["Name"], 4) - product.Name.Length + 1));
        //    Console.Write("| " + product.Price + DrawAddChar(" ", int.Max(atribLength["Price"], 5) - product.Price.ToString().Length + 1));
        //    Console.Write("| " + product.Description + DrawAddChar(" ", int.Max(atribLength["Description"], 11) - product.Description.Length + 1));
        //    Console.WriteLine("|");

        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
        //    Console.WriteLine("+");
        //}
        //private static void DrawServiceDescription(Service service, Dictionary<string, int> atribLength)
        //{
        //    Console.Write("| " + service.Id + DrawAddChar(" ", int.Max(atribLength["Id"], 2) - service.Id.ToString().Length + 1));
        //    Console.Write("| " + service.Name + DrawAddChar(" ", int.Max(atribLength["Name"], 4) - service.Name.Length + 1));
        //    Console.Write("| " + service.Price + DrawAddChar(" ", int.Max(atribLength["Price"], 5) - service.Price.ToString().Length + 1));
        //    Console.Write("| " + service.Description + DrawAddChar(" ", int.Max(atribLength["Description"], 11) - service.Description.Length + 1));
        //    Console.WriteLine("|");

        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
        //    Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
        //    Console.WriteLine("+");
        //}
        //private static string DrawAddChar(string Char, int count)
        //{
        //    string res = "";
        //    for (int i = 0; i < count; i++)
        //        res += Char;

        //    return res;
        //}
    }
}
