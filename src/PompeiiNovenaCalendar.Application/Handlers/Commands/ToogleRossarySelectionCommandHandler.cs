using FluentResults;
using FluentValidation.Results;
using MediatR;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands
{
    public class ToogleRossarySelectionCommandHandler(ToogleRossarySelectionCommandValidator validator, IRosarySelectionRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<ToogleRossarySelectionCommand, Result>
    {
        public async Task<Result> Handle(ToogleRossarySelectionCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult.Errors.Select(e => e.ErrorMessage)?.ToArray() ?? []);
            }

            Result result = await repository.ToogleRossarySelectionAsync(request);

            if (result.IsFailed)
            {
                return result;
            }

            return  await unitOfWork.SaveChangesAsync();
        }
    }
}
