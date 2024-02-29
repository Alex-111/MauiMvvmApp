using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public abstract class BaseViewModel<T> : BaseViewModel, IQueryAttributable where T : class
    {

        private T? _parameter;

        protected BaseViewModel(NavigationService navigationService) : base(navigationService)
        {
                
        }

        public sealed override Task OnAppearingAsync(CancellationToken cancellationToken)
        {
            return  OnAppearingAsync(_parameter, cancellationToken);
        }

        public sealed override Task OnPageLoadedAsync(CancellationToken cancellationToken)
        {
            return OnPageLoadedAsync(_parameter, cancellationToken  );


        }

        public virtual Task OnPageLoadedAsync(T? parameter, CancellationToken cancellationToken) => Task.CompletedTask;
         
        public virtual async Task OnAppearingAsync(T? parameter, CancellationToken cancellationToken)
        {
            await base.OnAppearingAsync(cancellationToken);
        }

        

        public void ApplyQueryAttributes(IDictionary<string, object?> query)
        {
            _parameter = query?.Values?.FirstOrDefault() as T;
        }
    }
}
