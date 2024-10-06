using Eshop.Menu.Commands;
using Core;

namespace Eshop.Menu
{
    internal class CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands, int PageNum = 0) : MenuPage(previosPage, commands)
    {
        static public int ProdQty { get; set; } = 5;
        public int PageNum { get; set; } = PageNum;
        Product[] Products = [];
        
        public override void DrawPage()
        {
            commands.Add(1, new PreviosProductsCommand());
            commands.Add(2, new NextProductsCommand());
            commands.Add(9, new SetQtyDisplayedCommand());
            commands.Add(0, new BackCommand());

            Products



            Console.Clear();
            
            Console.WriteLine("Content");
            DrawCommandInterface();
        }
    }
}
