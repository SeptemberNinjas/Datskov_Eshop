namespace Eshop.Core;

public class Product
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public uint Stock { get; set; }

    public Product(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }
    public Product(int Id, string Name, string Description) : this(Id, Name)
    {
        this.Description = Description;
    }
}
