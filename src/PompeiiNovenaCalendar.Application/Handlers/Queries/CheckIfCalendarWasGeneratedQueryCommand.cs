using MediatR;
using PompeiiNovenaCalendar.Domain.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.Application.Handlers.Queries
{
    public class CheckIfCalendarWasGeneratedQueryCommand(IDayRecordQuery databaseQuery) : IRequestHandler<CheckIfCalendarWasGeneratedQuery, bool>
    {
        public Task<bool> Handle(CheckIfCalendarWasGeneratedQuery request, CancellationToken cancellationToken)
        {
            return databaseQuery.CheckIfCalendarWasGeneratedAsync();
        }
    }
}
