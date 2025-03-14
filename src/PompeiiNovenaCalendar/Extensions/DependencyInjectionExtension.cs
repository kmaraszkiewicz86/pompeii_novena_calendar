using PompeiiNovenaCalendar.Presentation.ViewModels;
using PompeiiNovenaCalendar.Presentation.Views;

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

        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            services.AddTransient<DaysListPage>();
            services.AddTransient<StartPage>();

            return services;
        }
    }
}
