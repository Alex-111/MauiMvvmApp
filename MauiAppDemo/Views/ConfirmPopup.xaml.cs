using CommunityToolkit.Maui.Views;
using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views;

public partial class ConfirmPopup : Popup<bool>
{
    public ConfirmPopup(ConfirmPopupViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
