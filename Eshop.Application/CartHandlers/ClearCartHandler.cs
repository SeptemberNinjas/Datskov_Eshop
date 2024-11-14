using Eshop.Core;
using FluentResults;

namespace Eshop.Application.CartHandlers
{
    public class ClearCartHandler
    {
        private readonly IRepository<Cart> _cartRepository;
        public ClearCartHandler(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> ClearCartAsync(CancellationToken ct = default)
        {
            try
            {
                await _cartRepository.SaveAsync(new(), ct);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось очистить корзину")
                    .WithError(ex.Message);
            }
        }
    }
}
