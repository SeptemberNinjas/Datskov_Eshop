using System.Text.Json.Serialization;

namespace Eshop.Core;

public class Product : SaleItem, IStoragedCatalog
{
    public uint Stock { get; set; }

    public override SaleItemType Type => SaleItemType.Product;

    [JsonConstructor]
    public Product(int id, string name, decimal price, uint stock) : base(id, name, price) 
    {
        Stock = stock;
    }
    public Product(int Id, string Name, decimal Price, uint Stock, string Description) : this(Id, Name, Price, Stock)
    {
        this.Description = Description;
    }
}
