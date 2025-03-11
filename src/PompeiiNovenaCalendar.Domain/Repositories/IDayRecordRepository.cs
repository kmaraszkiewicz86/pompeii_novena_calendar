using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Repositories
{
    public interface IDayRecordRepository : IRepository
    {
        Task GenerateInitialDataAsync(GenerateInialDataCommand request);
    }
}
