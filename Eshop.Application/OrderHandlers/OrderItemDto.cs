namespace Eshop.Application.OrderHandlers
{
    public record OrderItemDto
    {
        public int SaleItemId { get; init; }
        public decimal Price { get; init; }
        public uint Count { get; init; }
        public decimal Amount { get => Price * (decimal)Count; }
    
        public OrderItemDto(int saleItemId, decimal price, uint count)
        {
            SaleItemId = saleItemId;
            Price = price;
            Count = count;
        }
    }
}
