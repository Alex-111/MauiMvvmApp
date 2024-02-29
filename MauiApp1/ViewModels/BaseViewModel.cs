using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class BaseViewModel : ObservableRecipient
    {
        private CancellationTokenSource _cancellationTokenSource;

        public BaseViewModel() : base()
        {
        }

        public async Task RunOnPageLoaded()
        {
            await OnPageLoadedAsync(_cancellationTokenSource?.Token ?? new CancellationToken());
        }
        public async Task RunOnPageUnLoaded()
        {
            await OnPageUnLoadedAsync(_cancellationTokenSource?.Token ?? new CancellationToken());
        }
        public async Task RunOnAppearing()
        {
            IsActive = true;
            _cancellationTokenSource = new CancellationTokenSource();
            await OnAppearingAsync(_cancellationTokenSource.Token);
        }

        public async Task RunOnDisappearing()
        {
            try
            {
                this._cancellationTokenSource.Cancel();
                await OnDisappearingAsync();
            }
            finally
            {
                IsActive = false;

            }
        }

        public async Task RunOnSleep()
        {
            await OnSleepAsync(_cancellationTokenSource?.Token ?? default);
        }

        public virtual async Task OnSleepAsync(CancellationToken cancellationToken)
        {
        }

        public async Task RunOnResume()
        {
            await OnResumeAsync(_cancellationTokenSource?.Token ?? default);
        }

        public virtual async Task OnResumeAsync(CancellationToken cancellationToken)
        {
        }

        public virtual async Task OnPageLoadedAsync(CancellationToken cancellationToken)
        {
        }

        public virtual async Task OnPageUnLoadedAsync(CancellationToken cancellationToken)
        {
        }

        public virtual async Task OnAppearingAsync(CancellationToken cancellationToken)
        {
            Debug.WriteLine("OnAppearing: " + this.ToString());
        }

        public virtual async Task OnDisappearingAsync()
        {
            Debug.WriteLine("OnDisappearing: " + this.ToString());
        }
    }
}
