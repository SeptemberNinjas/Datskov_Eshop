using Eshop.DataAccess;
using FluentResults;

namespace Eshop.Application.CartHandlers
{
    public class ClearCartHandler
    {
        private readonly RepositoryFactory _repositoryFactory;
        public ClearCartHandler(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Result> ClearCartAsync(CancellationToken ct = default)
        {
            try
            {
                var cartRepository = _repositoryFactory.CartRepository();
                await cartRepository.SaveAsync(new(), ct);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось очистить корзину")
                    .WithError(ex.Message);
            }
        }
    }
}
