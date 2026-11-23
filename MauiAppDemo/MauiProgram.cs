using CommunityToolkit.Maui;
using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;
using Microsoft.Extensions.Logging;

namespace MauiAppDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Toast/Snackbar must be opted in explicitly on Windows (CommunityToolkit.Maui 17+)
            .UseMauiCommunityToolkit(options => options.SetShouldEnableSnackbarOnWindows(true))
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<NavigationService>();

        // CommunityToolkit.Maui helpers register the page together with its view model (and Shell route)
        builder.Services.AddTransient<MainPage, MainPageViewModel>();
        builder.Services.AddTransient<NewPage1, NewPage1ViewModel>();
        builder.Services.AddTransientWithShellRoute<NewPage2, NewPage2ViewModel>(nameof(NewPage2));
        builder.Services.AddTransientWithShellRoute<NewPage3, EmptyViewModel>(nameof(NewPage3));
        builder.Services.AddTransient<LayoutTest1>();

        builder.Services.AddTransientPopup<ConfirmPopup, ConfirmPopupViewModel>();

        return builder.Build();
    }
}
