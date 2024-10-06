namespace Core;

public class Product(int Id, ProductType Type, string Name, string Description)
{
    public int Id { get; } = Id;

    public ProductType Type { get; set; } = Type;
    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;
    
    static Product GetByID(int Id)
    {
        return Get()[Id];
    }
    static Product[] Get()
    {
        Product[] products = [
            new Product(1, ProductType.Product, "IPhone 16 Pro ultimate HD quadro maximum", "the best of the best of the best"),
            new Product(2, ProductType.Product, "Xiaomi iphone killer [assasinnator] 512mp", ""),
            new Product(3, ProductType.Product, "Dexp phone GG340", "1mb/512kb 3\", 0,3mp"),
            new Product(4, ProductType.Product, "Samsung Galaxy Universe MilkyWay Dominator Keller Terron", ""),
            new Product(5, ProductType.Product, "End of Ideas product1", "some product"),
            new Product(6, ProductType.Product, "End of Ideas product2", "some product"),
            new Product(7, ProductType.Product, "End of Ideas product3", "some product"),
            new Product(8, ProductType.Service, "Update Android to version 1.2.1.45.85.1.9.7.33", ""),
            new Product(9, ProductType.Service, "Extra warranty 120 years", ""),
            new Product(10, ProductType.Service, "Watch in your eyes", ""),
            new Product(11, ProductType.Service , "Some service1", ""),
            ];
        return products;
    }
}

public enum ProductType {
    Service,
    Product
}
