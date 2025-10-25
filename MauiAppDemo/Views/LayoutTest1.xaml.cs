using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views;

public partial class LayoutTest1: BaseView 
{
    public LayoutTest1(EmptyViewModel vm) : base(vm)
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //Without Dispatcher Focus() fails...
        Dispatcher.Dispatch(() =>
        {
            myEntry.CursorPosition = 0;
            myEntry.SelectionLength = myEntry.Text.Length;
            myEntry.Focus();
        });

    }
 
}