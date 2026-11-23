using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Views;

namespace MauiAppDemo.ViewModels;

public partial class NewPage2ViewModel(NavigationService navigationService)
    : BaseViewModel<NewPage2Parameter>(navigationService)
{
    [ObservableProperty]
    public partial int Count { get; set; }

    [RelayCommand]
    private Task OpenNextPage2Async() =>
        NavigationService.NavigateAsync(nameof(NewPage2), new NewPage2Parameter(Count + 1));

    [RelayCommand]
    private Task GoHomeAsync() => NavigationService.NavigateAsync($"//{nameof(MainPage)}");

    [RelayCommand]
    private Task GoHomeAndClearStackAsync()
    {
        NavigationService.ClearStack();
        return NavigationService.NavigateAsync($"//{nameof(MainPage)}");
    }

    [RelayCommand]
    private Task OpenModalPage3Async() => NavigationService.PushModalAsync<NewPage3>();

    [RelayCommand]
    private void ClearStack() => NavigationService.ClearStack();

    public override async Task OnAppearingAsync(NewPage2Parameter? parameter, CancellationToken cancellationToken)
    {
        await base.OnAppearingAsync(parameter, cancellationToken);
        Count = parameter?.Count ?? 0;
    }
}
