namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IDayRecordQuery : IQuery
    {
        Task<bool> CheckIfCalendarWasGeneratedAsync();
    }
}
