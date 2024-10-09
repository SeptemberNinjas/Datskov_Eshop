namespace Eshop.Core
{
    internal class Cart
    {
        private readonly List<CartItem> _items = [];
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
            cartItem ??= new(product);

            if (product is Service)
                cartItem.Count = 1;
            else cartItem.Count = +count;

            return "Product successfully added";
        }
    }
}
