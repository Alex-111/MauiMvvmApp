using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MauiApp1;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    Exported = true,
    //LaunchMode = Android.Content.PM.LaunchMode.SingleTask,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
//[IntentFilter(
//    [Intent.ActionView],
//    Categories = [Intent.CategoryDefault, Intent.CategoryBrowsable],
//    DataScheme = "MauiApp",
    
//    AutoVerify = true)]
public class MainActivity : MauiAppCompatActivity
{
}
