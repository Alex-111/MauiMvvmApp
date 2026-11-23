namespace MauiAppDemo.Wizard.Core;

/// <summary>
/// A simple multi page wizard, shown as normal pages on the Shell navigation stack.
/// - All pages share one <see cref="Data"/> object.
/// - <see cref="NextPage"/> decides which page follows (or null when the wizard is done).
/// - <see cref="RunAsync"/> returns the data when finished, or null when cancelled.
/// </summary>
public abstract class WizardBase<TData>(IServiceProvider services) where TData : class, new()
{
    private TaskCompletionSource<TData?> _completion = new();
    private TData? _result;

    public TData Data { get; private set; } = new();

    protected abstract Type FirstPage { get; }

    protected abstract Type? NextPage(WizardStepViewModel<TData> currentStep);

    private static INavigation Navigation => Shell.Current.Navigation;

    public async Task<TData?> RunAsync()
    {
        Data = new();
        _result = null;
        _completion = new();

        await ShowPageAsync(FirstPage);
        return await _completion.Task;
    }

    public Task NextAsync(WizardStepViewModel<TData> currentStep)
    {
        var nextPage = NextPage(currentStep);
        return nextPage is null ? CloseAsync(Data) : ShowPageAsync(nextPage);
    }

    /// <summary>Closes the wizard. <see cref="RunAsync"/> returns <paramref name="result"/> (null = cancelled).</summary>
    public Task CloseAsync(TData? result)
    {
        _result = result;

        // Remove the wizard pages behind the current one, then go back to the page that started the wizard
        foreach (var page in Navigation.NavigationStack.Where(IsWizardPage).SkipLast(1).ToList())
            Navigation.RemovePage(page);

        return Navigation.PopAsync();
    }

    private Task ShowPageAsync(Type pageType)
    {
        var page = (Page)services.GetRequiredService(pageType);
        page.NavigatedFrom += OnPageNavigatedFrom;
        return Navigation.PushAsync(page);
    }

    // The wizard is over as soon as the user leaves its pages: by Finish, Cancel or Back on the first page
    private void OnPageNavigatedFrom(object? sender, NavigatedFromEventArgs e)
    {
        if (!IsWizardPage(e.DestinationPage))
            _completion.TrySetResult(_result);
    }

    private static bool IsWizardPage(Page? page) => page?.BindingContext is WizardStepViewModel<TData>;
}
