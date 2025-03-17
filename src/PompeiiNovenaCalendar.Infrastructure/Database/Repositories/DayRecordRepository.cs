using Microsoft.EntityFrameworkCore;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class DayRecordRepository(AppDbContext dbContext) : IDayRecordRepository
    {
        public async Task AddRangeAsync(ICollection<DayRecord> dayRecords)
        {
            await dbContext.DayRecords.AddRangeAsync(dayRecords);
        }

        public async Task ResetAsync()
        {
            DayRecord[] days = await dbContext.DayRecords.ToArrayAsync();
            RosarySelection[] selections = await dbContext.RosarySelections.ToArrayAsync();

            dbContext.DayRecords.RemoveRange(days);
            dbContext.RosarySelections.RemoveRange(selections);
        }
    }
}
