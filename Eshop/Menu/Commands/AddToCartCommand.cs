using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand : IMenuCommand
    {
        public string Description { get; } = "Add product to cart";

        public void Execute(MenuPage currentPage)
        {
            Product? product;
            Service? service;

            int prodId;
            {
                string? input;
                do
                {
                    Console.WriteLine("Input product ID");
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out prodId) || prodId == 0);
            }

            if (currentPage is CatalogPage catPage)
            {
                if (catPage.ProductType == typeof(Product))
                {
                    product = ApplicationContext.GetProductByID(prodId);
                    if (product is not null)
                        ApplicationContext.Cart.Add(product, 1);
                }
                else if (catPage.ProductType == typeof(Service))
                {
                    service = ApplicationContext.GetServiceByID(prodId);
                    if (service is not null)
                        ApplicationContext.Cart.Add(service);
                }
            }

            currentPage.Show();
        }
    }
}
