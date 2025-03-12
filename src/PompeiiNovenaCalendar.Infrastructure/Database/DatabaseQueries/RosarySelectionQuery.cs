using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class RosarySelectionQuery(IAppDbQueryContext queryContext) : IRosarySelectionQuery
    {
    }
}
