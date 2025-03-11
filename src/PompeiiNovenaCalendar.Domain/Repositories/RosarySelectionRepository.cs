using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Repositories
{
    public interface IRosarySelectionRepository : IRepository
    {
        Task ToogleRossarySelectionAsync(SaveRosarySelectionCommand command);
    }
}
