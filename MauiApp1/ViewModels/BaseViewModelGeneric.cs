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


        public override Task OnAppearingAsync()
        {
            return  OnAppearingAsync(_parameter);
        }

        public override Task OnPageLoadedAsync()
        {
            return OnPageLoadedAsync(_parameter);


        }

        //public override Task OnDisappearingAsync()
        //{
        //    return OnDisappearingAsync();
        //}


        public virtual async Task OnPageLoadedAsync(T parameter)
        {

        }
        public virtual async Task OnAppearingAsync(T parameter)
        {

        }

        

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _parameter = query?.Values?.FirstOrDefault() as T;
        }
    }
}
