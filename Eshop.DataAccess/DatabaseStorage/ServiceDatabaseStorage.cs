using Eshop.Core;
using System.Data;
using System.Data.Common;

namespace Eshop.DataAccess.DatabaseStorage
{
    public class ServiceDatabaseStorage : DBContext, IRepository<Service>
    {
        public ServiceDatabaseStorage(string connectionString) : base(connectionString) { }

        public IReadOnlyCollection<Service> GetAll()
        {
            using var command = GetCommand(
                @"select 
                    c.*
                from 
                    catalog c
                where 
                    type = 2
                order by 
                    id");

            using var reader = command.ExecuteReader();

            var result = new List<Service>();

            while (reader.Read())
            {
                result.Add(GetService(reader));
            }

            return result;
        }

        public async Task<IReadOnlyCollection<Service>> GetAllAsync(CancellationToken ct = default)
        {
            var query =
                @"select 
                    c.*
                from 
                    catalog c
                where 
                    type = 2
                order by 
                    id";

            return await ExecuteReaderListAsync<Service>(query, ct, GetService);
        }

        private static Service GetService(DbDataReader reader)
        {
            return new Service(
                    reader.GetFieldValue<int>("id"),
                    reader.GetFieldValue<string>("name"),
                    reader.GetFieldValue<decimal>("price"),
                    reader.GetFieldValue<string>("description"));
        }

        public Service? GetById(int id) => GetByIdAsync(id).Result;

        public async Task<Service?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var query =
                $@"select 
                    c.*
                from 
                    catalog c
                where 
                    type = 2
                    and id = {id}";

            var list = await ExecuteReaderListAsync<Service>(query, ct, GetService);
            return list.FirstOrDefault(x => x.Id == id)!;
        }

        public async Task<int> GetCountAsync(CancellationToken ct = default)
        {
            using var command = GetCommand(
                $@"select count(*) as count
                from 
                    catalog c
                where 
                    type = 2");

            var result = await command.ExecuteScalarAsync(ct);

            return int.TryParse(result?.ToString(), out int count) ? count : 0;
        }

        public void Save(Service obj)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Service obj, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
