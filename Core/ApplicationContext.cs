namespace Eshop.Core
{
    public class ApplicationContext
    {
        public static Service[] GetServices()
        {
            Service[] services = [
                new (1, "Update Android to version 1.2.1.45.85.1.9.7.33"),
                new (2, "Extra warranty 120 years"),
                new (3, "Watch in your eyes"),
                new (4, "Some service1"),
            ];
            return services;
        }
        public static Product[] GetProducts()
        {
            Product[] products = [
                new (1, "IPhone 16 Pro ultimate HD quadro maximum", "the best of the best of the best"),
                new (2, "Xiaomi iphone killer [assasinnator] 512mp"),
                new (3, "Dexp phone GG340", "1mb/512kb 3\", 0,3mp"),
                new (4, "Samsung Galaxy Universe MilkyWay Dominator Keller Terron"),
                new (5, "End of Ideas product1", "some product"),
                new (6, "End of Ideas product2", "some product"),
                new (7, "End of Ideas product3", "some product"),
            ];
            return products;
        }
    }
}
