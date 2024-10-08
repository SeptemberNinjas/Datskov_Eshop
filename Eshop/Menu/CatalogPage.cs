using Eshop.Core;
using Eshop.Menu.Commands;

namespace Eshop.Menu
{
    internal class CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands) : MenuPage(previosPage, commands)
    {
        public static int ProdQty { get; set; } = 5;
        public int PageNum { get; set; }
        
        private readonly string _title = string.Empty;

        private readonly Product[] _goods = [];

        public CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands, Type productType, int pageNum = 1) : this(previosPage, commands)
        {
            PageNum = pageNum;

            if (productType == typeof(Product))
            {
                _goods = ApplicationContext.GetProducts();
                _title = "--// Products //--";
            }
            else
            {
                _goods = ApplicationContext.GetServices();
                _title = "--// Services //--";
            }
        }

        public override void DrawPage()
        {
            Console.Clear();

            Console.WriteLine(_title);

            var firstIndex = ProdQty * (PageNum - 1);

            DrawCatalogHeader();
            for (int i = firstIndex; i < _goods.Length && i < firstIndex + ProdQty; i++)
                DrawProductDescription(_goods[i]);

            DrawCommandInterface();
        }

        private static void DrawCatalogHeader()
        {
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  | Name / Description");
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
        }

        private static void DrawProductDescription(Product goods)
        {
            Console.WriteLine("| {0}    | {1} / {2}", goods.Id, goods.Name, goods.Description);
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
        }
    }
}
