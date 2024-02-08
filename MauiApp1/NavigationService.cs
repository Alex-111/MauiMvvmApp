using MauiApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class NavigationService
    {
        private readonly AppShell shell;

        public NavigationService(AppShell shell)
        {
            this.shell = shell;
        }


        

        public Task NavigateAsync(string path, bool clearStack = false)
        {
            return NavigateAsync<ViewModelParameterBase>(path, null, clearStack);
        }
        public async Task NavigateAsync<T>(string path, T parameter = null, bool clearStack = false) where T : class
        {


            if (clearStack)
            {
                var navigation = Shell.Current.Navigation;
                var pages = navigation.NavigationStack;

                foreach (var item in pages.ToList())
                {
                    if (item != null) navigation.RemovePage(item);
                }

            }
            //App.Current.MainPage = shell;
            await Shell.Current.GoToAsync(path, new Dictionary<string, object>() { ["P"] = parameter });
        }

        public void ResetToHome()
        {
            var navigation = Shell.Current.Navigation;
            var pages = navigation.NavigationStack;

            foreach (var item in pages.ToList())
            {
                if (item != null) navigation.RemovePage(item);
            }

            var appShell = Shell.Current as AppShell;

            appShell.SetMainPage();
        }
    }
}
