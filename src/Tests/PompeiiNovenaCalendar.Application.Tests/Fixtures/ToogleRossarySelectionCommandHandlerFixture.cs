using AutoFixture;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;

namespace PompeiiNovenaCalendar.Application.Tests.Fixtures
{
    public class ToogleRossarySelectionCommandHandlerFixture : BaseFixture
    {
        public ToogleRossarySelectionCommandHandler GetServiceUnderTest()
        {
            var validator = new ToogleRossarySelectionCommandValidator();
            var service = this.Freeze<IToogleRossarySelectionService>();

            return new ToogleRossarySelectionCommandHandler(validator, service);
        }
    }
}
