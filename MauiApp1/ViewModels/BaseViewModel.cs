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

        public virtual async Task OnPageLoadedAsync( )
        {

        }
        public virtual async Task OnAppearingAsync( )
        {

        }

        public virtual async Task OnDisappearingAsync()
        {

        }


    }
}
