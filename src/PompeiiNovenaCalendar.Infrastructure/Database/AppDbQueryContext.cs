using Microsoft.Data.Sqlite;
using PompeiiNovenaCalendar.Domain.Database;

namespace PompeiiNovenaCalendar.Infrastructure.Database
{
    public class AppDbQueryContext : IAppDbQueryContext
    {
        public SqliteConnection Connection { get; }

        public AppDbQueryContext(string databasePath)
        {
            Connection = new SqliteConnection($"Data Source={databasePath}");
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
