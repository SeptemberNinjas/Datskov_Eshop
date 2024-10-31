namespace Eshop.Core
{
    public class OrderItem
    {
        public int SaleItemId { get; set; }
        public decimal Price { get; set; }
        public uint Count { get; set; }
        public decimal Amount { get => Price * (decimal)Count; }
    }
}
