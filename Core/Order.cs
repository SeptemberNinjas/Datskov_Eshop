namespace Eshop.Core
{
    public class Order
    {
        public int Number { get; }
        public List<OrderItem> Items = [];
        public OrderStatuses Status { get; set; } = OrderStatuses.New;
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

        public Order(Cart cart)
        {
            Number = ApplicationContext.LastOrderNum;
            ApplicationContext.LastOrderNum++;

            foreach (CartItem cartItem in cart)
            {
                Items.Add(new(cartItem));
            } 
        }
        public void SetStatus(OrderStatuses status) => Status = status;
    }
}
