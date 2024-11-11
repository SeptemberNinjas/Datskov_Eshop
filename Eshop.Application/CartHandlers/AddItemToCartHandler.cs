using Eshop.Core;
using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application.CartHandlers
{
    public class AddItemToCartHandler
    {
        private readonly RepositoryFactory _repositoryFactory;
        public AddItemToCartHandler(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Result> AddToCartAsync(int saleItemId, uint count = default, CancellationToken ct = default)
        {
            try
            {
                var cartRepository = _repositoryFactory.CartRepository();
                var saleItemRepository = _repositoryFactory.SaleItemRepository();

                var carts = await cartRepository.GetAllAsync(ct);
                var cart = carts.FirstOrDefault() ?? new Cart();

                var saleItem = await saleItemRepository.GetByIdAsync(saleItemId, ct);

                if (saleItem is Product product)
                    cart.Add(product, count);
                else if (saleItem is Service service)
                    cart.Add(service);
                else
                    throw new($"Ид {saleItemId} не найден!");

                await cartRepository.SaveAsync(cart, ct);

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
