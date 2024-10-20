namespace Eshop.Core
{
    public interface IRepository<T> where T : IStoredDataCatalog
    {
        public IReadOnlyCollection<T> GetAll();
        public virtual T? GetById(int Id) => GetAll().FirstOrDefault(item => item.Id == Id);
        public virtual int GetCount() => GetAll().Count;
    }
}