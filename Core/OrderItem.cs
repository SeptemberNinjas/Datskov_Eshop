namespace Eshop.Core
{
    public class OrderItem(CartItem<SaleItem> cartItem)
    {
        public SaleItem SaleItem { get; } = cartItem.SaleItem;
        public decimal Price { get; } = cartItem.Price;
        public uint Count { get; } = cartItem.Count;
        public decimal Amount { get ; } = cartItem.Amount;
    }
}
