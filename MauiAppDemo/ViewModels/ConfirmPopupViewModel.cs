using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiAppDemo.ViewModels;

public partial class ConfirmPopupViewModel(IPopupService popupService) : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    public partial string Message { get; set; } = string.Empty;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(nameof(Message), out var message))
            Message = message as string ?? string.Empty;
    }

    [RelayCommand]
    private Task ConfirmAsync() => popupService.ClosePopupAsync(Shell.Current, true);

    [RelayCommand]
    private Task CancelAsync() => popupService.ClosePopupAsync(Shell.Current, false);
}
