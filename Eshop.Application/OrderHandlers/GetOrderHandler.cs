﻿using Eshop.Core;
using FluentResults;

namespace Eshop.Application.OrderHandlers
{
    public class GetOrderHandler
    {
        private readonly IRepository<Order> _orderRepository;

        public GetOrderHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<IReadOnlyCollection<OrderDto>>> GetAllAsync(CancellationToken ct = default)
        {
            try
            {
                var orderDtos = new List<OrderDto>();

                var orders = await _orderRepository.GetAllAsync(ct);

                foreach (var order in orders) {
                    var orderItemDtos = new List<OrderItemDto>();
                    foreach (var item in order.Items) {
                        orderItemDtos.Add(new(item.SaleItemId, item.Count, item.Price));
                    }
                    orderDtos.Add(new(order.Id, order.Status, orderItemDtos));
                }
                return Result.Ok((IReadOnlyCollection<OrderDto>)orderDtos);
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось получить заказы")
                    .WithError(ex.Message)
                    .WithError(ex.StackTrace);
            }
        }

        public async Task<Result<OrderDto?>> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var result = await GetAllAsync(ct);

            if (result.IsFailed)
                return result.ToResult();

            return result.Value.FirstOrDefault(x => x.Id == id);
        }
    }
}
