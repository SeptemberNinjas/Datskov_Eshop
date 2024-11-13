using Eshop.Application.CartHandlers;
using Eshop.Core;
using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application.OrderHandlers
{
    public class CreateOrderFromCartHandler
    {
        private readonly RepositoryFactory _repositoryFactory;
        private readonly GetCartHandler _getCartHandler;
        public CreateOrderFromCartHandler(RepositoryFactory repositoryFactory, GetCartHandler getCartHandler)
        {
            _repositoryFactory = repositoryFactory;
            _getCartHandler = getCartHandler;
        }

        public async Task<Result<Order>> CreateOrderAsync(CancellationToken ct = default)
        {
            var cartGetResult = await _getCartHandler.GetAsync(ct);
            if (cartGetResult.IsFailed)
                return cartGetResult.ToResult();

            if(cartGetResult.Value.Items.Count == 0)
                return Result.Fail("Корзина пуста");
                
            var cart = cartGetResult.Value;

            var newOrderNo = await GetNewOrderNumberAsync(ct);
            if (newOrderNo.IsFailed)
                return newOrderNo.ToResult();

            var order = new Order(newOrderNo.Value);
            foreach (var cartItem in cart.Items)
            {
                var orderLine = order.Add();
                orderLine.SaleItemId = cartItem.SaleItem.Id;
                orderLine.Price = cartItem.Price;
                orderLine.Count = cartItem.Count;
            }

            try
            {
                await _repositoryFactory.OrderRepository().SaveAsync(order, ct);
                return Result.Ok(order);
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось создать заказ")
                    .WithError(ex.Message);
            }
        }
        private async Task<Result<int>> GetNewOrderNumberAsync(CancellationToken ct = default)
        {
            try
            {
                var orders = await _repositoryFactory.OrderRepository().GetAllAsync(ct);
                var last = orders.MaxBy(x => x.Id)?.Id ?? 0;

                return Result.Ok(++last);
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось получить номер нового заказа")
                    .WithError(ex.Message);
            }
        }
    }
}
