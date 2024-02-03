using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class BaseViewModel  : ObservableObject 
    {
        private CancellationTokenSource _cancellationTokenSource ;


        public async void RunOnPageLoaded()
        {
            await OnPageLoadedAsync(_cancellationTokenSource?.Token ?? new CancellationToken());
        }
        public async void RunOnAppearing()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            await OnAppearingAsync(_cancellationTokenSource.Token);
        }

        public async void RunOnDisappearing()
        {
            this._cancellationTokenSource.Cancel();
            await OnDisappearingAsync();
        }

        public virtual async Task OnPageLoadedAsync(CancellationToken cancellationToken  )
        {

        }
        public virtual async Task OnAppearingAsync(CancellationToken cancellationToken  )
        {
            Debug.WriteLine("OnAppearing: " + this.ToString());
        }

        public virtual async Task OnDisappearingAsync()
        {
            Debug.WriteLine("OnDisappearing: " + this.ToString());
        }


    }
}
