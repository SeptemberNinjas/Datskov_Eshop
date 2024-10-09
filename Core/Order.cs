namespace Eshop.Core
{
    internal class Order
    {
        public Cart Сomposition { get; }
        public OrderStatuses Status { get; } = OrderStatuses.New;

    }
}
