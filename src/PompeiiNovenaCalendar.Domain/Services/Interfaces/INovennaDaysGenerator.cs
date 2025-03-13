using FluentResults;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Services.Interfaces
{
    public interface INovennaDaysGenerator : IService
    {
        Task<Result> GenerateInitialDataAsync(GenerateInialDataCommand request);
    }
}
