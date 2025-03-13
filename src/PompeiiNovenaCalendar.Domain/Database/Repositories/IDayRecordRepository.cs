using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordRepository : IRepository
    {
        Task AddRangeAsync(ICollection<DayRecord> dayRecords);
    }
}
