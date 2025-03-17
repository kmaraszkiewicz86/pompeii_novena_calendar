using FluentResults;
using MediatR;

namespace PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

public record ToogleRossarySelectionCommand(int Id, int DayId) : IRequest<Result>;