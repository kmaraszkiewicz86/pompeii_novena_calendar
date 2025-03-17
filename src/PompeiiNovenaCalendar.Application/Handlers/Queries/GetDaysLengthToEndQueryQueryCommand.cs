using MediatR;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.ApplicationLayer.Handlers.Queries
{
    public class GetDaysLengthToEndQueryQueryCommand(IDayRecordQuery databaseQuery) : IRequestHandler<GetDaysLengthToEndQuery, int>
    {
        public Task<int> Handle(GetDaysLengthToEndQuery request, CancellationToken cancellationToken)
        {
            return databaseQuery.GetDaysLengthToEndAsync();
        }
    }
}
