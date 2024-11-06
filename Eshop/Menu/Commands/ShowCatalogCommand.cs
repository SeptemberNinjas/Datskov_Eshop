using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand<T>(ApplicationContext context, IRepository<T> saleItemRepository) : IMenuCommand where T : SaleItem
    {
        public string Description { get; } = typeof(T) == typeof(Product) ? "Products" : "Services";

        public void Execute() => ExecuteAsync().Wait();
        
        public async Task ExecuteAsync(CancellationToken ct = default)
        {
            context.CurrentPage = new CatalogPage([], typeof(T))
            {
                SaleItems = [.. await saleItemRepository.GetAllAsync(ct)]
            };
        }
    }
}
