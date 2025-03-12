using PompeiiNovenaCalendar.Presentation.ViewModels;

namespace PompeiiNovenaCalendar.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<StartViewModel>();
            services.AddScoped<DayListViewModel>();

            return services;
        }
    }
}
