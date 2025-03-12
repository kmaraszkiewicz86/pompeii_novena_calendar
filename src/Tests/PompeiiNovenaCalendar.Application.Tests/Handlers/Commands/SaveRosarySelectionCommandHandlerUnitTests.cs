using AutoFixture;
using FluentResults;
using NSubstitute;
using PompeiiNovenaCalendar.Application.Handlers.Commands;
using PompeiiNovenaCalendar.Application.Tests.Fixtures;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using Shouldly;

namespace PompeiiNovenaCalendar.Application.Tests.Handlers.Commands
{
    public class SaveRosarySelectionCommandHandlerUnitTests
    {
        private readonly SaveRosarySelectionCommandHandlerFixture _fixture = new();

        [Fact]
        public async Task HandleAsync_WhenQueryIsValid_ReturnsSuccessResult()
        {
            // Arrange
            SaveRosarySelectionCommand query = new(1, 1, true);
            var unitOfWork = _fixture.Freeze<IUnitOfWork>();
            unitOfWork.SaveChangesAsync().Returns(Task.FromResult(Result.Ok()));

            SaveRosarySelectionCommandHandler handler = _fixture.GetServiceUnderTest();
            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task HandleAsync_WhenQueryIsValidButUnitOfWorkReturnFalseResponse_ReturnsSuccessResult()
        {
            // Arrange
            SaveRosarySelectionCommand query = new(1, 1, true);
            var unitOfWork = _fixture.Freeze<IUnitOfWork>();
            unitOfWork.SaveChangesAsync().Returns(Task.FromResult(Result.Fail("test")));

            SaveRosarySelectionCommandHandler handler = _fixture.GetServiceUnderTest();
            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeFalse();
        }
    }
}
