using FluentValidation;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Validators
{
    public class GenerateInialDataCommandValidator : AbstractValidator<GenerateInialDataCommand>
    {
        public GenerateInialDataCommandValidator()
        {
            RuleFor(x => x.fromDate).NotEmpty();
        }
    }
}
