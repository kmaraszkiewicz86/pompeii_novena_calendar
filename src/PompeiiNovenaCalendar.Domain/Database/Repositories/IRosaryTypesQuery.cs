using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Models;

namespace PompeiiNovenaCalendar.Domain.Database.Repositories
{
    public interface IRosaryTypesQuery : IQuery
    {
        Task<RosaryTypeModel[]> GetAllRosaryTypesAsync(string language);
    }
}
