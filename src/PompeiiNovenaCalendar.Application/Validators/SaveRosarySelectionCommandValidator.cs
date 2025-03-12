using FluentValidation;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.ApplicationLayer.Validators
{
    public class SaveRosarySelectionCommandValidator : AbstractValidator<SaveRosarySelectionCommand>
    {
        public SaveRosarySelectionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RosaryId).NotEmpty();
            RuleFor(x => x.IsChecked).NotEmpty();
        }
    }
}
