using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Models;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordQuery : IQuery
    {
        Task<bool> CheckIfCalendarWasGeneratedAsync();
        Task<IEnumerable<DayRecordModel>> GetAllDayRecordsAsync();
    }
}
