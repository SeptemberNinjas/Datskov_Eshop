namespace Eshop.Core
{
    public abstract class SaleItem
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public SaleItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public SaleItem(int id, string name, decimal price, string description) : this(id, name, price)
        {
            Description = description;
        }

        public void Representation(out Dictionary<string, string> representationData)
        {
            representationData = [];
            representationData.Add("Id", Id.ToString());
            representationData.Add("Name", Name);
            representationData.Add("Price", Price.ToString());
            representationData.Add("Description", Description);
        }
    }
}
