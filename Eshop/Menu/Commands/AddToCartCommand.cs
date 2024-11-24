using Eshop.Application.CartHandlers;

namespace Eshop.Menu.Commands
{
    internal class AddToCartCommand : IMenuCommand
    {
        private readonly ApplicationContext _context;
        private readonly AddItemToCartHandler _addItemToCartHandler;
        
        public AddToCartCommand(ApplicationContext context, AddItemToCartHandler addSaleItemToCartHandler)
        {
            _context = context;
            _addItemToCartHandler = addSaleItemToCartHandler;
        }
        public string Description { get; } = "Add product to cart";

        public void Execute() => ExecuteAsync().Wait();

        public async Task ExecuteAsync(CancellationToken ct = default)
        {
            var currentPage = _context.CurrentPage;
            currentPage.GetUserInput("Input product ID", out int saleItemId);

            var result = await _addItemToCartHandler.AddToCartAsync(saleItemId, 1, ct);

            currentPage.InfoMessage = result.IsSuccess ? "Successfully added!": result.ToString();
        }
    }
}
