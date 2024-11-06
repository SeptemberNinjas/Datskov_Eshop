namespace Eshop.Core
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> GetAll();
        public T? GetById(int id);
        public virtual int GetCount() => GetAll().Count;
        public void Save(T obj);

        public Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken ct = default);

        public Task<T?> GetByIdAsync(int id, CancellationToken ct = default);

        public Task<int> GetCountAsync(CancellationToken ct = default);

        public Task SaveAsync(T obj, CancellationToken ct = default);

    }
}