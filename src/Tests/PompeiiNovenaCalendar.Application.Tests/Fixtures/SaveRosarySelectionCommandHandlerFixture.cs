using AutoFixture;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

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
