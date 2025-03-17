using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IRosaryTypesQuery : IQuery
    {
        Task<RosaryType[]> GetAllRosaryTypesAsync();
    }
}
