using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class NewPage1 : BaseView 
{
	public NewPage1(NewPage1ViewModel vm) : base(vm)
	{
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}