using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordRepository : IRepository
    {
        Task AddRangeAsync(ICollection<DayRecord> dayRecords);
        Task ResetAsync();
    }
}
