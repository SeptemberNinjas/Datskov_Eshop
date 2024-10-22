namespace Eshop.Core
{
    public class OrderItem
    {
        public Product? Product { get; set; }
        public Service? Service { get; set; }
        public decimal Price { get; set; }
        public uint Count { get; set; }
        public decimal Amount { get; set; }
    }
}
