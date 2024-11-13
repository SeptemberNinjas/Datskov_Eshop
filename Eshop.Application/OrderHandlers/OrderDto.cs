using Eshop.Core;

namespace Eshop.Application.OrderHandlers
{
    public record OrderDto
    {
        public int Id { get; init; }
        public int Number { get => Id; }
        public OrderStatuses Status { get; init; }
        public List<OrderItemDto> Items { get; init; }
        public uint Count { get => (uint)Items.Sum(item => item.Count); }
        public decimal TotalAmount { get => Items.Sum(item => item.Amount); }

        public OrderDto(int id, OrderStatuses status, List<OrderItemDto> items)
        {
            Id = id;
            Status = status;
            Items = items;

        }
    }
}
