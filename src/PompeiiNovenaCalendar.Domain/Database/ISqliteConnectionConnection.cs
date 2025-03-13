using Microsoft.Data.Sqlite;

namespace PompeiiNovenaCalendar.Domain.Database
{
    public interface ISqliteConnectionConnection: IAsyncDisposable
    {
        SqliteConnection Connection { get; }
    }
}
