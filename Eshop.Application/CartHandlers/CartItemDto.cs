using Eshop.Core;

namespace Eshop.Application.CartHandlers
{
    public record CartItemDto
    {
        public SaleItem SaleItem { get; init; }

        public decimal Price { get => SaleItem.Price; }
        public uint Count { get; init; }
        public decimal Amount { get => (decimal)Count * Price; init{ } }

        public CartItemDto(SaleItem saleItem, uint count, decimal amount)
        {
            SaleItem = saleItem;
            Count = count;
            Amount = amount;
        }
    }
}
