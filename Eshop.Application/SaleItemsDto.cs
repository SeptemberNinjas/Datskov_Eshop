using Eshop.Core;

namespace Eshop.Application
{
    public record SaleItemDto(SaleItemType ItemType, int Id, string Name, decimal Price, decimal? Stock = null);
}
