namespace Eshop.Core
{
    public class Cart
    {
        public List<CartItem<SaleItem>> Items { get; } = [];
        public uint Count { get => (uint)Items.Sum(item => item.Count); }
        public decimal TotalAmount { get => Items.Sum(item => item.Amount); }
        public string Add(Product product, uint count)
        {
            CartItem<SaleItem>? cartItem = Items.Find(value => value.SaleItem == product);
            if (cartItem == null)
            {
                cartItem = new(product, count);
                Items.Add(cartItem);
            }
            else
                cartItem.Count += count;

            return "Product successfully added";
        }
        public string Add(Service service)
        {
            CartItem<SaleItem>? cartItem = Items.Find(value => value.SaleItem == service);
            if (cartItem == null)
            {
                cartItem = new(service);
                Items.Add(cartItem);
            }

            return "Service successfully added";
        }
        public void Clear()
        {
            Items.Clear();
        }
    }
}
