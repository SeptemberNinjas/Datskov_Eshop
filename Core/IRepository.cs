namespace Eshop.Core
{
    public interface IRepository<T> where T : IStoraged
    {
        public IReadOnlyCollection<T> GetAll();
        public virtual T? GetById(int Id) => GetAll().FirstOrDefault(item => item.Id == Id);
        public virtual int GetCount() => GetAll().Count;
        public void Save(T obj);

        public Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken ct = default);

        public Task<T>? GetByIdAsync(int Id, CancellationToken ct = default);

        public Task<int> GetCountAsync(CancellationToken ct = default);

        public Task SaveAsync(CancellationToken ct = default);

    }
}