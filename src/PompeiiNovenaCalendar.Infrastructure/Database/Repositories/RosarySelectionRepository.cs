using PompeiiNovenaCalendar.Domain.Models.Commands;
using PompeiiNovenaCalendar.Domain.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class RosarySelectionRepository : IRosarySelectionRepository
    {
        public async Task ToogleRossarySelectionAsync(SaveRosarySelectionCommand command)
        {
        }
    }
}
