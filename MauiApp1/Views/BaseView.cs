using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class BaseView   : ContentPage  
{
    private readonly BaseViewModel  vm;

    public BaseView(BaseViewModel vm)
    {
        this.BindingContext = vm;
        //InitializeComponent();
        this.Loaded += BaseView_Loaded;
        this.vm = vm;
    }

    private async void BaseView_Loaded(object sender, EventArgs e)
    {
        await vm.OnPageLoadedAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.OnAppearingAsync();
    }


    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await vm.OnDisappearingAsync();
    }
}