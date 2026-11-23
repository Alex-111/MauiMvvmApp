using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiAppDemo.ViewModels;

public partial class MainPageViewModel(NavigationService navigationService, IPopupService popupService)
    : BaseViewModel(navigationService)
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ShowToastCommand))]
    public partial string Message { get; set; } = "Hello from .NET 11!";

    private bool CanShowToast => !string.IsNullOrWhiteSpace(Message);

    [RelayCommand(CanExecute = nameof(CanShowToast))]
    private Task ShowToastAsync() => ShowToast(Message);

    [RelayCommand]
    private Task LongPressedAsync() => ShowToast("You long-pressed the .NET bot");

    [RelayCommand]
    private async Task ShowPopupAsync()
    {
        // Popups are displayed as modal pages, which triggers OnDisappearing (and cancels PageCancellationToken)
        // on this page, so the page token must not be used to wait for the popup result.
        var result = await popupService.ShowPopupAsync<ConfirmPopupViewModel, bool>(
            Shell.Current,
            PopupOptions.Empty,
            new Dictionary<string, object> { [nameof(ConfirmPopupViewModel.Message)] = Message });

        var text = result.WasDismissedByTappingOutsideOfPopup
            ? "Popup dismissed"
            : $"Popup result: {(result.Result ? "Yes" : "No")}";

        await ShowToast(text);
    }

    [RelayCommand]
    private async Task ThrowExceptionAsync()
    {
        try
        {
            await FailingOperationAsync();
        }
        catch (Exception ex)
        {
            await NavigationService.ShowAlert(ex);
        }
    }

    private static async Task FailingOperationAsync()
    {
        await Task.Delay(100);
        throw new InvalidOperationException("Demo exception thrown from MainPageViewModel.");
    }

    private async Task ShowToast(string text)
    {
        try
        {
            await Toast.Make(text, ToastDuration.Short, 16).Show(PageCancellationToken);
        }
        catch (OperationCanceledException)
        {
            // Page disappeared before the toast was shown
        }
    }
}
