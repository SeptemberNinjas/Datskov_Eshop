using Eshop.Application.CartHandlers;

namespace Eshop.Menu.Commands
{
    internal class ShowCartCommand : IMenuCommand
    {
        private readonly ApplicationContext _context;
        private readonly GetCartHandler _getCartHandler;
        public string Description { get; } = "Show cart";

        public ShowCartCommand(ApplicationContext context, GetCartHandler getCartHandler)
        {
            _context = context; 
            _getCartHandler = getCartHandler;
        }

        public void Execute() => ExecuteAsync().Wait();
        
        public async Task ExecuteAsync(CancellationToken ct = default)
        {
            var cartDto = await _getCartHandler.GetAsync(ct);
            if (cartDto.IsSuccess)
                _context.CurrentPage = new CartPage([]) { CartDto = cartDto.Value };
        }
    }
}
