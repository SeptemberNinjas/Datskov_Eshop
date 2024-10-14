using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand : IMenuCommand
    {
        public string Description { get; } = "Add product to cart";

        public void Execute(MenuPage currentPage)
        {
            Product? product = null;
            Service? service = null;

            currentPage.GetUserInput("Input product ID", out int prodId);

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
            if (product is null && service is null)
                currentPage.InfoMessage = $"Id {prodId} not found!";

            currentPage.Show();
        }
    }
}
