namespace MauiApp1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }

   
    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        
        

        //if (args.Source == ShellNavigationSource.ShellItemChanged)
        //{
        //    var navigation = Shell.Current?.Navigation;

        //    if (navigation != null)
        //    {
        //        var pages = navigation.NavigationStack;
        //        for (var i = pages.Count - 1; i >= 1; i--)
        //        {
        //            navigation.RemovePage(pages[i]);
                   
        //        }
        //    }

        //}
        base.OnNavigating(args);
    }
    public void SetMainPage()
    {

        CurrentItem = MainPage;
    }
}
