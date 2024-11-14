using Eshop.Core;
using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application.CartHandlers
{
    public class GetCartHandler
    {
        private readonly RepositoryFactory _repositoryFactory;

        public GetCartHandler(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Result<CartDto>> GetAsync(CancellationToken ct = default)
        {
            var repository = _repositoryFactory.CartRepository();

            try
            {
                var carts = await repository.GetAllAsync(ct);
                var cart = carts.FirstOrDefault() ?? new Cart();

                var cartItems = new List<CartItemDto>();

                foreach (var cartItem in cart.Items)
                {
                    SaleItem saleItem;
                    if (cartItem.Product is not null)
                        saleItem = (SaleItem)cartItem.Product;
                    else if (cartItem.Service is not null)
                        saleItem = (SaleItem)cartItem.Service;
                    else
                        return Result.Fail("Не удалось получить торговую единицу");

                    cartItems.Add(new(saleItem, cartItem.Count, cartItem.Amount));
                }

                return Result.Ok(new CartDto(cartItems));
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось получить корзину")
                    .WithError(ex.Message)
                    .WithError(ex.StackTrace);
            }
        }
    }
}
