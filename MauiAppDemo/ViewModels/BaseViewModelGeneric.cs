namespace MauiAppDemo.ViewModels;

public abstract class BaseViewModel<T>(NavigationService navigationService)
    : BaseViewModel(navigationService), IQueryAttributable where T : class
{
    private T? _parameter;

    public sealed override Task OnAppearingAsync(CancellationToken cancellationToken) =>
        OnAppearingAsync(_parameter, cancellationToken);

    public sealed override Task OnPageLoadedAsync(CancellationToken cancellationToken) =>
        OnPageLoadedAsync(_parameter, cancellationToken);

    public virtual Task OnPageLoadedAsync(T? parameter, CancellationToken cancellationToken) => Task.CompletedTask;

    public virtual Task OnAppearingAsync(T? parameter, CancellationToken cancellationToken) =>
        base.OnAppearingAsync(cancellationToken);

    public void ApplyQueryAttributes(IDictionary<string, object?> query)
    {
        _parameter = query?.Values.FirstOrDefault() as T;
    }
}
