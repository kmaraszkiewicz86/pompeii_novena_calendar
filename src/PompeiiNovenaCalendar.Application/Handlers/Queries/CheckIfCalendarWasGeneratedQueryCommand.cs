using MediatR;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.ApplicationLayer.Handlers.Queries
{
    public class CheckIfCalendarWasGeneratedQueryCommand(IDayRecordQuery databaseQuery) : IRequestHandler<CheckIfCalendarWasGeneratedQuery, bool>
    {
        public Task<bool> Handle(CheckIfCalendarWasGeneratedQuery request, CancellationToken cancellationToken)
        {
            return databaseQuery.CheckIfCalendarWasGeneratedAsync();
        }
    }
}
