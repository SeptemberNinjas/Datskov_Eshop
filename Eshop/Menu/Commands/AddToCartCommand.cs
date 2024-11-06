using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand(
        ApplicationContext context,
        IRepository<Product> productRepository,
        IRepository<Service> serviceRepository,
        Cart cart) : IMenuCommand
    {
        public string Description { get; } = "Add product to cart";

        public void Execute() => ExecuteAsync().Wait();
        
        public async Task ExecuteAsync() 
        {
            string? infoMessage = null;

            var currentPage = context.CurrentPage;
            currentPage.GetUserInput("Input product ID", out int saleItemId);

            if (await productRepository.GetByIdAsync(saleItemId) is Product product)
                cart.Add(product, 1);
            else if (await serviceRepository.GetByIdAsync(saleItemId) is Service service)
                cart.Add(service);
            else
                infoMessage = $"Id {saleItemId} not found!";

            currentPage.InfoMessage = infoMessage ?? "Successfully added!";
        }
    }
}
