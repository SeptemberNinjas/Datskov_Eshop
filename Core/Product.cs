namespace Core;

public interface IGoods
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }

    static abstract IGoods[] Get();
    static abstract IGoods GetByID(int Id);
}
public class Product(int Id, string Name, string Description) : IGoods
{
    public int Id { get; } = Id;

    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;

    public static IGoods[] Get()
    {
        IGoods[] products = 
            [
                new Product(1, "IPhone 16 Pro ultimate HD quadro maximum", "the best of the best of the best"),
                new Product(2, "Xiaomi iphone killer [assasinnator] 512mp", ""),
                new Product(3, "Dexp phone GG340", "1mb/512kb 3\", 0,3mp"),
                new Product(4, "Samsung Galaxy Universe MilkyWay Dominator Keller Terron", ""),
                new Product(5, "End of Ideas product1", "some product"),
                new Product(6, "End of Ideas product2", "some product"),
                new Product(7, "End of Ideas product3", "some product"),
            ];
                return products;
            }
    public static IGoods GetByID(int Id)
    {
        return Get()[Id];
    }
}

public class Service(int Id, string Name, string Description) : IGoods
{
    public int Id { get; } = Id;

    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;

    public static IGoods[] Get()
    {
        IGoods[] services = [
            new Service(1, "Update Android to version 1.2.1.45.85.1.9.7.33", ""),
            new Service(2, "Extra warranty 120 years", ""),
            new Service(3,"Watch in your eyes", ""),
            new Service(4, "Some service1", ""),
            ];
        return services;
    }

    public static IGoods GetByID(int Id)
    {
        return Get()[Id];
    }
}
