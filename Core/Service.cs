using System.Text.Json.Serialization;

namespace Eshop.Core
{
    public class Service : SaleItem
    {
        public override SaleItemType Type => SaleItemType.Service;

        [JsonConstructor]
        public Service(int id, string name, decimal price) : base(id, name, price)
        {
        }
        
        public Service(int id, string name, decimal price, string description) : base(id, name, price, description)
        {
        }
    }
}
