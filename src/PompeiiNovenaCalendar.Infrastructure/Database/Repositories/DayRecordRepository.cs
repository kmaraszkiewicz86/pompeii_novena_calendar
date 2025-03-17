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
    }
}
