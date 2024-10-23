using Eshop.Core;

namespace Eshop.DataAccess.MemmoryDataStorage
{
    internal class OrderMemmoryDataStorage : IRepository<Order>
    {
        public IReadOnlyCollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
