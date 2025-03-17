using MediatR;
using PompeiiNovenaCalendar.Domain.Models;

namespace PompeiiNovenaCalendar.Shared.Models.Handlers.Queries
{
    public class GetAllDayRecordsAsyncQuery : IRequest<IEnumerable<DayRecordCollectionModel>>
    {
    }
}
