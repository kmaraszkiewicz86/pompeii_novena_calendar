using FluentResults;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<Result> SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

            return Result.Ok();
        }
    }
}
