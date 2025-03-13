using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PompeiiNovenaCalendar.DependencyInjection;
using PompeiiNovenaCalendar.Extensions;
using PompeiiNovenaCalendar.Infrastructure.Database;

namespace PompeiiNovenaCalendar;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.ConfigureDatabaseLogic("Data Source=app.db")
			.AddCqrsHandlers()
			.AddViewModels()
			.AddServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        // Tworzenie bazy i stosowanie migracji
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }

        return app;
    }
}
