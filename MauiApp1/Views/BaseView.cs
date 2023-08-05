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

    private void BaseView_Loaded(object sender, EventArgs e)
    {
        vm.RunOnPageLoaded();
    }

    protected override   void OnAppearing()
    {
        base.OnAppearing();
        vm.RunOnAppearing( );
    }


    protected override   void OnDisappearing()
    {
        
        base.OnDisappearing();
          vm.RunOnDisappearing();
    }
}