using Eshop.Core;
using FluentResults;

namespace Eshop.Application.CartHandlers
{
    public class AddItemToCartHandler
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<SaleItem> _saleItemRepository;

        public AddItemToCartHandler(IRepository<Cart> cartRepository, IRepository<SaleItem> saleItemRepository)
        {
            _saleItemRepository = saleItemRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Result> AddToCartAsync(int saleItemId, uint count = default, CancellationToken ct = default)
        {
            try
            {
                var carts = await _cartRepository.GetAllAsync(ct);
                var cart = carts.FirstOrDefault() ?? new Cart();

                var saleItem = await _saleItemRepository.GetByIdAsync(saleItemId, ct);

                if (saleItem is Product product)
                    cart.Add(product, count);
                else if (saleItem is Service service)
                    cart.Add(service);
                else
                    return Result.Fail($"Ид {saleItemId} не найден!");

                await _cartRepository.SaveAsync(cart, ct);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось добавить в корзину")
                    .WithError(ex.Message);
            }
        }
    }
}
