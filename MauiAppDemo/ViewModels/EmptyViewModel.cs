using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppDemo.ViewModels
{
    public partial class EmptyViewModel : BaseViewModel
    {


        public EmptyViewModel(NavigationService navigationService) : base(navigationService) 
        {
                
        }
    }
}
