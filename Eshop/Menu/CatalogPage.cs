using Eshop.Core;
using Eshop.Menu.Commands;

namespace Eshop.Menu
{
    internal class CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands) : MenuPage(previosPage, commands)
    {
        public static int ProdQty { get; set; } = 5;
        public int PageNum { get; set; }
        public Type ProductType { get; } = typeof(Product);

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
            Console.WriteLine(_title + "                 Cart({0})", ApplicationContext.Cart.Count);

            var firstIndex = ProdQty * (PageNum - 1);

            if (ProductType == typeof(Product))
            {
                var productsForDraw = new List<Product>();
                for (int i = firstIndex; i < _products.Length && i < firstIndex + ProdQty; i++)
                    productsForDraw.Add(_products[i]);

                if (productsForDraw.Count == 0)
                {
                    if (PageNum > 1)
                    {
                        PageNum--;
                        Show();
                    }
                    else
                        PreviosPage?.Show();

                    return;
                }

                var atribLength = new Dictionary<string, int>
                {
                    { "Id", productsForDraw.Max(x => x.Id.ToString().Length) },
                    { "Name", productsForDraw.Max(x => x.Name.Length) },
                    { "Price", productsForDraw.Max(x => x.Price.ToString().Length) },
                    { "Description", productsForDraw.Max(x => x.Description.ToString().Length) }
                };

                DrawCatalogHeader(atribLength);
                foreach (var prod in productsForDraw)
                    DrawProductDescription(prod, atribLength);
            }

            else if (ProductType == typeof(Service))
            {
                var productsForDraw = new List<Service>();
                for (int i = firstIndex; i < _services.Length && i < firstIndex + ProdQty; i++)
                    productsForDraw.Add(_services[i]);
                
                if (productsForDraw.Count == 0)
                {
                    if (PageNum > 1)
                    {
                        PageNum--;
                        Show();
                    }else 
                        PreviosPage?.Show();
                    
                    return;
                }
                
                var atribLength = new Dictionary<string, int>
                {
                    { "Id", productsForDraw.Max(x => x.Id.ToString().Length) },
                    { "Name", productsForDraw.Max(x => x.Name.Length) },
                    { "Price", productsForDraw.Max(x => x.Price.ToString().Length) },
                    { "Description", productsForDraw.Max(x => x.Description.ToString().Length) }
                };

                DrawCatalogHeader(atribLength);
                foreach (var serv in productsForDraw)
                    DrawServiceDescription(serv, atribLength);
            }

            DrawCommandInterface();
        }

        private static void DrawCatalogHeader(Dictionary<string, int> atribLength)
        {
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
            Console.WriteLine("+");

            Console.Write("| ID " + DrawAddChar(" ", atribLength["Id"] - 2));
            Console.Write("| Name " + DrawAddChar(" ", atribLength["Name"] - 4));
            Console.Write("| Price " + DrawAddChar(" ", atribLength["Price"] - 5));
            Console.Write("| Description " + DrawAddChar(" ", atribLength["Description"] - 11));
            Console.WriteLine("|");

            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
            Console.WriteLine("+");
        }

        private static void DrawProductDescription(Product product, Dictionary<string, int> atribLength)
        {
            Console.Write("| " + product.Id + DrawAddChar(" ", int.Max(atribLength["Id"], 2) - product.Id.ToString().Length + 1));
            Console.Write("| " + product.Name + DrawAddChar(" ", int.Max(atribLength["Name"], 4) - product.Name.Length + 1));
            Console.Write("| " + product.Price + DrawAddChar(" ", int.Max(atribLength["Price"], 5) - product.Price.ToString().Length + 1));
            Console.Write("| " + product.Description + DrawAddChar(" ", int.Max(atribLength["Description"], 11) - product.Description.Length + 1));
            Console.WriteLine("|");

            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
            Console.WriteLine("+");
        }
        private static void DrawServiceDescription(Service service, Dictionary<string, int> atribLength)
        {
            Console.Write("| " + service.Id + DrawAddChar(" ", int.Max(atribLength["Id"], 2) - service.Id.ToString().Length + 1));
            Console.Write("| " + service.Name + DrawAddChar(" ", int.Max(atribLength["Name"], 4) - service.Name.Length + 1));
            Console.Write("| " + service.Price + DrawAddChar(" ", int.Max(atribLength["Price"], 5) - service.Price.ToString().Length + 1));
            Console.Write("| " + service.Description + DrawAddChar(" ", int.Max(atribLength["Description"], 11) - service.Description.Length + 1));
            Console.WriteLine("|");

            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Id"], 2)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Name"], 4)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Price"], 5)));
            Console.Write("+--" + DrawAddChar("-", int.Max(atribLength["Description"], 11)));
            Console.WriteLine("+");
        }
        private static string DrawAddChar(string Char, int count)
        {
            string res = "";
            for (int i = 0; i < count; i++)
                res += Char;

            return res;
        }
    }
}
