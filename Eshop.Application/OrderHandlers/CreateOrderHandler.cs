using Eshop.Core;
using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application.OrderHandlers
{
    public class CreateOrderHandler
    {
        private readonly RepositoryFactory _repositoryFactory;

        public CreateOrderHandler(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Result<int>> CreateOrderFromCartAsync(CancellationToken ct = default)
        {
            try
            {
                var carts = await _repositoryFactory.CartRepository().GetAllAsync(ct);
                var cart = carts.FirstOrDefault() ?? new();

                if (cart.Items.Count == 0)
                    return Result.Fail("Корзина пуста!");

                var newOrderNo = await GetNewOrderNumberAsync(ct);
                if (newOrderNo.IsFailed)
                    return newOrderNo.ToResult();

                var order = new Order(newOrderNo.Value);
                foreach (var cartItem in cart.Items)
                {
                    if ((cartItem.Product as SaleItem ?? cartItem.Service) is SaleItem saleItem)
                    {
                        var orderLine = order.Add();
                        orderLine.SaleItemId = saleItem.Id;
                        orderLine.Price = cartItem.Price;
                        orderLine.Count = cartItem.Count;
                    }
                }

                await _repositoryFactory.OrderRepository().SaveAsync(order, ct);
                return Result.Ok(order.Id);
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
