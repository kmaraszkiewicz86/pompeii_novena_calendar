using FluentResults;

namespace PompeiiNovenaCalendar.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<Result> SaveChangesAsync();
    }
}
