using System.Diagnostics;

namespace MauiApp1;

public partial class App : Application
{
	public App(AppShell shell)
	{
		InitializeComponent();

		MainPage = shell;

       

    }

    private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    {
        Debug.WriteLine(e.Exception.ToString());
    }
}
