using CommunityToolkit.Maui;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif



		builder.Services.AddTransient<AppShell>();
        builder.Services.AddTransient<NewPage1>();
        builder.Services.AddTransient<NewPage2>();
        builder.Services.AddTransient<NewPage1ViewModel>();
        builder.Services.AddTransient<NewPage2ViewModel>();

        builder.Services.AddSingleton<NavigationService>();

        Routing.RegisterRoute(nameof(NewPage2), typeof(NewPage2));	

        return builder.Build();
	}
}
