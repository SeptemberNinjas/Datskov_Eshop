using Eshop.Core;

namespace Eshop.Application.SaleItemHandlers
{
    public record SaleItemDto
    {
        public int ItemType { get; init; }
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public decimal? Stock { get; init; }

        public SaleItemDto(SaleItemType ItemType, int Id, string Name, string Description, decimal Price, decimal? Stock = null)
        {
            this.ItemType = (int)ItemType;
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Stock = Stock;
        }

        public void Representation(out Dictionary<string, string> representationData)
        {
            representationData = [];
            representationData.Add("Id", Id.ToString());
            representationData.Add("Name", Name);
            representationData.Add("Price", Price.ToString());
            representationData.Add("Description", Description);
            representationData.Add("Stock", Stock?.ToString() ?? "0");
        }
    }
}
