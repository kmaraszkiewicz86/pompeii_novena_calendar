using NSubstitute;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Services.Implementations;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Domain.Tests.Services.Implementations;

public class NovennaDaysGeneratorTests
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDayRecordRepository _repository;
    private readonly NovennaDaysGenerator _generator;

    public NovennaDaysGeneratorTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _repository = Substitute.For<IDayRecordRepository>();
        _generator = new NovennaDaysGenerator(_unitOfWork, _repository);
    }

    [Fact]
    public async Task GenerateInitialDataAsync_ShouldGenerate54Days()
    {
        // Arrange
        GenerateInialDataCommand command = new (new DateTime(2024, 3, 1, 0, 0 ,0, DateTimeKind.Utc));

        // Act
        await _generator.GenerateInitialDataAsync(command);

        // Assert
        await _repository.Received(1).AddRangeAsync(Arg.Is<List<DayRecord>>(list => list.Count == 54));
        await _unitOfWork.Received(1).SaveChangesAsync();
    }

    [Fact]
    public async Task GenerateInitialDataAsync_ShouldSetCorrectDates()
    {
        // Arrange
        var startDate = new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Utc);
        GenerateInialDataCommand command = new(new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Utc));

        // Act
        await _generator.GenerateInitialDataAsync(command);

        // Assert
        await _repository.Received(1).AddRangeAsync(Arg.Is<List<DayRecord>>(list =>
            list.Count == 54 &&
            list[0].Date == startDate &&
            list[53].Date == startDate.AddDays(53)
        ));
    }
}
