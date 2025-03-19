using AutoFixture;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Services.Implementations;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Application.Tests.Fixtures
{
    public class ToogleRossarySelectionServiceFixture : BaseFixture
    {
        public IRosarySelectionRepository RosarySelectionRepository => this.Freeze<IRosarySelectionRepository>();
        public IDayRecordRepository DayRecordRepository => this.Freeze<IDayRecordRepository>();
        public IRosarySelectionQuery RosarySelectionQuery => this.Freeze<IRosarySelectionQuery>();
        public IUnitOfWork UnitOfWork => this.Freeze<IUnitOfWork>();

        public ToogleRossarySelectionCommand ToogleRossarySelectionCommand => this.Create<ToogleRossarySelectionCommand>();

        public ToogleRossarySelectionService GetServiceUnderTest()
        {
            return new ToogleRossarySelectionService(
                RosarySelectionRepository, 
                DayRecordRepository, 
                RosarySelectionQuery, 
                UnitOfWork);
        }
    }
}
