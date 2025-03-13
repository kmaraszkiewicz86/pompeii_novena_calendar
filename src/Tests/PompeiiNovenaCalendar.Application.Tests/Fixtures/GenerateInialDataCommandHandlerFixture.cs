using AutoFixture;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;

namespace PompeiiNovenaCalendar.Application.Tests.Fixtures
{
    public class GenerateInialDataCommandHandlerFixture : BaseFixture
    {
        public GenerateInialDataCommandHandler GetServiceUnderTest()
        {
            var validator = new GenerateInialDataCommandValidator();
            var service = this.Freeze<INovennaDaysGenerator>();

            return new GenerateInialDataCommandHandler(validator, service);
        }
    }
}
