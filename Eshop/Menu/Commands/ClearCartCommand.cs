using Eshop.Application.CartHandlers;
using FluentResults;

namespace Eshop.Menu.Commands
{
    internal class ClearCartCommand : IMenuCommand
    {
        private readonly ClearCartHandler _clearCartHandler;
        private readonly ApplicationContext _context;
        public string Description { get; } = "Clear cart";

        public ClearCartCommand(ApplicationContext context, ClearCartHandler clearCartHandler)
        {
            _clearCartHandler = clearCartHandler;
            _context = context;
        }

        public void Execute() => ExecuteAsync().Wait();

        public async Task<Result> ExecuteAsync(CancellationToken ct = default)
        {
            var res = await _clearCartHandler.ClearCartAsync(ct);
            if (res.IsSuccess && _context.CurrentPage is CartPage cartPage)
                cartPage.CartDto = new([]);

            return res;
        }
    }
}
