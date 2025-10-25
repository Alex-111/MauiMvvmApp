using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MauiAppDemo.ViewModels
{
    public abstract class BaseViewModel : ObservableRecipient, IRecipient<OperatingSystemEvent>
    {
        private CancellationTokenSource? _cancellationTokenSource;
        protected readonly NavigationService NavigationService;
        public BaseViewModel(NavigationService navigationService) : base()
        {
            NavigationService = navigationService;
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
                this._cancellationTokenSource?.Cancel();
                await OnDisappearingAsync();
            }
            finally
            {
                IsActive = false;

            }
        }



        public virtual Task OnSleepAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task OnResumeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task OnPageLoadedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task OnPageUnLoadedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task OnAppearingAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task OnDisappearingAsync() => Task.CompletedTask;




        public async void Receive(OperatingSystemEvent message)
        {

            try
            {
                switch (message.Value)
                {
                    case OperatingSystemEventType.OnSleep:
                        await OnSleepAsync(_cancellationTokenSource?.Token ?? default);
                        break;
                    case OperatingSystemEventType.OnResume:
                        await OnResumeAsync(_cancellationTokenSource?.Token ?? default);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await NavigationService.ShowAlert(ex);

            }

        }

    }
}
