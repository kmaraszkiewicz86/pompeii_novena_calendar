using Microsoft.Data.Sqlite;
using PompeiiNovenaCalendar.Domain.Database;

namespace PompeiiNovenaCalendar.Infrastructure.Database
{
    public class AppDbQueryContext(string databasePath) : IAppDbQueryContext
    {
        public async Task<ISqliteConnectionConnection> CreateConnectionAsync()
        {
            SqliteConnection connection = new ($"Data Source={databasePath}");
            await connection.OpenAsync();

            return new SqliteConnectionConnection(connection);
        }
    }
}
