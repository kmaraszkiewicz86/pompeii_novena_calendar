using Microsoft.Data.Sqlite;
using PompeiiNovenaCalendar.Domain.Database;

namespace PompeiiNovenaCalendar.Infrastructure.Database
{
    public class SqliteConnectionConnection : ISqliteConnectionConnection
    {
        public SqliteConnection Connection { get; }

        public SqliteConnectionConnection(SqliteConnection connection)
        {
            Connection = connection;
        }

        public async ValueTask DisposeAsync()
        {
            await Connection.CloseAsync();
        }
    }
}
