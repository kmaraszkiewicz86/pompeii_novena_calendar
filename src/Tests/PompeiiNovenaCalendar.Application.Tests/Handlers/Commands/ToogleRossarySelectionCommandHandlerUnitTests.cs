using AutoFixture;
using FluentResults;
using NSubstitute;
using PompeiiNovenaCalendar.Application.Tests.Fixtures;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;
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
            ToogleRossarySelectionCommand query = new(-1, -1);
            var service = _fixture.Freeze<IToogleRossarySelectionService>();
            service.SaveAsync(query).Returns(Task.FromResult(Result.Fail("test")));

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
            ToogleRossarySelectionCommand query = new(1, 1);
            var service = _fixture.Freeze<IToogleRossarySelectionService>();
            service.SaveAsync(query).Returns(Task.FromResult(Result.Fail("test")));

            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeFalse();
        }

        [Fact]
        public async Task HandleAsync_WhenValidationSuccess_ShouldReturnValidResult()
        {
            // Arrange
            ToogleRossarySelectionCommand query = new(1, 1);
            var service = _fixture.Freeze<IToogleRossarySelectionService>();
            service.SaveAsync(query).Returns(Task.FromResult(Result.Ok()));

            ToogleRossarySelectionCommandHandler handler = _fixture.GetServiceUnderTest();
            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeTrue();
        }
    }
}
