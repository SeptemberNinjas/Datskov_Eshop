using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand : IMenuCommand
    {
        public string Description { get; } = "Add product to cart";

        public void Execute()
        {
            Product? product = null;
            Service? service = null;

            var currentPage = Program.Context.CurrentPage;

            currentPage.GetUserInput("Input product ID", out int prodId);

            if (currentPage is CatalogPage catPage)
            {
                if (catPage.SaleItemType == typeof(Product))
                {
                    product = ApplicationContext.GetProductByID(prodId);
                    if (product is not null)
                        Program.Context.Cart.Add(product, 1);
                }
                else if (catPage.SaleItemType == typeof(Service))
                {
                    service = ApplicationContext.GetServiceByID(prodId);
                    if (service is not null)
                        Program.Context.Cart.Add(service);
                }
            }
            if (product is null && service is null)
                currentPage.InfoMessage = $"Id {prodId} not found!";
            else
                currentPage.InfoMessage = "Successfully added!";
        }
    }
}
