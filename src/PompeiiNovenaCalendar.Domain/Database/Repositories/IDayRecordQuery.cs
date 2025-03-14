using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordQuery : IQuery
    {
        Task<bool> CheckIfCalendarWasGeneratedAsync();
        Task<IEnumerable<DayRecord>> GetDayRecordsWithRosarySelectionsAndTypesAsync();
    }
}
