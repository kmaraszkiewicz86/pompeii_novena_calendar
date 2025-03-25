using AutoFixture;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Domain.Services.Implementations;

namespace PompeiiNovenaCalendar.Application.Tests.Fixtures;

public class NovennaDaysGeneratorFixture : BaseFixture
{
    public IUnitOfWork UnitOfWork => this.Freeze<IUnitOfWork>();
    public IDayRecordRepository DayRecordRepository => this.Freeze<IDayRecordRepository>();
    public IRosaryTypesQuery RosaryTypesQuery => this.Freeze<IRosaryTypesQuery>();
    public LanguageSettings LanguageSettings => this.Freeze<LanguageSettings>();

    public NovennaDaysGenerator GetServiceUnderTest()
    {
        return new NovennaDaysGenerator(UnitOfWork, DayRecordRepository, RosaryTypesQuery, LanguageSettings);
    }
}