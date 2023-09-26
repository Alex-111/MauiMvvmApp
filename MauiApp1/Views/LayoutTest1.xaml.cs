namespace MauiApp1.Views;

public partial class LayoutTest1 : ContentPage
{
    public LayoutTest1()
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