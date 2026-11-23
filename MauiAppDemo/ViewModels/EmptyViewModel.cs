using CommunityToolkit.Mvvm.Input;

namespace MauiAppDemo.ViewModels;

public partial class EmptyViewModel(NavigationService navigationService) : BaseViewModel(navigationService)
{
    [RelayCommand]
    private Task CloseModalAsync() => NavigationService.PopModalAsync();
}
