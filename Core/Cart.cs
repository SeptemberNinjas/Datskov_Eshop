namespace Eshop.Core
{
    public class Cart
    {
        public List<CartItem> Items { get; } = [];
        public uint Count { get => (uint)Items.Sum(item => item.Count); }
        public decimal TotalAmount { get => Items.Sum(item => item.Amount); }
        public string Add(Product product, uint count)
        {
            CartItem? cartItem = Items.Find(value => value.Product == product);
            if (cartItem == null)
            {
                cartItem ??= new(product);
                Items.Add(cartItem);
            }
            cartItem.Count += count;

            return "Product successfully added";
        }
        public string Add(Service service)
        {
            CartItem? cartItem = Items.Find(value => value.Service == service);
            if (cartItem == null)
            {
                cartItem ??= new(service);
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
