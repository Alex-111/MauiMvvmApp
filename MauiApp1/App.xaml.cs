using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.Message;
using System.Diagnostics;

namespace MauiApp1;

public partial class App : Application
{
    public App(AppShell shell)
    {
        InitializeComponent();

        MainPage = shell;
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
