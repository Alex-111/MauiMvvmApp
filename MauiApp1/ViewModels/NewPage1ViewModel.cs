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
        

        public NewPage1ViewModel(NavigationService navigationService) : base(navigationService)
        {
            
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            OnButtonClick.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(AsyncRelayCommand.ExecutionTask) && s is AsyncRelayCommand rc &&
                    rc.ExecutionTask?.Exception is AggregateException exception)
                {
                    // Log your exception here
                }
            };

        }

        

        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.ToString()); 
        }


        public override Task OnAppearingAsync(CancellationToken cancellationToken)
        {
            return base.OnAppearingAsync(cancellationToken);
        }

        public override Task OnDisappearingAsync()
        {
            return base.OnDisappearingAsync();
        }


        public AsyncRelayCommand OnButtonClick   => 
            new AsyncRelayCommand(async (cancel) =>
            {

                
                //throw new Exception();
                await NavigationService.NavigateAsync(nameof(NewPage2));
            });

    }
}
