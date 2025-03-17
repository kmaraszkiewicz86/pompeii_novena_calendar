using AutoFixture;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Application.Tests.Fixtures
{
    public class ToogleRossarySelectionCommandHandlerFixture : BaseFixture
    {
        public ToogleRossarySelectionCommandHandler GetServiceUnderTest()
        {
            var validator = new ToogleRossarySelectionCommandValidator();
            var service = this.Freeze<IRosarySelectionRepository>();
            var unitOfWork = this.Freeze<IUnitOfWork>();

            return new ToogleRossarySelectionCommandHandler(validator, service, unitOfWork);
        }
    }
}
