using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Wizard.Core;

/// <summary>
/// Base view model for every wizard page: gives derived view models the shared data and the page the Next/Cancel commands.
/// </summary>
public abstract partial class WizardStepViewModel<TData>(NavigationService navigationService, WizardBase<TData> wizard)
    : BaseViewModel(navigationService)
    where TData : class, new()
{
    protected TData Data => wizard.Data;

    [RelayCommand]
    private Task NextAsync() => wizard.NextAsync(this);

    [RelayCommand]
    private Task CancelAsync() => wizard.CloseAsync(null);
}
