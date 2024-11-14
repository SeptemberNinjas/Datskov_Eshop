using Eshop.Core;
using FluentResults;

namespace Eshop.Application.OrderHandlers
{
    public class CreateOrderHandler
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;

        public CreateOrderHandler(IRepository<Cart> cartRepository, IRepository<Order> orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Result<int>> CreateOrderFromCartAsync(CancellationToken ct = default)
        {
            try
            {
                var carts = await _cartRepository.GetAllAsync(ct);
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

                await _orderRepository.SaveAsync(order, ct);
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
                var orders = await _orderRepository.GetAllAsync(ct);
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
