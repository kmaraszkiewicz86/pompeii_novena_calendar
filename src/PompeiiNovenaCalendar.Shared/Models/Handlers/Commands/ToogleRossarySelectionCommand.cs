using FluentResults;
using MediatR;

namespace PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

public record ToogleRossarySelectionCommand(int DayId, int RosaryId, bool IsChecked) : IRequest<Result>;