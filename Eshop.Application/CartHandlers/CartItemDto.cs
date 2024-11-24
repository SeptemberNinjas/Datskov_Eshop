using Eshop.Application.SaleItemHandlers;
using Eshop.Core;

namespace Eshop.Application.CartHandlers
{
    public record CartItemDto
    {
        public SaleItemDto SaleItem { get; init; }

        public decimal Price { get => SaleItem.Price; }
        public uint Count { get; init; }
        public decimal Amount { get => (decimal)Count * Price; init{ } }

        public CartItemDto(SaleItem saleItem, uint count, decimal amount)
        {
            SaleItem = new(saleItem.Type, saleItem.Id, saleItem.Name, saleItem.Description, saleItem.Price, (saleItem as Product)?.Stock);
            Count = count;
            Amount = amount;
        }
    }
}
