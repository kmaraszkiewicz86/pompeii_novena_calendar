using AutoFixture;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;

namespace PompeiiNovenaCalendar.Application.Tests.Fixtures
{
    public class ToogleRossarySelectionCommandHandlerFixture : BaseFixture
    {
        public IToogleRossarySelectionService Service => this.Freeze<IToogleRossarySelectionService>();

        public ToogleRossarySelectionCommandHandler GetServiceUnderTest()
        {
            var validator = new ToogleRossarySelectionCommandValidator();

            return new ToogleRossarySelectionCommandHandler(validator, Service);
        }
    }
}
