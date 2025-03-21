using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PompeiiNovenaCalendar.ApplicationLayer.Handlers.Commands;
using PompeiiNovenaCalendar.ApplicationLayer.Validators;
using PompeiiNovenaCalendar.Domain.Database;
using PompeiiNovenaCalendar.Domain.Database.Repositories;
using PompeiiNovenaCalendar.Domain.Models;
using PompeiiNovenaCalendar.Domain.Services.Interfaces;
using PompeiiNovenaCalendar.Infrastructure.Database;
using PompeiiNovenaCalendar.Infrastructure.Database.DatabaseQueries;
using PompeiiNovenaCalendar.Infrastructure.Database.Repositories;

namespace PompeiiNovenaCalendar.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDatabaseLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddSingleton<IAppDbQueryContext>(provider => new AppDbQueryContext(connectionString));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddClassesToDependencyInjection(typeof(IQuery), typeof(DayRecordQuery).Assembly);
            services.AddClassesToDependencyInjection(typeof(IRepository), typeof(DayRecordRepository).Assembly);

            return services;
        }

        public static IServiceCollection AddCqrsHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ToogleRossarySelectionCommandHandler).Assembly);
            });

            return services;
        }

        public static IServiceCollection ConfigureDefaultLanguage(this IServiceCollection services, string language)
        {
            services.AddScoped(services =>
            {
                return new LanguageSettings(language);
            });

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<GenerateInialDataCommandValidator>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddClassesToDependencyInjection(typeof(IService));

            return services;
        }

        private static IServiceCollection AddClassesToDependencyInjection(this IServiceCollection services, Type type, Assembly? assembly = null)
        {
            if (assembly is null)
                assembly = type.Assembly;

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
