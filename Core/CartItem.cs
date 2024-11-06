using System.Text.Json.Serialization;

namespace Eshop.Core
{
    public class CartItem
    {
        public Product? Product { get; private set; }

        public Service? Service { get; private set; }

        public decimal Price { get => Product?.Price ?? Service?.Price ?? 0; }
        public uint Count { get; set; }
        public decimal Amount { get => (decimal)Count * Price; }

        [JsonConstructor]
        private CartItem(Product? product, Service? service, uint count = 1)
        {
            Product = product;
            Service = service;
            Count = count;
        }

        public CartItem(Product product, uint count = 1)
        {
            Product = product;
            Count = count;
        }
        public CartItem(Service service, uint count = 1)
        {
            Service = service;
            Count = count;
        }
    }
}
