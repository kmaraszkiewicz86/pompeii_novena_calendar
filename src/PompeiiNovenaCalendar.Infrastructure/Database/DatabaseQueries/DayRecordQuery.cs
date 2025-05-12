using Dapper;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Infrastructure.Database.Extensions;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class DayRecordQuery(IAppDbQueryContext queryContext, LanguageSettings settings) : IDayRecordQuery
    {
        public async Task<bool> CheckIfCalendarWasGeneratedAsync()
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();

            int count = await connection.Connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM DayRecords");

            return count > 0;
        }

        public async Task<IEnumerable<DayRecordCollectionModel>> GetAllDayRecordsAsync()
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();

            Dictionary<string, string> rossaryTypeNames = await connection.GetRosaryTypeLocalization(settings.Language);

            var sql = @"SELECT dr.*, rs.*, rt.*
                FROM DayRecords dr
                INNER JOIN RosarySelections rs ON dr.Id = rs.DayRecordId
                INNER JOIN RosaryTypes rt ON rs.RosaryTypeId = rt.Id           
                ORDER BY dr.Date";

            DayRecordModel[] daysFromDatabase = [.. (await connection.Connection.QueryAsync<DayRecord, RosarySelection, RosaryType, DayRecordModel>(
                sql,
                (dayRecord, rosarySelection, rosaryType) =>
                {
                    return new DayRecordModel
                    {
                        Id = dayRecord.Id,
                        Day = dayRecord.Date,
                        IsDayCompleted = dayRecord.IsCompleted,
                        RossarySelectionId = rosarySelection.Id,
                        RossaryTypeName = rossaryTypeNames[rosaryType.Key],
                        IsRossarySelectionCompleted = rosarySelection.IsCompleted
                    };
                }
            )).Distinct()];

            return GenerateCollection(daysFromDatabase);
        }

        public async Task<int> GetDaysLengthToEndAsync()
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();
            
            var sql = @"SELECT count(*) FROM DayRecords WHERE IsCompleted = 0";

            return await connection.Connection.ExecuteScalarAsync<int>(sql);
        }

        private IEnumerable<DayRecordCollectionModel> GenerateCollection(DayRecordModel[] daysFromDatabase)
        {
            List<DayRecordCollectionModel> days = [];

            foreach (DayRecordModel dayFromDb in daysFromDatabase)
            {
                if (dayFromDb.Day > DateTime.UtcNow)
                {
                    break;
                }

                DayRecordCollectionModel? day = days.FirstOrDefault(d => d.Id == dayFromDb.Id);

                if (day is null)
                {
                    day = new DayRecordCollectionModel
                    {
                        Id = dayFromDb.Id,
                        Day = dayFromDb.Day,
                        IsCompleted = dayFromDb.IsDayCompleted
                    };

                    days.Add(day);
                }

                day.RosarySelections.Add(new RosarySelectionModel
                {
                    Id = dayFromDb.RossarySelectionId,
                    DayId = dayFromDb.Id,
                    Name = dayFromDb.RossaryTypeName,
                    IsCompleted = dayFromDb.IsRossarySelectionCompleted
                });
            }

            return days;
        }
    }
}
