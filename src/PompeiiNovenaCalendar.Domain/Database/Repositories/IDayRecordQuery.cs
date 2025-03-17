using PompeiiNovenaCalendar.Domain.Models;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordQuery : IQuery
    {
        Task<bool> CheckIfCalendarWasGeneratedAsync();
        Task<int> GetDaysLengthToEndAsync();
        Task<IEnumerable<DayRecordCollectionModel>> GetAllDayRecordsAsync();
    }
}
