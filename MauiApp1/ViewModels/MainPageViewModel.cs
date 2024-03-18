using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        CancellationToken _cancellationToken = default;

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
