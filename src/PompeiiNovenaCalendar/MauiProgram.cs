using Microsoft.Extensions.Logging;
using PompeiiNovenaCalendar.Shared.DependencyInjection;

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

		builder.Services.AddAppDbContext("Data Source=app.db");

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
