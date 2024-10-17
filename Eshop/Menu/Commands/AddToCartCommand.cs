using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand : IMenuCommand
    {
        public string Description { get; } = "Add product to cart";

        public void Execute(ApplicationContext app)
        {
            Product? product = null;
            Service? service = null;

            var currentPage = app.CurrentPage;

            currentPage.GetUserInput("Input product ID", out int prodId);

            if (currentPage is CatalogPage catPage)
            {
                if (catPage.SaleItemType == typeof(Product))
                {
                    product = app.GetProductByID(prodId);
                    if (product is not null)
                        app.Cart.Add(product, 1);
                }
                else if (catPage.SaleItemType == typeof(Service))
                {
                    service = app.GetServiceByID(prodId);
                    if (service is not null)
                        app.Cart.Add(service);
                }
            }
            if (product is null && service is null)
                currentPage.InfoMessage = $"Id {prodId} not found!";
            else
                currentPage.InfoMessage = "Successfully added!";
        }
    }
}
