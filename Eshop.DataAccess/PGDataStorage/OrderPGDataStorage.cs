using Eshop.Core;

namespace Eshop.DataAccess.PGDataStorage
{
    class OrderPGDataStorage : DBContext, IRepository<Order>
    {
        public OrderPGDataStorage(string connectionString) : base(connectionString) { }

        public IReadOnlyCollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Order>? GetByIdAsync(int Id, CancellationToken ct = default)
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

        public Task SaveAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
