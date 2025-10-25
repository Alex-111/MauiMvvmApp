using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppDemo.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        CancellationToken _cancellationToken = default;

        //[ObservableProperty]
        //public partial string MyProperty { get; set; }

        [RelayCommand]
        private async Task Button2Press()
        {

            IToast toast = Toast.Make("test", ToastDuration.Short, 20);
            await toast.Show(_cancellationToken);

            //var sb = Snackbar.Make("test");
            //await sb.Show();
        }

        public MainPageViewModel(NavigationService navigationService) : base(navigationService) 
        {
                
        }

        public override Task OnAppearingAsync(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            return base.OnAppearingAsync(cancellationToken);
        }
    }
}
