using FluentResults;
using MediatR;

namespace PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

public record GenerateInialDataCommand(DateTime fromDate) : IRequest<Result>;