using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PompeiiNovenaCalendar.Application.Handlers.Commands;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Infrastructure.Database;

namespace PompeiiNovenaCalendar.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDatabaseLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddTransient<IAppDbQueryContext>(sp => new AppDbQueryContext(connectionString));

            services.AddClassesToDependencyInjection(typeof(IQuery));
            services.AddClassesToDependencyInjection(typeof(IRepository));

            return services;
        }

        public static IServiceCollection AddCqrsHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(SaveRosarySelectionCommandHandler).Assembly);
            });

            return services;
        }

        private static IServiceCollection AddClassesToDependencyInjection(this IServiceCollection services, Type type)
        {
            var assembly = type.Assembly;

            var types = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false }
                            && t.GetInterfaces().Contains(type))
                .ToList();

            foreach (var implementationType in types)
            {
                var interfaceType = implementationType.GetInterfaces().First(i => i != type);

                services.AddScoped(interfaceType, implementationType);
            }

            return services;
        }
    }
}
