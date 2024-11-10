using Npgsql;
using System.Data;
using System.Data.Common;

namespace Eshop.DataAccess.DatabaseStorage
{
    public class DBContext : IDisposable
    {
        private readonly string _connectionString;

        private NpgsqlConnection? _connection;

        public DBContext(string connectionString) => _connectionString = connectionString;

        public void Dispose() => _connection?.Dispose();

        public NpgsqlConnection GetConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                return _connection;

            _connection = new NpgsqlConnection(_connectionString);

            _connection.Open();

            return _connection;
        }

        public NpgsqlCommand GetCommand(string text)
        {
            return new NpgsqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = text
            };
        }

        public async Task<NpgsqlConnection> GetConnectionAsync(CancellationToken ct)
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                return _connection;

            _connection = new NpgsqlConnection(_connectionString);

            await _connection.OpenAsync(ct);

            return _connection;
        }

        protected async Task<IReadOnlyCollection<T>> ExecuteReaderListAsync<T>(string query,
            CancellationToken ct, Func<DbDataReader, T> binding)
        {
            using var connection = await GetConnectionAsync(ct);

            var command = GetCommand(query);

            using var reader = await command.ExecuteReaderAsync(ct);

            var result = new List<T>();

            while (await reader.ReadAsync(ct))
            {
                result.Add(binding(reader));
            }

            return result;
        }
        protected async Task<int> ExecuteNonQueryAsync(string query, CancellationToken ct)
        {
            using var connection = await GetConnectionAsync(ct);

            var command = GetCommand(query);

            return await command.ExecuteNonQueryAsync(ct);
        }
    }
}
