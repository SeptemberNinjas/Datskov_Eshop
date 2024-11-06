using Eshop.Core;
using System.Text.Json;

namespace Eshop.DataAccess.JSONDataStorage
{
    internal class OrderJSONDataStorage : IRepository<Order>
    {
        private readonly string _dirPath = "JSONDataStorage\\data\\Orders";
        public IReadOnlyCollection<Order> GetAll()
        {
            var dirInfo = new DirectoryInfo(_dirPath);

            List<Order> orders = [];

            if (Directory.Exists(_dirPath))
                foreach (var file in dirInfo.GetFiles("*.jsonOrder"))
                {
                    using var fs = file.Open(FileMode.Open);
                    var order = JsonSerializer.Deserialize<Order>(fs);
                    if (order != null)
                        orders.Add(order);
                }

            return orders;
        }

        public Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct = default) => Task.FromResult(GetAll());

        public Order? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public Task<Order?> GetByIdAsync(int id, CancellationToken ct = default) => Task.FromResult(GetById(id));

        public Task<int> GetCountAsync(CancellationToken ct = default) => Task.FromResult(GetAll().Count);

        public void Save(Order obj)
        {
            if (!File.Exists(_dirPath))
                Directory.CreateDirectory(_dirPath);

            var filePath = $"{_dirPath}\\{obj.Id}.jsonOrder";
            var fileMode = File.Exists(filePath) ? FileMode.Truncate : FileMode.Create;

            using var fs = new FileStream(filePath, fileMode);
            JsonSerializer.Serialize(fs, obj);
        }

        public Task SaveAsync(Order obj, CancellationToken ct = default)
        {
            Save(obj);
            return Task.CompletedTask;
        }

    }
}
