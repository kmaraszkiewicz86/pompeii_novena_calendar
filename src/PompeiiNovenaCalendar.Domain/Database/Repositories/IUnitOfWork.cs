using FluentResults;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IUnitOfWork
    {
        Task<Result> SaveChangesAsync();
    }
}
