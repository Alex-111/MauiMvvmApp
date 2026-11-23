using MauiAppDemo.ViewModels;

namespace MauiAppDemo;

public class NavigationService(IServiceProvider services)
{
    private const string ParameterKey = "P";

    private static Shell CurrentShell =>
        Shell.Current ?? throw new InvalidOperationException("No active Shell is available for navigation.");

    public Task ShowAlert(Exception ex) =>
        CurrentShell.DisplayAlertAsync("Error", ex.ToString(), "OK");

    public Task NavigateAsync(string path) =>
        NavigateAsync<ViewModelParameterBase>(path, null);

    public Task NavigateAsync<T>(string path, T? parameter = null) where T : class =>
        CurrentShell.GoToAsync(path, new Dictionary<string, object?> { [ParameterKey] = parameter });

    public Task PushModalAsync<TPage>() where TPage : Page =>
        CurrentShell.Navigation.PushModalAsync(services.GetRequiredService<TPage>());

    public Task PopModalAsync() =>
        CurrentShell.Navigation.PopModalAsync();

    public Task ResetToHome() =>
        CurrentShell.Navigation.PopToRootAsync(true);

    /// <summary>
    /// Unfortunately the OnAppearing runs for the root page after executing this
    /// </summary>
    public void ClearStack()
    {
        var navigation = CurrentShell.Navigation;

        foreach (var page in navigation.NavigationStack.ToList())
        {
            if (page is not null)
                navigation.RemovePage(page);
        }
    }
}
