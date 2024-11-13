namespace Eshop.Application.OrderHandlers
{
    public record OrderItemDto
    {
        public int SaleItemId { get; init; }
        public decimal Price { get; init; }
        public uint Count { get; init; }
        public decimal Amount { get => (decimal)Count * Price; }

        public OrderItemDto(int saleItemId, uint count, decimal price)
        {
            SaleItemId = saleItemId;
            Count = count;
            Price = price;
        }
    }
}
