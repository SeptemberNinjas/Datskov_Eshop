using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand : IMenuCommand
    {
        public string Description { get; } = "Add product to cart";

        public void Execute(ApplicationContext app)
        {
            string? infoMessage = null;
            
            var currentPage = app.CurrentPage;
            currentPage.GetUserInput("Input product ID", out int saleItemId);

            if (app.ProductManager.GetById(saleItemId) is Product product)
                app.Cart.Add(product, 1);
            else if (app.ServiceManager.GetById(saleItemId) is Service service)
                app.Cart.Add(service);
            else
                infoMessage = $"Id {saleItemId} not found!";

            currentPage.InfoMessage = infoMessage ?? "Successfully added!";
        }
    }
}
