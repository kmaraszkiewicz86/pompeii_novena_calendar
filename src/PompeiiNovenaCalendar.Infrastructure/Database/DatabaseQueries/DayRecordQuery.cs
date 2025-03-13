using Dapper;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class DayRecordQuery(IAppDbQueryContext queryContext) : IDayRecordQuery
    {
        public async Task<bool> CheckIfCalendarWasGeneratedAsync()
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();

            int count = await connection.Connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM DayRecord");

            return count > 0;
        }
    }
}
