﻿using Eshop.Core;
using Eshop.Menu.Commands;
using System.Text;

namespace Eshop.Menu
{
    internal class CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands) : MenuPage(previosPage, commands)
    {
        public static int ProdQty { get; set; } = 5;
        public int PageNum { get; set; }
        public Type ProductType { get; } = typeof(Product);

        private readonly string _title = string.Empty;

        public Product[] Products = [];
        public Service[] Services = [];

        public CatalogPage(MenuPage? previosPage, Dictionary<int, IMenuCommand> commands, Type productType, int pageNum = 1) : this(previosPage, commands)
        {
            commands.Clear();
            commands.Add(1, new PreviosProductsCommand());
            commands.Add(2, new NextProductsCommand());
            commands.Add(3, new AddToCartCommand());
            commands.Add(4, new ShowCartCommand());
            commands.Add(9, new SetQtyDisplayedCommand());
            commands.Add(0, new BackCommand());

            PageNum = pageNum;
            ProductType = productType;

            if (ProductType == typeof(Product))
            {
                _title = "--// Products //--";
            }
            else
            {
                _title = "--// Services //--";
            }
        }

        public override void DrawPage()
        {
            Console.WriteLine(_title + "                 Cart({0})", ApplicationContext.Cart.Count);

            var firstIndex = ProdQty * (PageNum - 1);

            List<Dictionary<string, string>> productsForDraw = [];

            if (ProductType == typeof(Product))
            {
                productsForDraw = [];
                for (int i = firstIndex; i < Products.Length && i < firstIndex + ProdQty; i++)
                {
                    Products[i].Deconstruct(out Dictionary<string, string> descriptionData);
                    productsForDraw.Add(descriptionData);
                }

            }
            else if (ProductType == typeof(Service))
            {
                for (int i = firstIndex; i < Services.Length && i < firstIndex + ProdQty; i++)
                {
                    Services[i].Deconstruct(out Dictionary<string, string> descriptionData);
                    productsForDraw.Add(descriptionData);
                }
            }

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

            var attributeLength = new Dictionary<string, int>
                {
                    { "Id", productsForDraw.Max(x => x["Id"].Length) },
                    { "Name", productsForDraw.Max(x => x["Name"].Length) },
                    { "Price", productsForDraw.Max(x => x["Price"].Length) },
                    { "Description", productsForDraw.Max(x => x["Description"].Length) }
                };

            DrawCatalogHeader(attributeLength);
            foreach (var prod in productsForDraw)
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
    }
}
