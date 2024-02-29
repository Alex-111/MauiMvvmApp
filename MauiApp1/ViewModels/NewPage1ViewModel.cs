using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class NewPage1ViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;

        public NewPage1ViewModel(NavigationService navigation)
        {
            this._navigationService = navigation;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            OnButtonClick.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(AsyncRelayCommand.ExecutionTask) &&
                    ((AsyncRelayCommand)s).ExecutionTask is Task task &&
                    task.Exception is AggregateException exception)
                {
                    // Log your exception here
                }
            };

        }

        

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.ToString()); 
        }


        

        public AsyncRelayCommand OnButtonClick   => 
            new AsyncRelayCommand(async (cancel) =>
            {

                
                //throw new Exception();
                await _navigationService.NavigateAsync(nameof(NewPage2));
            });

    }
}
