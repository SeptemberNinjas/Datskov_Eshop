using Eshop.Core;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Eshop.DataAccess.DatabaseStorage
{
    class OrderDatabaseStorage : DBContext, IRepository<Order>
    {
        public OrderDatabaseStorage(string connectionString) : base(connectionString) { }

        public IReadOnlyCollection<Order> GetAll() => GetAllAsync().Result;

        public async Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct = default)
        {
            var query =
                @"SELECT 
                    o.id,
                    o.status,
                    Array(SELECT 
                            row_to_json(t)
                        FROM (SELECT 
                                ol.saleitemid,
                                ol.price,
                                ol.count
                              FROM 
                                order_lines ol 
                              WHERE 
                                o.id = ol.id) as t ) as lines
                FROM 
                    orders o";

            return await ExecuteReaderListAsync<Order>(query, ct, GetOrder);
        }

        private static Order GetOrder(DbDataReader reader)
        {
            var order = new Order(reader.GetFieldValue<int>("id"))
            {
                Status = (OrderStatuses)reader.GetFieldValue<int>("status")
            };

            var jsonLines = reader.GetFieldValue<string[]>("lines");

            foreach (var jsonLine in jsonLines)
            {
                var definition = new { saleitemid = 0, price = "", count = 1 };
                dynamic? parsed = JsonSerializer.Deserialize(jsonLine, definition.GetType());

                var ci = new CultureInfo("en-US");

                var line = new OrderItem
                {
                    Price = Convert.ToDecimal(((string?)parsed?.price ?? "").Replace("$", ""), ci),
                    SaleItemId = parsed?.saleitemid,
                    Count = Convert.ToUInt32(parsed?.count ?? 0)
                };
                order.Items.Add(line);
            }

            return order;
        }

        public Order? GetById(int id) => GetByIdAsync(id).Result;
        
        public async Task<Order?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var query =
                $@"SELECT 
                    o.id,
                    o.status,
                    Array(SELECT 
                            row_to_json(t)
                        FROM (SELECT 
                                ol.saleitemid,
                                ol.price,
                                ol.count
                              FROM 
                                order_lines ol 
                              WHERE 
                                o.id = ol.id) as t ) as lines
                FROM 
                    orders o 
                WHERE id = {id}";

            var list = await ExecuteReaderListAsync<Order>(query, ct, GetOrder);
            return list.FirstOrDefault(x => x.Id == id)!;
        }

        public Task<int> GetCountAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public void Save(Order obj) => SaveAsync(obj).Wait();

        public async Task SaveAsync(Order obj, CancellationToken ct = default)
        {
            var insertLinesStatement = string.Empty;

            if (obj.Items.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine("INSERT INTO order_lines(id, saleitemid, price, count)");
                sb.AppendLine("VALUES");

                var values = new List<string>();
                foreach (var line in obj.Items)
                    values.Add($"({obj.Id}, {line.SaleItemId}, {line.Price.ToString().Replace(",", ".")}, '{line.Count}')");

                sb.AppendJoin(", ", values);
                sb.Append(";");

                insertLinesStatement = sb.ToString();
            }

            var query =
                $@"DO $$DECLARE r record;
                BEGIN
                    INSERT INTO orders (id, status)
                    VALUES ({obj.Id}, {(int)obj.Status})
                    ON CONFLICT(id)
                    DO UPDATE SET
                        status = EXCLUDED.status
                    ;
                    DELETE FROM order_lines WHERE id = {obj.Id}
                    ;

                    {insertLinesStatement}
                END$$;";

            await ExecuteNonQueryAsync(query, ct);
        }
    }
}
