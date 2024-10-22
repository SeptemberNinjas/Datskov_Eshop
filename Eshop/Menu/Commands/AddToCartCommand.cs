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

            var product = app.ProductManager.GetById(saleItemId);
            var service = app.ServiceManager.GetById(saleItemId);
            if (product is not null)
                app.Cart.Add(product, 1);
            else if (service is not null)
                app.Cart.Add(service);
            else
                infoMessage = $"Id {saleItemId} not found!";

            currentPage.InfoMessage = infoMessage ?? "Successfully added!";

            //if (currentPage is CatalogPage<Product> catPage)
            //{
            //    if (catPage.SaleItemType == typeof(Product))
            //    {
            //        product = app.ProductManager.GetById(prodId);
            //        if (product is not null)
            //            app.Cart.Add(product, 1);
            //    }
            //    else if (catPage.SaleItemType == typeof(Service))
            //    {
            //        service = app.ServiceManager.GetById(prodId);
            //        if (service is not null)
            //            app.Cart.Add(service);
            //    }
            //}
            //if (product is null && service is null)
            //    currentPage.InfoMessage = $"Id {prodId} not found!";
            //else
            //    currentPage.InfoMessage = "Successfully added!";
        }
    }
}
