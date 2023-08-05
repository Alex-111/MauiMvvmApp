using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class BaseViewModel<T> : BaseViewModel, IQueryAttributable where T : class
    {

        private T _parameter;


        public override Task OnAppearingAsync(CancellationToken cancellationToken)
        {
            return  OnAppearingAsync(_parameter, cancellationToken);
        }

        public override Task OnPageLoadedAsync(CancellationToken cancellationToken)
        {
            return OnPageLoadedAsync(_parameter, cancellationToken  );


        }

        //public override Task OnDisappearingAsync()
        //{
        //    return OnDisappearingAsync();
        //}


        public virtual async Task OnPageLoadedAsync(T parameter, CancellationToken cancellationToken)
        {

        }
        public virtual async Task OnAppearingAsync(T parameter, CancellationToken cancellationToken)
        {

        }

        

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _parameter = query?.Values?.FirstOrDefault() as T;
        }
    }
}
