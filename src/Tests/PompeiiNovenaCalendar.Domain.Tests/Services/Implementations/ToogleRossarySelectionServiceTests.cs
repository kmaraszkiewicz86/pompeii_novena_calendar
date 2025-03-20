using FluentResults;
using NSubstitute;
using PompeiiNovenaCalendar.Application.Tests.Fixtures;
using PompeiiNovenaCalendar.Domain.Services.Implementations;
using PompeiiNovenaCalendar.Domain.Tests.Enums;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using Shouldly;

namespace PompeiiNovenaCalendar.Domain.Tests.Services.Implementations;

public class ToogleRossarySelectionServiceTests
{
    private readonly ToogleRossarySelectionServiceFixture _fixture = new();

    [Fact]
    public async Task GenerateInitialDataAsync_WhenProcessPass_ShouldReturnOkResponse()
    {
        // Arrange
        ToogleRossarySelectionService service = _fixture.GetServiceUnderTest();

        _fixture.RosarySelectionRepository.ToogleRossarySelectionAsync(Arg.Any<ToogleRossarySelectionCommand>()).Returns(Result.Ok());
        _fixture.DayRecordRepository.MarkDayAsCompletedAsync(Arg.Any<int>(), Arg.Any<bool>()).Returns(Result.Ok());
        _fixture.RosarySelectionQuery.IsDayCompletedAsync(Arg.Any<int>()).Returns(true);
        _fixture.UnitOfWork.SaveChangesAsync().Returns(Result.Ok());

        // Act
        Result result = await service.SaveAsync(_fixture.ToogleRossarySelectionCommand);

        // Assert
        result.IsSuccess.ShouldBeTrue();
    }

    [Theory]
    [InlineData(ToogleRossarySelectionServiceType.ToogleRossarySelectionAsync)]
    [InlineData(ToogleRossarySelectionServiceType.MarkDayAsCompletedAsync)]
    [InlineData(ToogleRossarySelectionServiceType.UnitOfWork)]
    public async Task GenerateInitialDataAsync_WhenProcessFail_ShouldReturnOkResponse(ToogleRossarySelectionServiceType type)
    {
        // Arrange
        ToogleRossarySelectionService service = _fixture.GetServiceUnderTest();
        var fakeResult = Result.Fail("test");

        _fixture.RosarySelectionRepository.ToogleRossarySelectionAsync(Arg.Any<ToogleRossarySelectionCommand>())
            .Returns(type == ToogleRossarySelectionServiceType.ToogleRossarySelectionAsync ? fakeResult : Result.Ok());
        _fixture.DayRecordRepository.MarkDayAsCompletedAsync(Arg.Any<int>(), Arg.Any<bool>())
            .Returns(type == ToogleRossarySelectionServiceType.MarkDayAsCompletedAsync ? fakeResult : Result.Ok());
        _fixture.UnitOfWork.SaveChangesAsync()
            .Returns(type == ToogleRossarySelectionServiceType.UnitOfWork ? fakeResult : Result.Ok());
        _fixture.RosarySelectionQuery.IsDayCompletedAsync(Arg.Any<int>())
            .Returns(true);

        // Act
        Result result = await service.SaveAsync(_fixture.ToogleRossarySelectionCommand);

        // Assert
        result.ShouldBe(result);
    }
}
