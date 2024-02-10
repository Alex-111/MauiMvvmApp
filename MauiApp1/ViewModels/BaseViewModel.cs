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
    public   class BaseViewModel  : ObservableRecipient, IRecipient<OperatingSystemEvent>
    {
        private CancellationTokenSource _cancellationTokenSource ;

        public BaseViewModel() : base() 
        {
           
        }

        public async void RunOnPageLoaded()
        {
            await OnPageLoadedAsync(_cancellationTokenSource?.Token ?? new CancellationToken());
        }
        public async void RunOnPageUnLoaded()
        {
            await OnPageUnLoadedAsync(_cancellationTokenSource?.Token ?? new CancellationToken());
        }
        public async void RunOnAppearing()
        {
            IsActive = true;
            _cancellationTokenSource = new CancellationTokenSource();
            await OnAppearingAsync(_cancellationTokenSource.Token);
        }

        public async void RunOnDisappearing()
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

        public virtual void OnSleep()
        {

        }

        public virtual void OnResume()
        {

        }

        public virtual async Task OnPageLoadedAsync(CancellationToken cancellationToken  )
        {

        }

        public virtual async Task OnPageUnLoadedAsync(CancellationToken cancellationToken)
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

        public async void Receive(OperatingSystemEvent message)
        {
            //Shell.Current.DisplayAlert("Message received", message.Value.ToString() , "OK" );

            switch (message.Value)
            {
                case OperatingSystemEventType.OnSleep:
                    OnSleep();
                    break;
                case OperatingSystemEventType.OnResume:
                    OnResume();
                    break;
                default:
                    break;
            }

            
        }
    }
}
