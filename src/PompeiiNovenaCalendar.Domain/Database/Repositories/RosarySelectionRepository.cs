using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IRosarySelectionRepository : IRepository
    {
        Task ToogleRossarySelectionAsync(SaveRosarySelectionCommand command);
    }
}
