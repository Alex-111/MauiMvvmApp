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
        builder.Services.AddTransient<NewPage3>();
        builder.Services.AddTransient<LayoutTest1>();
        builder.Services.AddTransient<NewPage1ViewModel>();
        builder.Services.AddTransient<NewPage2ViewModel>();
        builder.Services.AddTransient<EmptyViewModel>();
        builder.Services.AddTransient<MainPage>();

        builder.Services.AddSingleton<NavigationService>();

        Routing.RegisterRoute(nameof(NewPage2), typeof(NewPage2));
        Routing.RegisterRoute(nameof(NewPage3), typeof(NewPage3));

        return builder.Build();
	}
}

