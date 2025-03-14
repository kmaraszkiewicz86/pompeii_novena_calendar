using Dapper;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class DayRecordQuery(IAppDbQueryContext queryContext) : IDayRecordQuery
    {
        public async Task<bool> CheckIfCalendarWasGeneratedAsync()
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();

            int count = await connection.Connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM DayRecords");

            return count > 0;
        }

        public async Task<IEnumerable<DayRecord>> GetDayRecordsWithRosarySelectionsAndTypesAsync()
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();

            // Zapytanie SQL z trzema tabelami
            var sql = @"
                SELECT dr.Id AS DayRecordId, dr.Date, dr.IsCompleted, 
                       rs.Id AS RosarySelectionId, rs.RosaryTypeId, rs.IsCompleted AS RosarySelectionIsCompleted, 
                       rt.Id AS RosaryTypeId, rt.Name AS RosaryTypeName
                FROM DayRecords dr
                LEFT JOIN RosarySelections rs ON dr.Id = rs.DayRecordId
                LEFT JOIN RosaryTypes rt ON rs.RosaryTypeId = rt.Id
                ORDER BY dr.Date";

            var dayRecords = (await connection.Connection.QueryAsync<DayRecord, RosarySelection, RosaryType, DayRecord>(
                sql,
                (dayRecord, rosarySelection, rosaryType) =>
                {
                    // Mapowanie wyników
                    if (rosarySelection != null)
                    {
                        rosarySelection.RosaryType = rosaryType;
                        dayRecord.RosarySelections.Add(rosarySelection);
                    }
                    return dayRecord;
                },
                splitOn: "RosarySelectionId, RosaryTypeId" 
            )).Distinct().ToList();

            return [.. dayRecords];

        }
    }
}
