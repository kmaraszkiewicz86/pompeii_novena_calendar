using FluentResults;
using FluentValidation.Results;
using MediatR;
using PompeiiNovenaCalendar.Application.Validators;
using PompeiiNovenaCalendar.Domain.Models.Commands;
using PompeiiNovenaCalendar.Domain.Repositories;

namespace PompeiiNovenaCalendar.Application.Handlers.SaveRosarySelection
{
    public class SaveRosarySelectionCommandHandler(IRosarySelectionRepository repository, SaveRosarySelectionCommandValidator validator, IUnitOfWork unitOfWork) : IRequestHandler<SaveRosarySelectionCommand, Result>
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
