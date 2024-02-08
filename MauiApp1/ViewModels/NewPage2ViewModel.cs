using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class NewPage2ViewModel : BaseViewModel<NewPage2Parameter>
    {
        private readonly NavigationService navigationService;

        public NewPage2ViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;

           

        }
        public ICommand OnButtonClick =>
                                      new AsyncRelayCommand(async () =>
                                      {
                                          param = param ?? new NewPage2Parameter();
                                          param.Count++;
                                          await navigationService.NavigateAsync(nameof(NewPage2), param);
                                      });


        public ICommand OnButton2Click =>
                                    new AsyncRelayCommand(async () =>
                                    {
                                        await navigationService.NavigateAsync("//" + nameof(MainPage));
                                      
                                    });

        public ICommand OnButton3Click =>
                                  new AsyncRelayCommand(async () =>
                                  {
                                      //await Shell.Current.Navigation.PopToRootAsync();
                                      await navigationService.NavigateAsync("//" + nameof(MainPage), true);
                                      //navigationService.ResetToHome();
                                      
                                  });


        public ICommand OnButton4Click =>
                                  new AsyncRelayCommand(async () =>
                                  {
                                      await Shell.Current.Navigation.PushModalAsync(new NewPage3(new EmptyViewModel()));
                                      //await navigationService.NavigateAsync(nameof(NewPage3), false);
                                      

                                  });


        private NewPage2Parameter param;
        public override async Task OnAppearingAsync(NewPage2Parameter p, CancellationToken cancellationToken)
        {
            await base.OnAppearingAsync (p, cancellationToken);
            param = p;
            //await navigationService.NavigateAsync("..");
        }

       
    }
}
