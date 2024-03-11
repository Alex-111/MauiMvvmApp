using CommunityToolkit.Maui;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using MauiApp3;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

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
            }).ConfigureLifecycleEvents(lifecycle =>
            {
#if ANDROID
                lifecycle.AddAndroid(android =>
                {
                    android.OnCreate((activity, bundle) =>
                    {
                        var action = activity.Intent?.Action;
                        var data = activity.Intent?.Data?.ToString();
                        
                        if (action == Android.Content.Intent.ActionView && data is not null/* && activity is MainActivity main*/)
                        {
                             
                            activity.Finish();
                            Task.Run(() => HandleAppLink(data));
                        }

                    });
                });
#endif
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

        var app = builder.Build();

        MauiServiceProvider.Initialize(app.Services);

        return app;

        
    }

    static void HandleAppLink(string url)
    {
        if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri))
            App.Current?.SendOnAppLinkRequestReceived(uri);
    }
}

