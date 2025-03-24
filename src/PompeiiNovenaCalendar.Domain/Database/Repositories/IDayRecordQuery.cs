using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordQuery : IQuery
    {
        Task<bool> CheckIfCalendarWasGeneratedAsync();
        Task<int> GetDaysLengthToEndAsync();
        Task<IEnumerable<DayRecordCollectionModel>> GetAllDayRecordsAsync();
    }
}
