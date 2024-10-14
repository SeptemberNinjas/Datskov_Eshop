namespace Eshop.Core
{
    public class Order
    {
        public int Number { get; }
        private readonly List<OrderItem> _items = [];
        public OrderStatuses Status { get; set; } = OrderStatuses.New;
        public uint Count { get => (uint)_items.Sum(item => item.Count); }
        public decimal TotalAmount { get => _items.Sum(item => item.Amount); }

        public Order(Cart cart)
        {
            Number = ApplicationContext.LastOrderNum;

            foreach (CartItem cartItem in cart.Items)
            {
                _items.Add(new(cartItem));
                if (cartItem.Product is not null)
                    cartItem.Product.Stock -= cartItem.Count;
            }
        }
    }
}
