using Eshop.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand(ApplicationContext context, IServiceProvider sp, Cart cart) : IMenuCommand
    {
        public string Description { get; } = "Add product to cart";

        public void Execute()
        {
            string? infoMessage = null;
            
            var currentPage = context.CurrentPage;
            currentPage.GetUserInput("Input product ID", out int saleItemId);

            if (sp.GetRequiredService<IRepository<Product>>().GetById(saleItemId) is Product product)
                cart.Add(product, 1);
            else if (sp.GetRequiredService<IRepository<Service>>().GetById(saleItemId) is Service service)
                cart.Add(service);
            else
                infoMessage = $"Id {saleItemId} not found!";

            currentPage.InfoMessage = infoMessage ?? "Successfully added!";
        }
    }
}
