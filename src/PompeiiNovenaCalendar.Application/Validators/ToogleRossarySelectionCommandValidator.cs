using FluentValidation;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Validators
{
    public class ToogleRossarySelectionCommandValidator : AbstractValidator<ToogleRossarySelectionCommand>
    {
        public ToogleRossarySelectionCommandValidator()
        {
            RuleFor(x => x.DayId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(x => x.RosaryId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(x => x.IsChecked)
                .NotEmpty();
        }
    }
}
