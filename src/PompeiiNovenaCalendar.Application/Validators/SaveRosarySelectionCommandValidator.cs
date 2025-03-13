using FluentValidation;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Validators
{
    public class SaveRosarySelectionCommandValidator : AbstractValidator<SaveRosarySelectionCommand>
    {
        public SaveRosarySelectionCommandValidator()
        {
            RuleFor(x => x.Id)
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
