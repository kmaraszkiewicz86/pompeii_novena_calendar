using AutoFixture;
using FluentResults;
using NSubstitute;
using PompeiiNovenaCalendar.Application.Tests.Fixtures;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using Shouldly;

namespace PompeiiNovenaCalendar.Application.Tests.Handlers.Commands
{
    public class ToogleRossarySelectionCommandHandlerUnitTests
    {
        private readonly ToogleRossarySelectionCommandHandlerFixture _fixture = new();

        [Fact]
        public async Task HandleAsync_WhenQueryIsValid_ShouldReturnsInvalidResult()
        {
            // Arrange

            // Arrange
            ToogleRossarySelectionCommandHandler handler = _fixture.GetServiceUnderTest();
            ToogleRossarySelectionCommand query = new(-1, -1, true);
            var unitOfWork = _fixture.Freeze<IUnitOfWork>();
            unitOfWork.SaveChangesAsync().Returns(Task.FromResult(Result.Fail("test")));

            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeFalse();
        }

        [Fact]
        public async Task HandleAsync_WhenUnityOfWorkReturnInvalidResult_ShouldReturnsInvalidResult()
        {
            // Arrange
            ToogleRossarySelectionCommandHandler handler = _fixture.GetServiceUnderTest();
            ToogleRossarySelectionCommand query = new(1, 1, true);
            var unitOfWork = _fixture.Freeze<IUnitOfWork>();
            unitOfWork.SaveChangesAsync().Returns(Task.FromResult(Result.Fail("test")));

            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeFalse();
        }

        [Fact]
        public async Task HandleAsync_WhenValidationSuccess_ShouldCallGenerateInitialDataAsyncMethod()
        {
            // Arrange
            ToogleRossarySelectionCommandHandler handler = _fixture.GetServiceUnderTest();
            ToogleRossarySelectionCommand query = new(1, 1, true);
            _fixture.Freeze<IUnitOfWork>().SaveChangesAsync().Returns(Result.Ok());
            var repository = _fixture.Freeze<IRosarySelectionRepository>();

            // Act
            await handler.Handle(query, CancellationToken.None);

            // Assert
            await repository.Received(1).ToogleRossarySelectionAsync(query);
        }

        [Fact]
        public async Task HandleAsync_WhenValidationSuccess_ShouldReturnValidResult()
        {
            // Arrange
            ToogleRossarySelectionCommand query = new(1, 1, true);
            var unitOfWork = _fixture.Freeze<IUnitOfWork>();
            unitOfWork.SaveChangesAsync().Returns(Task.FromResult(Result.Ok()));

            ToogleRossarySelectionCommandHandler handler = _fixture.GetServiceUnderTest();
            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeTrue();
        }
    }
}
