using Eshop.Menu.Commands;
using Core;

namespace Eshop.Menu
{
    internal class CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands, Type productType, int PageNum = 1) : MenuPage(previosPage, commands)
    {
        static public int ProdQty { get; set; } = 5;
        public int PageNum { get; set; } = PageNum;
        IGoods[] Products = [];
        
        public override void DrawPage()
        {
            Console.Clear();

            if (productType == typeof(Product))
                Products = Product.Get();
            else
                Products = Service.Get();

            var firstIndex = ProdQty * (PageNum - 1);

            DrawCatalogHeader();
            for (int i = firstIndex; i < Products.Length && i < firstIndex + ProdQty; i++) 
                DrawProductDescription(Products[i]);
            
            DrawCommandInterface();
        }

        private static void DrawCatalogHeader()
        {
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  | Name / Description");
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
        }

        private static void DrawProductDescription(IGoods goods)
        {
            Console.WriteLine("| {0}    | {1} / {2}", goods.Id, goods.Name, goods.Description);
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
        }
    }
}
