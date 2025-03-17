using Dapper;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class RosaryTypesQuery(IAppDbQueryContext queryContext) : IRosaryTypesQuery
    {
        public async Task<RosaryType[]> GetAllRosaryTypesAsync()
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();
            return [.. await connection.Connection.QueryAsync<RosaryType>("SELECT Id, Name FROM RosaryTypes")];
        }
    }
}
