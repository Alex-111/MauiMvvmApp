using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;

namespace MauiAppDemo;

public partial class MainPage : BaseView
{
	int count = 0;

	public MainPage(MainPageViewModel vm) : base(vm)
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object? sender, EventArgs e)
	{
		count++;

		CounterBtn.Text = count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

