using FluentResults;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Services.Interfaces
{
    public interface IToogleRossarySelectionService : IService
    {
        Task<Result> SaveAsync(ToogleRossarySelectionCommand request);
    }
}
