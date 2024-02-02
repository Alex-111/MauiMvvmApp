using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class BaseViewModel  : ObservableObject 
    {
        public  CancellationTokenSource cancellationTokenSource => new CancellationTokenSource();


        public async void RunOnPageLoaded()
        {
            await OnPageLoadedAsync(cancellationTokenSource.Token);
        }
        public async void RunOnAppearing()
        {
            await OnAppearingAsync(cancellationTokenSource.Token);
        }

        public async void RunOnDisappearing()
        {
            this.cancellationTokenSource.Cancel();
            await OnDisappearingAsync();
        }

        public virtual async Task OnPageLoadedAsync(CancellationToken cancellationToken  )
        {

        }
        public virtual async Task OnAppearingAsync(CancellationToken cancellationToken  )
        {

        }

        public virtual async Task OnDisappearingAsync()
        {

        }


    }
}
