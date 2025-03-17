using FluentResults;
using MediatR;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands
{
    public class ResetDaysCommandHandler(IDayRecordRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<ResetDaysCommand, Result>
    {
        public async Task<Result> Handle(ResetDaysCommand request, CancellationToken cancellationToken)
        {
            await repository.ResetAsync();
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
