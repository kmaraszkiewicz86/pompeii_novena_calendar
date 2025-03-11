using AutoFixture;
using PompeiiNovenaCalendar.Application.Handlers.Commands;
using PompeiiNovenaCalendar.Application.Validators;
using PompeiiNovenaCalendar.Domain.Repositories;

namespace PompeiiNovenaCalendar.Application.Tests.Fixtures
{
    public class SaveRosarySelectionCommandHandlerFixture : BaseFixture
    {
        public SaveRosarySelectionCommandHandler GetServiceUnderTest()
        {
            var validator = new SaveRosarySelectionCommandValidator();
            var service = this.Freeze<IRosarySelectionRepository>();
            var unitOfWork = this.Freeze<IUnitOfWork>();

            return new SaveRosarySelectionCommandHandler(validator, service, unitOfWork);
        }
    }
}
