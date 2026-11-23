using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Views;

namespace MauiAppDemo.ViewModels;

public partial class NewPage1ViewModel(NavigationService navigationService) : BaseViewModel(navigationService)
{
    [RelayCommand]
    private Task NavigateToPage2Async() => NavigationService.NavigateAsync(nameof(NewPage2));
}
