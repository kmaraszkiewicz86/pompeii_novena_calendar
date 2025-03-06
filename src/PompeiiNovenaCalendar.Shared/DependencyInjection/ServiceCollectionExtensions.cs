using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PompeiiNovenaCalendar.Infrastructure.Database;

namespace PompeiiNovenaCalendar.Shared.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

            return services;
        }
    }
}
