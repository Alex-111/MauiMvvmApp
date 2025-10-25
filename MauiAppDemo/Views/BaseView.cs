using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Message;
using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class BaseView   : ContentPage 
{
    private readonly BaseViewModel  vm;

    public BaseView(BaseViewModel vm)
    {
        this.BindingContext = vm;
        //InitializeComponent();
        this.Loaded += BaseView_Loaded;
        this.Unloaded += BaseView_Unloaded;
        this.vm = vm;
    }

    private async void BaseView_Unloaded(object? sender, EventArgs e)
    {
        try
        {
            await vm.RunOnPageUnLoaded();
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", ex.ToString(), "OK");
        }
    }

    private async void BaseView_Loaded(object? sender, EventArgs e)
    {
        try
        {
            await vm.RunOnPageLoaded();
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", ex.ToString(), "OK");
        }
    }

    protected override async void OnAppearing()
    {
       
        try
        {
            await vm.RunOnAppearing();
            base.OnAppearing();
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", ex.ToString(), "OK");
        }
    }


    protected override async  void OnDisappearing()
    {
        try
        {
            await vm.RunOnDisappearing();
            base.OnDisappearing();
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", ex.ToString(), "OK");
        }
    }

   
}