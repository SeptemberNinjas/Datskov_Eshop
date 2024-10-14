namespace Eshop.Core
{
    public class OrderItem(CartItem cartItem)
    {
        public Product? Product { get; } = cartItem.Product;
        public Service? Service { get; } = cartItem.Service;
        public decimal Price { get; } = cartItem.Price;
        public uint Count { get; } = cartItem.Count;
        public decimal Amount { get ; } = cartItem.Amount;
    }
}
