namespace Eshop.Core;

public class Product
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public uint Stock { get; set; }

    public Product(int Id, string Name, decimal Price, uint Stock)
    {
        this.Id = Id;
        this.Name = Name;
        this.Price = Price;
        this.Stock = Stock;
    }
    public Product(int Id, string Name, decimal Price, uint Stock, string Description) : this(Id, Name, Price, Stock)
    {
        this.Description = Description;
    }
    public void Deconstruct(out Dictionary<string, string> descriptionData)
    {
        descriptionData = new()
        {
            { "Id", Id.ToString() },
            { "Name", Name },
            { "Price", Price.ToString() },
            { "Description", Description }
        };
    }
}
