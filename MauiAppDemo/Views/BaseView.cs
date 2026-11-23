using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views;

public partial class BaseView : ContentPage
{
    private readonly BaseViewModel vm;

    public BaseView(BaseViewModel vm)
    {
        BindingContext = this.vm = vm;
        Loaded += BaseView_Loaded;
        Unloaded += BaseView_Unloaded;
    }

    private async void BaseView_Unloaded(object? sender, EventArgs e) =>
        await RunSafeAsync(vm.RunOnPageUnLoaded);

    private async void BaseView_Loaded(object? sender, EventArgs e) =>
        await RunSafeAsync(vm.RunOnPageLoaded);

    protected override async void OnAppearing()
    {
        await RunSafeAsync(async () =>
        {
            await vm.RunOnAppearing();
            base.OnAppearing();
        });
    }

    protected override async void OnDisappearing()
    {
        await RunSafeAsync(async () =>
        {
            await vm.RunOnDisappearing();
            base.OnDisappearing();
        });
    }

    private async Task RunSafeAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", ex.ToString(), "OK");
        }
    }
}
