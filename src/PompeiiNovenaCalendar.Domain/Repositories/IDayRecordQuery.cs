
namespace PompeiiNovenaCalendar.Domain.Repositories
{
    public interface IDayRecordQuery : IQuery
    {
        Task<bool> CheckIfCalendarWasGeneratedAsync();
    }
}
