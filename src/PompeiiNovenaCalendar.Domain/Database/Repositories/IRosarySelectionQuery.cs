
namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IRosarySelectionQuery : IQuery
    {
        Task<bool> IsDayCompletedAsync(int dayId);
    }
}
