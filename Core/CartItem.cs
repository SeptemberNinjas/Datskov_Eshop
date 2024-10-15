namespace Eshop.Core
{
    public class CartItem<T> where T : SaleItem
    {
        public T SaleItem { get; }

        public decimal Price { get => SaleItem.Price; }
        public uint Count { get; set; }
        public decimal Amount { get => (decimal)Count * Price; }

        public CartItem(T product, uint count = 1)
        {
            SaleItem = product;
            Count = count;
        }
    }
}
