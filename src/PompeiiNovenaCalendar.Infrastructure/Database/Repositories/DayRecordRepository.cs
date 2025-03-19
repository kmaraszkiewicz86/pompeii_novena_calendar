using FluentResults;
using Microsoft.EntityFrameworkCore;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class DayRecordRepository(AppDbContext dbContext) : IDayRecordRepository
    {
        public async Task<Result> MarkDayAsCompletedAsync(int dayId, bool isCompleted)
        {
            DayRecord? day = await dbContext.DayRecords.FindAsync(dayId);

            if (day is null)
            {
                return Result.Fail("Day not found");
            }

            if (day.IsCompleted != isCompleted)
            {
                day.IsCompleted = isCompleted;
                dbContext.DayRecords.Update(day);
            }

            return Result.Ok();
        }

        public async Task AddRangeAsync(ICollection<DayRecord> dayRecords)
        {
            await dbContext.DayRecords.AddRangeAsync(dayRecords);
        }

        public async Task ResetAsync()
        {
            DayRecord[] days = await dbContext.DayRecords.ToArrayAsync();
            RosarySelection[] selections = await dbContext.RosarySelections.ToArrayAsync();

            dbContext.RosarySelections.RemoveRange(selections);
            dbContext.DayRecords.RemoveRange(days);
        }
    }
}
