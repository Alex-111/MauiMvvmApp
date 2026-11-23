using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Message;
using System.Diagnostics;

namespace MauiAppDemo;

public partial class App : Application
{
    private readonly AppShell shell;

    public App(AppShell shell)
    {
        InitializeComponent();
        this.shell = shell;
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    }

    protected override Window CreateWindow(IActivationState? activationState) => new(shell);

    protected override void OnAppLinkRequestReceived(Uri uri)
    {
        base.OnAppLinkRequestReceived(uri);
        Debug.WriteLine($"App link: {uri}");
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

    private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        Debug.WriteLine(e.Exception.ToString());
    }
}
