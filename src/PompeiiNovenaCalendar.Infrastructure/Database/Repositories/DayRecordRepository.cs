using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class DayRecordRepository(AppDbContext dbContext) : IDayRecordRepository
    {
        public async Task AddRangeAsync(ICollection<DayRecord> dayRecords)
        {
            await dbContext.DayRecords.AddRangeAsync(dayRecords);
        }
    }
}
