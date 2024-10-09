namespace Eshop.Core
{
    public class ApplicationContext
    {
        private static Product[] _products = [];
        private static Service[] _services = [];
        public static Cart Cart { get; } = new Cart();
        public static Service[] GetServices()
        {
            if (_services.Length == 0)
            {
                _services = [
                    new (1, "Update Android to version 1.2.1.45.85.1.9.7.33"),
                    new (2, "Extra warranty 120 years"),
                    new (3, "Watch in your eyes"),
                    new (4, "Some service1")];
            }
            return _services;
        }
        public static Product[] GetProducts()
        {
            if (_products.Length == 0)
            {
                _products = [
                    new (1, "IPhone 16 Pro ultimate HD quadro maximum", "the best of the best of the best"),
                    new (2, "Xiaomi iphone killer [assasinnator] 512mp"),
                    new (3, "Dexp phone GG340", "1mb/512kb 3\", 0,3mp"),
                    new (4, "Samsung Galaxy Universe MilkyWay Dominator Keller Terron"),
                    new (5, "End of Ideas product1", "some product"),
                    new (6, "End of Ideas product2", "some product"),
                    new (7, "End of Ideas product3", "some product")];
            }
            return _products;
        }
        public static Product? GetProductByID(int Id)
        {
            return Array.Find(_products, x => x.Id == Id);
        }
        public static Service? GetServiceByID(int Id)
        {
            return Array.Find(_services, x => x.Id == Id);
        }
    }
}
