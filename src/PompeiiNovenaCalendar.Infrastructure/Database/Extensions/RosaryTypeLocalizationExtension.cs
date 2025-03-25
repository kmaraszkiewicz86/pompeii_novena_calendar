using Dapper;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Entities;

namespace PompeiiNovenaCalendar.Infrastructure.Database.Extensions
{
    public static class RosaryTypeLocalizationExtension
    {
        public static async Task<Dictionary<string, string>> GetRosaryTypeLocalization(this ISqliteConnectionConnection connection, string language)
        {
            return (await connection.Connection.QueryAsync<RosaryTypeLocalization>(
                "SELECT * FROM RosaryTypeLocalizations WHERE Language = @Language",
                new { Language = language }
            )).ToDictionary(r => r.Key, r => r.Name);
        }
    }
}
