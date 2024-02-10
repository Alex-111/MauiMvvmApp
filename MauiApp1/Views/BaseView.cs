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
        this.Unloaded += BaseView_Unloaded;
        this.vm = vm;
    }

    private void BaseView_Unloaded(object sender, EventArgs e)
    {
        vm.RunOnPageUnLoaded(); 
    }

    private void BaseView_Loaded(object sender, EventArgs e)
    {
        vm.RunOnPageLoaded();
    }

    protected override   void OnAppearing()
    {
       
        try
        {
            vm.RunOnAppearing();
            base.OnAppearing();
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }


    protected override   void OnDisappearing()
    {
        vm.RunOnDisappearing();
        base.OnDisappearing();
          
    }
}