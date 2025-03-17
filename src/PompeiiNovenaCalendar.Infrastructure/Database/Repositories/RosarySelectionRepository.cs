using FluentResults;
using Microsoft.EntityFrameworkCore;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Shared.Models.Handlers.Commands;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class RosarySelectionRepository(AppDbContext dbContext) : IRosarySelectionRepository
    {
        public async Task<Result> ToogleRossarySelectionAsync(ToogleRossarySelectionCommand command)
        {
            RosarySelection? selection = await dbContext.RosarySelections.FirstOrDefaultAsync(r => r.DayRecordId == command.DayId && r.RosaryTypeId == command.RosaryId);

            if (selection is null)
                return Result.Fail("No data found in databse");

            selection!.IsCompleted = !selection.IsCompleted;

            return Result.Ok();
        }
    }
}
