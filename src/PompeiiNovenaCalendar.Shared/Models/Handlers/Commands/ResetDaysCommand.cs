using FluentResults;
using MediatR;

namespace PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

public record ResetDaysCommand : IRequest<Result>;
