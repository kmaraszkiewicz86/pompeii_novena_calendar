using Microsoft.Data.Sqlite;
using PompeiiNovenaCalendar.Domain.Database;

namespace PompeiiNovenaCalendar.Infrastructure.Database
{
    public class AppDbQueryContext(string connectionString) : IAppDbQueryContext
    {
        public async Task<ISqliteConnectionConnection> CreateConnectionAsync()
        {
            SqliteConnection connection = new (connectionString);
            await connection.OpenAsync();

            return new SqliteConnectionConnection(connection);
        }
    }
}
