using FluentResults;
using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordRepository : IRepository
    {
        Task<Result> MarkDayAsCompletedAsync(int dayId, bool isCompleted);
        Task AddRangeAsync(ICollection<DayRecord> dayRecords);
        Task ResetAsync();
    }
}
