using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application.OrderHandlers
{
    public class GetOrderHandler
    {
        private readonly RepositoryFactory _repositoryFactory;

        public GetOrderHandler(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Result<IReadOnlyCollection<OrderDto>>> GetAllAsync(CancellationToken ct = default)
        {
            var repository = _repositoryFactory.OrderRepository();

            try
            {
                var orders = await repository.GetAllAsync(ct);
                var ordersDto = new List<OrderDto>();
                foreach (var order in orders)
                {
                    var orderItemDtos = new List<OrderItemDto>();
                    foreach (var item in order.Items)
                    {
                        orderItemDtos.Add(new(item.SaleItemId, item.Price, item.Count));
                    }
                    ordersDto.Add(new(order.Id, order.Status, orderItemDtos));
                }
                return Result.Ok((IReadOnlyCollection<OrderDto>)ordersDto);
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
            var ordersGetResult = await GetAllAsync(ct);

            if (ordersGetResult.IsFailed)
                return ordersGetResult.ToResult();

            return Result.Ok(ordersGetResult.Value.FirstOrDefault(x => x.Id == id));
        }
    }
}
