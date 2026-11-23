// Map the app namespaces into the .NET MAUI global XAML namespace so they can be
// used in XAML without any xmlns prefix (combined with implicit XAML namespaces in .NET 11).
[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "MauiAppDemo")]
[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "MauiAppDemo.Views")]
[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "MauiAppDemo.ViewModels")]
[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "MauiAppDemo.Wizard.Core")]
[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "MauiAppDemo.Wizard.Demo")]
