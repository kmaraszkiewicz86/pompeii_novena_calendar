using FluentResults;
using FluentValidation.Results;
using MediatR;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands
{
    public class SaveRosarySelectionCommandHandler(SaveRosarySelectionCommandValidator validator, IRosarySelectionRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<SaveRosarySelectionCommand, Result>
    {
        public async Task<Result> Handle(SaveRosarySelectionCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                return Result.Fail(validationResult.Errors.Select(e => e.ErrorMessage)?.ToArray() ?? []);
            }

            await repository.ToogleRossarySelectionAsync(request);

            return  await unitOfWork.SaveChangesAsync();
        }
    }
}
