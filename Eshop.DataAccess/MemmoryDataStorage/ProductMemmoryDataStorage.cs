using Eshop.Core;

namespace Eshop.DataAccess.MemmoryDataStorage
{
    public class ProductMemmoryDataStorage : IRepository<Product>
    {
        public IReadOnlyCollection<Product> GetAll()
        {
            Product[] _products = [
                    new (1, "IPhone 16 Pro ultimate HD quadro maximum", 155499, 10, "the best of the best of the best"),
                    new (2, "Xiaomi iphone killer [assasinnator] 512mp", 70999, 200),
                    new (3, "Dexp phone GG340", 1699, 20000, "1mb/512kb 3\", 0,3mp"),
                    new (4, "Samsung Galaxy Universe MilkyWay Dominator Keller Terron", 124599, 100),
                    new (5, "End of Ideas product1", 599, 10 ,"some product"),
                    new (6, "End of Ideas product2", 699, 10, "some product"),
                    new (7, "End of Ideas product3", 799, 10, "some product")];

            return _products;
        }
    }
}
