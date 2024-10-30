namespace Eshop.Core
{
    public class Order : IStoraged
    {
        public int Id { get; }
        public int Number { get => Id; }
        public List<OrderItem> Items { get; set; } = [];
        public OrderStatuses Status { get; set; } = OrderStatuses.New;
        public uint Count { get => (uint)Items.Sum(item => item.Count); }
        public decimal TotalAmount { get => Items.Sum(item => item.Amount); }

        public Order(int id) => Id = id;

        public OrderItem Add() 
        { 
            var item = new OrderItem();
            Items.Add(item);
            return item;
        }
    }
}
