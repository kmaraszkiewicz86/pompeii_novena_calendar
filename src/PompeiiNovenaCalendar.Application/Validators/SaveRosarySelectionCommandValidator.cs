using FluentValidation;
using PompeiiNovenaCalendar.Domain.Models.Commands;

namespace PompeiiNovenaCalendar.Application.Validators
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
