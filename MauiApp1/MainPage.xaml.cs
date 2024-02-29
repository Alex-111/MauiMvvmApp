using MauiApp1.Message;
using MauiApp1.ViewModels;
using MauiApp1.Views;

namespace MauiApp1;

public partial class MainPage : BaseView
{
	int count = 0;

	public MainPage(EmptyViewModel vm) : base(vm)
	{
		InitializeComponent();
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);	
    }
    private void OnCounterClicked(object sender, EventArgs e)
	{

		var stack = Navigation.NavigationStack;
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    
}

