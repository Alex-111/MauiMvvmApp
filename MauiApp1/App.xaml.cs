using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.Message;
using MauiApp1.Views;
using MauiApp3;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace MauiApp1;

public partial class App : Application
{
    public App(AppShell shell)
    {
        InitializeComponent();
        MainPage = shell;
    }

    protected override async void OnAppLinkRequestReceived(Uri uri)
    {
        base.OnAppLinkRequestReceived(uri);

        // Show an alert to test that the app link was received.
        //await Dispatcher.DispatchAsync(async () =>
        //{

        // MainPage = MauiServiceProvider.GetService<NewPage1>();



        //});

        Console.WriteLine("App link: " + uri.ToString());
    }

    protected override void OnSleep()
    {
        WeakReferenceMessenger.Default.Send(new OperatingSystemEvent(OperatingSystemEventType.OnSleep));
        base.OnSleep();
    }


    protected override void OnResume()
    {
        WeakReferenceMessenger.Default.Send(new OperatingSystemEvent(OperatingSystemEventType.OnResume));
        base.OnResume();
    }


    private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    {
        Debug.WriteLine(e.Exception.ToString());
    }
}
