using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class RosarySelectionRepository : IRosarySelectionRepository
    {
        public async Task ToogleRossarySelectionAsync(SaveRosarySelectionCommand command)
        {
        }
    }
}
