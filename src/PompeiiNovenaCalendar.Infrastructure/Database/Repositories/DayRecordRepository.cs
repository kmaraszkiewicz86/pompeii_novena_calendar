using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class DayRecordRepository : IDayRecordRepository
    {
        public Task GenerateInitialDataAsync(GenerateInialDataCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
