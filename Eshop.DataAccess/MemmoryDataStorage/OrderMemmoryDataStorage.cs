using Eshop.Core;

namespace Eshop.DataAccess.MemmoryDataStorage
{
    internal class OrderMemmoryDataStorage : IRepository<Order>
    {
        public IReadOnlyCollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Order? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByIdAsync(int Id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public void Save(Order obj)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Order obj,CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
