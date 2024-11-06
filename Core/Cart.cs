namespace Eshop.Core
{
    public class Cart
    {
        public delegate void CartChangeHandler();
        public event CartChangeHandler? CartChangeNotyfy;

        public List<CartItem> Items { get; set; } = [];
        public uint Count { get => (uint)Items.Sum(item => item.Count); }
        public decimal TotalAmount { get => Items.Sum(item => item.Amount); }

        public string Add(Product product, uint count)
        {
            CartItem? cartItem = Items.FirstOrDefault(value => value.Product?.Id == product.Id);
            if (cartItem == null)
            {
                cartItem = new(product, count);
                Items.Add(cartItem);
            }
            else
                cartItem.Count += count;

            CartChangeNotyfy?.Invoke();

            return "Product successfully added";
        }
        public string Add(Service service)
        {
            CartItem? cartItem = Items.FirstOrDefault(value => value.Service?.Id == service.Id);
            if (cartItem == null)
            {
                cartItem = new(service);
                Items.Add(cartItem);
            }

            CartChangeNotyfy?.Invoke();

            return "Service successfully added";
        }

        public void Clear()
        {
            Items.Clear();
            CartChangeNotyfy?.Invoke();
        }
    }
}
