using Eshop.Core;
using Eshop.Menu.Commands;

namespace Eshop.Menu
{
    internal class CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands) : MenuPage(previosPage, commands)
    {
        public static int ProdQty { get; set; } = 5;
        public int PageNum { get; set; }
        public Type ProductType{ get; } = typeof(Product);

        private readonly string _title = string.Empty;

        private readonly Product[] _products = [];
        private readonly Service[] _services = [];

        public CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands, Type productType, int pageNum = 1) : this(previosPage, commands)
        {
            PageNum = pageNum;
            ProductType = productType;

            if (ProductType == typeof(Product))
            {
                _products = ApplicationContext.GetProducts();
                _title = "--// Products //--";
            }
            else
            {
                _services = ApplicationContext.GetServices();
                _title = "--// Services //--";
            }
        }

        public override void DrawPage()
        {
            Console.Clear();

            Console.WriteLine(_title);

            var firstIndex = ProdQty * (PageNum - 1);

            DrawCatalogHeader();
            
            if (ProductType == typeof(Product)) 
                for (int i = firstIndex; i < _products.Length && i < firstIndex + ProdQty; i++)
                    DrawProductDescription(_products[i]);

            if (ProductType == typeof(Service)) 
                for (int i = firstIndex; i < _services.Length && i < firstIndex + ProdQty; i++)
                    DrawServiceDescription(_services[i]);

            DrawCommandInterface();
        }

        private static void DrawCatalogHeader()
        {
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  | Name / Description");
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
        }

        private static void DrawProductDescription(Product product)
        {
            Console.WriteLine("| {0}    | {1} / {2}", product.Id, product.Name, product.Description);
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
        }
        private static void DrawServiceDescription(Service service)
        {
            Console.WriteLine("| {0}    | {1} / {2}", service.Id, service.Name, service.Description);
            Console.WriteLine("+------+----------------------------------------------------------------------------------");
        }
    }
}
