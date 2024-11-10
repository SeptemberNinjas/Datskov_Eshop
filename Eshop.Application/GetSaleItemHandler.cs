using Eshop.Core;
using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application
{
    public class GetSaleItemHandler
    {
        private readonly RepositoryFactory _repositoryFactory;

        public GetSaleItemHandler(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        //public async Task<Result<IEnumerable<SaleItemDto>>> GetItemsAsync(SaleItemType itemType)
        //{
        //    var repository = _repositoryFactory.SaleItemRepository();

        //    try
        //    {
        //        var items = (await repository
        //            .GetAllAsync())
        //            .Where(i => i.Type == itemType);

        //        var requestedItems = count is null or <= 0
        //            ? items
        //            : items.Take(count.Value);

        //        return Result.Ok(requestedItems
        //            .Select(i => new SaleItemDto(i.Type, i.Id, i.Name, i.Price, (i as Product)?.Stock)));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail("Не удалось получить коллекцию торговых единиц")
        //            .WithError(ex.Message)
        //            .WithError(ex.StackTrace);
        //    }
        //}
    }
}
