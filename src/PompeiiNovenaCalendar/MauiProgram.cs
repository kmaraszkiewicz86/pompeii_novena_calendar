using Microsoft.Extensions.Logging;
using PompeiiNovenaCalendar.DependencyInjection;
using PompeiiNovenaCalendar.Extensions;

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
            .AddViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
