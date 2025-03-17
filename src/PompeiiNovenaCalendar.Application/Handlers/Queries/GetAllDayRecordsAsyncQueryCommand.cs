using MediatR;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;

namespace PompeiiNovenaCalendar.ApplicationLayer.Handlers.Queries
{
    public class GetAllDayRecordsAsyncQueryCommand(IDayRecordQuery databaseQuery) : IRequestHandler<GetAllDayRecordsAsyncQuery, IEnumerable<DayRecordCollectionModel>>
    {
        public Task<IEnumerable<DayRecordCollectionModel>> Handle(GetAllDayRecordsAsyncQuery request, CancellationToken cancellationToken)
        {
            return databaseQuery.GetAllDayRecordsAsync();
        }
    }
}
