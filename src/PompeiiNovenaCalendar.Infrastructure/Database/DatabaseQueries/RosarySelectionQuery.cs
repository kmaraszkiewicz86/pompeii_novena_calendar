using Dapper;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class RosarySelectionQuery(IAppDbQueryContext queryContext) : IRosarySelectionQuery
    {
        public async Task<bool> IsDayCompletedAsync(int dayId)
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();
            var sql = @"SELECT COUNT(*) FROM RosarySelections WHERE DayRecordId = @DayId and IsCompleted = 1 and RosaryTypeId IN (1,2,3)";
            int count = await connection.Connection.ExecuteScalarAsync<int>(sql, new { DayId = dayId });
            return count == 3;
        }
    }
}
