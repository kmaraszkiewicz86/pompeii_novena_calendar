using Dapper;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Entities;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Infrastructure.Database.Extensions;

namespace PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries
{
    public class RosaryTypesQuery(IAppDbQueryContext queryContext) : IRosaryTypesQuery
    {
        public async Task<RosaryTypeModel[]> GetAllRosaryTypesAsync(string language)
        {
            await using ISqliteConnectionConnection connection = await queryContext.CreateConnectionAsync();
            RosaryType[] rosaries = [.. await connection.Connection.QueryAsync<RosaryType>("SELECT Id, Key FROM RosaryTypes")];

            Dictionary<string, string> languageDictionary = await connection.GetRosaryTypeLocalization(language);

            return [.. rosaries.Select(r => new RosaryTypeModel
            {
                Id = r.Id,
                Name = languageDictionary[r.Key]
            })];
        }
    }
}
