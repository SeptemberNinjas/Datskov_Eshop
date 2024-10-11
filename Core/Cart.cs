using System.Collections;

namespace Eshop.Core
{
    public class Cart : IEnumerable
    {
        public List<CartItem> Items = [];
        public uint Count
        {
            get
            {
                uint count = 0;
                Items.ForEach(item => count += item.Count);
                return count;
            }
        }
        public decimal TotalAmount
        {
            get
            {
                decimal sum = 0.0M;
                Items.ForEach(item => sum += item.Amount);
                return sum;
            }
        }

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

        public IEnumerator GetEnumerator()
        {
            return new CartItemEnum(ApplicationContext.Cart);
        }
    }
}
