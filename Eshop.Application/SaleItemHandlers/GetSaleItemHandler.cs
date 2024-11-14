using Eshop.Core;
using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application.SaleItemHandlers
{
    public class GetSaleItemHandler
    {
        private readonly RepositoryFactory _repositoryFactory;

        public GetSaleItemHandler(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Result<IEnumerable<SaleItemDto>>> GetAllAsync(SaleItemType itemType, CancellationToken ct = default)
        {
            var repository = _repositoryFactory.SaleItemRepository();

            try
            {
                var requestedItems = (await repository
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
            var repository = _repositoryFactory.SaleItemRepository();
            try
            {
                var requestedItem = await repository.GetByIdAsync(id, ct);
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
