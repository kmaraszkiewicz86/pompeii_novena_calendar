using FluentResults;
using MediatR;

namespace PompeiiNovenaCalendar.Domain.Models.Commands;

public record SaveRosarySelectionCommand(int Id, int RosaryId, bool IsChecked) : IRequest<Result>;