using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class DayRecordQuery(IAppDbQueryContext queryContext) : IDayRecordQuery
    {
        public async Task<bool> CheckIfCalendarWasGeneratedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
