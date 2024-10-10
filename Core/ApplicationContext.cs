﻿namespace Eshop.Core
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
                    new (1, "Update Android to version 1.2.1.45.85.1.9.7.33", 1000),
                    new (2, "Extra warranty 120 years", 3000),
                    new (3, "Watch in your eyes", 100),
                    new (4, "Some service1", 200)];
            }
            return _services;
        }
        public static Product[] GetProducts()
        {
            if (_products.Length == 0)
            {
                _products = [
                    new (1, "IPhone 16 Pro ultimate HD quadro maximum", 155499, 10, "the best of the best of the best"),
                    new (2, "Xiaomi iphone killer [assasinnator] 512mp", 70999, 200),
                    new (3, "Dexp phone GG340", 1699, 20000, "1mb/512kb 3\", 0,3mp"),
                    new (4, "Samsung Galaxy Universe MilkyWay Dominator Keller Terron", 124599, 100),
                    new (5, "End of Ideas product1", 599, 10 ,"some product"),
                    new (6, "End of Ideas product2", 699, 10, "some product"),
                    new (7, "End of Ideas product3", 799, 10, "some product")];
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
