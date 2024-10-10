using System.Collections;

namespace Eshop.Core
{
    public class Cart : IEnumerable
    {
        public List<CartItem> _items = [];
        public decimal TotalAmount
        {
            get
            {
                decimal sum = 0.0M;
                _items.ForEach(item => sum += item.Amount);
                return sum;
            }
        }

        public string Add(Product product, uint count)
        {
            CartItem? cartItem = _items.Find(value => value.Product == product);
            if (cartItem == null)
            {
                cartItem ??= new(product);
                _items.Add(cartItem);
            }
            cartItem.Count += count;

            return "Product successfully added";
        }
        public string Add(Service service, uint count = 1)
        {
            CartItem? cartItem = _items.Find(value => value.Service == service);
            if (cartItem == null)
            {
                cartItem ??= new(service);
                _items.Add(cartItem);
            }

            return "Service successfully added";
        }
        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return new CartItemEnum(ApplicationContext.Cart);
        }
    }
}
