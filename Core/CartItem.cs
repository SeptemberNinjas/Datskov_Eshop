namespace Eshop.Core
{
    class CartItem
    {
        public Product Product { get; }
        public decimal Price { get => Product.Price; }
        public uint Count { get; set; }
        public decimal Amount { get => (decimal)Count * Price; }

        public CartItem(Product product, uint count = 0)
        {
            Product = product;
            Count = count;
        }
    }
}
