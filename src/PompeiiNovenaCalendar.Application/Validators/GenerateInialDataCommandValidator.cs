using FluentValidation;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Application.Validators
{
    public class GenerateInialDataCommandValidator : AbstractValidator<GenerateInialDataCommand>
    {
        public GenerateInialDataCommandValidator()
        {
            RuleFor(x => x.fromDate).NotEmpty();
        }
    }
}
