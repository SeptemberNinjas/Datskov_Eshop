namespace Eshop.Core
{
    public class CartItem
    {
        public Product? Product { get; }
        public Service? Service { get; }
        public decimal Price { get => Product?.Price ?? Service?.Price ?? 0; }
        public uint Count { get; set; }
        public decimal Amount { get => (decimal)Count * Price; }

        public CartItem(Product product, uint count = 0)
        {
            Product = product;
            Count = count;
        }
        public CartItem(Service service)
        {
            Service = service;
            Count = 1;
        }
    }
}
