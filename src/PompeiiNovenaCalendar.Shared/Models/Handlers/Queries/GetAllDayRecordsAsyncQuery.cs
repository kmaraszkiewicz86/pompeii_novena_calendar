using MediatR;
using PompeiiNovenaCalendar.Domain.Models;

namespace PompeiiNovenaCalendar.Shared.Models.Handlers.Queries;
public record GetAllDayRecordsAsyncQuery : IRequest<IEnumerable<DayRecordCollectionModel>>;
