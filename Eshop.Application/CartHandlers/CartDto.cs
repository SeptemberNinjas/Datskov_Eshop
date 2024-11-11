namespace Eshop.Application.CartHandlers
{
    public class CartDto
    {
        public List<CartItemDto> Items { get; init; }
        public uint Count { get => (uint)Items.Sum(item => item.Count); }
        public decimal TotalAmount { get => Items.Sum(item => item.Amount); }

        public CartDto(List<CartItemDto> items) { Items = items; }
    }
}
