using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Message;

namespace MauiAppDemo.ViewModels;

public abstract partial class BaseViewModel(NavigationService navigationService)
    : ObservableRecipient, IRecipient<OperatingSystemEvent>
{
    private CancellationTokenSource? _cancellationTokenSource;

    protected NavigationService NavigationService { get; } = navigationService;

    /// <summary>
    /// Token that is canceled as soon as the page disappears.
    /// </summary>
    protected CancellationToken PageCancellationToken => _cancellationTokenSource?.Token ?? CancellationToken.None;

    [ObservableProperty]
    public partial bool IsBusy { get; set; }

    public Task RunOnPageLoaded() => OnPageLoadedAsync(PageCancellationToken);

    public Task RunOnPageUnLoaded() => OnPageUnLoadedAsync(PageCancellationToken);

    public async Task RunOnAppearing()
    {
        IsActive = true;
        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = new CancellationTokenSource();
        await OnAppearingAsync(_cancellationTokenSource.Token);
    }

    public async Task RunOnDisappearing()
    {
        try
        {
            if (_cancellationTokenSource is not null)
                await _cancellationTokenSource.CancelAsync();

            await OnDisappearingAsync();
        }
        finally
        {
            IsActive = false;
        }
    }

    public virtual Task OnSleepAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public virtual Task OnResumeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public virtual Task OnPageLoadedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public virtual Task OnPageUnLoadedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public virtual Task OnAppearingAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public virtual Task OnDisappearingAsync() => Task.CompletedTask;

    public async void Receive(OperatingSystemEvent message)
    {
        try
        {
            var task = message.Value switch
            {
                OperatingSystemEventType.OnSleep => OnSleepAsync(PageCancellationToken),
                OperatingSystemEventType.OnResume => OnResumeAsync(PageCancellationToken),
                _ => Task.CompletedTask
            };

            await task;
        }
        catch (Exception ex)
        {
            await NavigationService.ShowAlert(ex);
        }
    }
}
