using AutoFixture;
using FluentResults;
using NSubstitute;
using PompeiiNovenaCalendar.Application.Tests.Fixtures;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;
using Shouldly;

namespace PompeiiNovenaCalendar.Application.Tests.Handlers.Commands
{
    public class GenerateInialDataCommandHandlerTests
    {
        private readonly GenerateInialDataCommandHandlerFixture _fixture = new();

        [Fact]
        public async Task HandleAsync_WhenQueryIsValid_ShouldReturnsInvalidResult()
        {
            // Arrange

            GenerateInialDataCommandHandler handler = _fixture.GetServiceUnderTest();
            GenerateInialDataCommand command = new (default);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.ShouldBeTrue();
        }

        [Fact]
        public async Task HandleAsync_WhenValidationSuccess_ShouldCallGenerateInitialDataAsyncMethod()
        {
            // Arrange
            GenerateInialDataCommandHandler handler = _fixture.GetServiceUnderTest();
            GenerateInialDataCommand command = new(DateTime.Now);
            var service = _fixture.Freeze<INovennaDaysGenerator>();

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            await service.Received(1).GenerateInitialDataAsync(command);
        }

        [Fact]
        public async Task HandleAsync_WhenValidationSuccess_ShouldReturnValidResult()
        {
            // Arrange
            GenerateInialDataCommandHandler handler = _fixture.GetServiceUnderTest();
            GenerateInialDataCommand command = new(DateTime.Now);
            _fixture.Freeze<INovennaDaysGenerator>().GenerateInitialDataAsync(command).Returns(Result.Ok());

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.ShouldBeTrue();
        }
    }
}
