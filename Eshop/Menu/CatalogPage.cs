using Eshop.Application.SaleItemHandlers;
using Eshop.Core;
using Eshop.Menu.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Eshop.Menu
{
    internal class CatalogPage : MenuPage 
    {
        public static int ProdQty { get; set; } = 5;
        public int PageNum { get; set; }
        public Type SaleItemType { get; }

        private readonly string _title = string.Empty;

        public SaleItemDto[] SaleItems = [];

        public CatalogPage(Dictionary<int, IMenuCommand> commands, Type saleItemType, int pageNum = 1) : base(commands)
        {
            commands.Clear();
            commands.Add(1, ServiceProvider.GetRequiredService<PreviosProductsCommand>());
            commands.Add(2, ServiceProvider.GetRequiredService<NextProductsCommand>());
            commands.Add(3, ServiceProvider.GetRequiredService<AddToCartCommand>());
            commands.Add(4, ServiceProvider.GetRequiredService<ShowCartCommand>());
            commands.Add(9, ServiceProvider.GetRequiredService<SetQtyDisplayedCommand>());
            commands.Add(0, ServiceProvider.GetRequiredService<BackCommand>());

            PageNum = pageNum;
            SaleItemType = saleItemType;

            _title = SaleItemType == typeof(Product) ? "--// Products //--" : "--// Services //--";

        }

        public override void DrawPage()
        {
            Console.WriteLine(_title);

            var firstIndex = ProdQty * (PageNum - 1);

            List<Dictionary<string, string>> itemsForDraw = [];

            for (int i = firstIndex; i < SaleItems.Length && i < firstIndex + ProdQty; i++)
            {
                SaleItems[i].Representation(out Dictionary<string, string> descriptionData);
                itemsForDraw.Add(descriptionData);
            }

            if (itemsForDraw.Count == 0)
            {
                if (PageNum > 1)
                {
                    PageNum--;
                    Show();
                }
                //else
                    //PreviosPage?.Show();

                return;
            }

            var attributeLength = new Dictionary<string, int>
                {
                    { "Id", itemsForDraw.Max(x => x["Id"].Length) },
                    { "Name", itemsForDraw.Max(x => x["Name"].Length) },
                    { "Price", itemsForDraw.Max(x => x["Price"].Length) },
                    { "Description", itemsForDraw.Max(x => x["Description"].Length) }
                };

            DrawCatalogHeader(attributeLength);
            foreach (var prod in itemsForDraw)
                DrawProductDescription(prod["Id"], prod["Name"], prod["Price"], prod["Description"], attributeLength);

            DrawCommandInterface();
        }

        private static void DrawCatalogHeader(Dictionary<string, int> attributeLength)
        {
            DrawStringDelimiter(attributeLength);

            Console.Write("| ID " + DrawAddChar(" ", attributeLength["Id"] - 2));
            Console.Write("| Name " + DrawAddChar(" ", attributeLength["Name"] - 4));
            Console.Write("| Price " + DrawAddChar(" ", attributeLength["Price"] - 5));
            Console.Write("| Description " + DrawAddChar(" ", attributeLength["Description"] - 11));
            Console.WriteLine("|");

            DrawStringDelimiter(attributeLength);
        }

        private static void DrawStringDelimiter(Dictionary<string, int> attributeLength)
        {
            Console.Write("+--" + DrawAddChar("-", int.Max(attributeLength["Id"], 2)));
            Console.Write("+--" + DrawAddChar("-", int.Max(attributeLength["Name"], 4)));
            Console.Write("+--" + DrawAddChar("-", int.Max(attributeLength["Price"], 5)));
            Console.Write("+--" + DrawAddChar("-", int.Max(attributeLength["Description"], 11)));
            Console.WriteLine("+");
        }

        private static void DrawProductDescription(string id, string name, string price, string description, Dictionary<string, int> attributeLength)
        {
            Console.Write("| " + id + DrawAddChar(" ", int.Max(attributeLength["Id"], 2) - id.Length + 1));
            Console.Write("| " + name + DrawAddChar(" ", int.Max(attributeLength["Name"], 4) - name.Length + 1));
            Console.Write("| " + price + DrawAddChar(" ", int.Max(attributeLength["Price"], 5) - price.Length + 1));
            Console.Write("| " + description + DrawAddChar(" ", int.Max(attributeLength["Description"], 11) - description.Length + 1));
            Console.WriteLine("|");

            DrawStringDelimiter(attributeLength);
        }

        private static string DrawAddChar(string Char, int count)
        {
            StringBuilder sb = new();

            for (int i = 0; i < count; i++)
                sb.Append(Char);

            return sb.ToString();
        }

        public void Representation(SaleItemDto saleItem, out Dictionary<string, string> representationData)
        {
            representationData = [];
            representationData.Add("Id", saleItem.Id.ToString());
            representationData.Add("Name", saleItem.Name);
            representationData.Add("Price", saleItem.Price.ToString());
            representationData.Add("Description", saleItem.Description);
        }
    }
}
