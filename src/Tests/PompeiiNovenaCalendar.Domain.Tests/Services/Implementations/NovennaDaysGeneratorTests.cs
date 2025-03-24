using NSubstitute;
using PompeiiNovenaCalendar.Application.Tests.Fixtures;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Services.Implementations;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Tests.Services.Implementations;

public class NovennaDaysGeneratorTests
{
    private readonly NovennaDaysGeneratorFixture _fixture = new();

    [Fact]
    public async Task GenerateInitialDataAsync_ShouldGenerate54Days()
    {
        // Arrange
        NovennaDaysGenerator generator = _fixture.GetServiceUnderTest();
        GenerateInialDataCommand command = new(new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Utc));

        // Act
        await generator.GenerateInitialDataAsync(command);

        // Assert
        await _fixture.DayRecordRepository.Received(1).AddRangeAsync(Arg.Is<List<DayRecord>>(list => list.Count == 54));
        await _fixture.UnitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task GenerateInitialDataAsync_ShouldSetCorrectDates()
    {
        // Arrange
        NovennaDaysGenerator generator = _fixture.GetServiceUnderTest();
        var startDate = new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Utc);
        GenerateInialDataCommand command = new(new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Utc));
        _fixture.RosaryTypesQuery.GetAllRosaryTypesAsync().Returns([
            new RosaryType { Id = 1, RosaryTypeLocalization = new RosaryTypeLocalization { Id = 1, Name = "Tajemnice radosne" } },
            new RosaryType { Id = 2, RosaryTypeLocalization = new RosaryTypeLocalization { Id = 2, Name = "Tajemnice bolesne" } },
            new RosaryType { Id = 3, RosaryTypeLocalization = new RosaryTypeLocalization { Id = 3, Name = "Tajemnice chwalebne" } },
            new RosaryType { Id = 4, RosaryTypeLocalization = new RosaryTypeLocalization { Id = 4, Name = "Tajemnice światła" } }
        ]);

        // Act
        await generator.GenerateInitialDataAsync(command);

        // Assert
        await _fixture.DayRecordRepository.Received(1).AddRangeAsync(Arg.Is<List<DayRecord>>(list =>
            list.Count == 54 &&
            list.All(l => l.RosarySelections.Count == 4) &&
            list[0].Date == startDate &&
            list[53].Date == startDate.AddDays(53)
        ));
    }
}
