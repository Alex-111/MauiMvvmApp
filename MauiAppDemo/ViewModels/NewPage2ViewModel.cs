using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppDemo.ViewModels
{
    public partial class NewPage2ViewModel : BaseViewModel<NewPage2Parameter>
    {
      

        public NewPage2ViewModel(NavigationService navigationService) : base(navigationService)
        {
            
        }
        public ICommand OnButtonClick =>
                                      new AsyncRelayCommand(async () =>
                                      {
                                          param = param ?? new NewPage2Parameter();
                                          param.Count++;
                                          await NavigationService.NavigateAsync(nameof(NewPage2), param);
                                      });


        public ICommand OnButton2Click =>
                                    new AsyncRelayCommand(async () =>
                                    {
                                        await NavigationService.NavigateAsync("//" + nameof(MainPage));
                                      
                                    });

        public ICommand OnButton3Click =>
                                  new AsyncRelayCommand(async () =>
                                  {
                                      //await Shell.Current.Navigation.PopToRootAsync();
                                      NavigationService.ClearStack();
                                      await NavigationService.NavigateAsync("//" + nameof(MainPage));
                                     

                                      //navigationService.ResetToHome();
                                      
                                  });

 
        [RelayCommand]
        private async Task  Button4Async()
        {
            await Shell.Current.Navigation.PushModalAsync(new NewPage3(new EmptyViewModel(NavigationService)));
        }
        [RelayCommand]
        private void ClearStack()
        {
            NavigationService.ClearStack();
        }

        private NewPage2Parameter? param;
        public override async Task OnAppearingAsync(NewPage2Parameter? p, CancellationToken cancellationToken)
        {
            
            await base.OnAppearingAsync (p, cancellationToken);
            param = p;
            //await navigationService.NavigateAsync("..");
        }

        
       
    }
}
