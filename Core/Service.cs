namespace Eshop.Core
{
    public class Service : SaleItem
    {
        public Service(int id, string name, decimal price) : base(id, name, price)
        {
        }
        
        public Service(int id, string name, decimal price, string description) : base(id, name, price, description)
        {
        }
    }
}
