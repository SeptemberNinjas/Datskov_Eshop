using Eshop.Core;
using FluentResults;

namespace Eshop.Application.SaleItemHandlers
{
    public class GetSaleItemHandler
    {
        private readonly IRepository<SaleItem> _saleItemRepository;

        public GetSaleItemHandler(IRepository<SaleItem> saleItemRepository)
        {
            _saleItemRepository = saleItemRepository;
        }

        public async Task<Result<IEnumerable<SaleItemDto>>> GetAllAsync(SaleItemType itemType, CancellationToken ct = default)
        {
            try
            {
                var requestedItems = (await _saleItemRepository

                    .GetAllAsync(ct))
                    .Where(i => i.Type == itemType);

                return Result.Ok(requestedItems
                    .Select(i => new SaleItemDto(i.Type, i.Id, i.Name, i.Description, i.Price, (i as Product)?.Stock)));
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось получить коллекцию торговых единиц")
                    .WithError(ex.Message)
                    .WithError(ex.StackTrace);
            }
        }

        public async Task<Result<SaleItemDto>> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                var requestedItem = await _saleItemRepository.GetByIdAsync(id, ct);
                if (requestedItem != null)
                    return Result.Ok(new SaleItemDto(requestedItem.Type, requestedItem.Id, requestedItem.Name, requestedItem.Description, requestedItem.Price, (requestedItem as Product)?.Stock));
                else
                    return Result.Fail("Не удалось получить торговую единицу");
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось получить торговую единицу")
                    .WithError(ex.Message)
                    .WithError(ex.StackTrace);
            }
        }
    }
}
