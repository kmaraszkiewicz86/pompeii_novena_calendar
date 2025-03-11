using FluentResults;
using MediatR;

namespace PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

public record SaveRosarySelectionCommand(int Id, int RosaryId, bool IsChecked) : IRequest<Result>;