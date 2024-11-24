using Eshop.Application.SaleItemHandlers;
using Eshop.Core;

namespace Eshop.Menu.Commands
{
    internal class ShowCatalogCommand<T> : IMenuCommand where T : SaleItem
    {
        private readonly GetSaleItemHandler _getSaleItemHandler;
        private readonly ApplicationContext _context;

        public ShowCatalogCommand(ApplicationContext context, GetSaleItemHandler getSaleItemHandler) 
        { 
            _getSaleItemHandler = getSaleItemHandler;
            _context = context;
        }

        public string Description { get; } = typeof(T) == typeof(Product) ? "Products" : "Services";

        public void Execute() => ExecuteAsync().Wait();

        public async Task ExecuteAsync(CancellationToken ct = default)
        {
            SaleItemType itemType = typeof(T) == typeof(Product) ? SaleItemType.Product : SaleItemType.Service;

            var SaleItems = await _getSaleItemHandler.GetAllAsync(itemType, ct);

            if (SaleItems.IsSuccess)
            {
                _context.CurrentPage = new CatalogPage([], typeof(T))
                {
                    SaleItems = SaleItems?.Value.ToArray() ?? []
                }; 
            }
        }
    }
}
