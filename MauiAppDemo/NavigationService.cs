using MauiAppDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MauiAppDemo
{
    public class NavigationService
    {
        private readonly AppShell shell;

        public NavigationService(AppShell shell)
        {
            this.shell = shell;
        }


        public async Task ShowAlert(Exception ex)
        {
            await shell.DisplayAlert("Error", ex.ToString(), "OK");
        }



        public Task NavigateAsync(string path)
        {
            return NavigateAsync<ViewModelParameterBase>(path, null);
        }
        public async Task NavigateAsync<T>(string path, T? parameter = null) where T : class
        {
            await Shell.Current.GoToAsync(path, new Dictionary<string, object?>() { ["P"] = parameter } );
        }
        public Task ResetToHome()
        {
            return Shell.Current.Navigation.PopToRootAsync(true);
        }


        /// <summary>
        /// Unfortunately the OnAppearing runs for the root page after execuring this
        /// </summary>
        public void ClearStack()
        {
            var navigation = Shell.Current.Navigation;
            var pages = navigation.NavigationStack;

            foreach (var item in pages.ToList())
            {
                if (item != null) navigation.RemovePage(item);
            }
        }



        //public Task NavigateAsync(string path, bool clearStack = false)
        //{
        //    return NavigateAsync<ViewModelParameterBase>(path, null, clearStack);
        //}
        //public async Task NavigateAsync<T>(string path, T? parameter = null, bool clearStack = false) where T : class
        //{


        //    if (clearStack)
        //    {
        //        var navigation = Shell.Current.Navigation;
        //        var pages = navigation.NavigationStack;

        //        foreach (var item in pages.ToList())
        //        {
        //            if (item != null) navigation.RemovePage(item);
        //        }

        //    }
        //    //App.Current.MainPage = shell;
        //    await Shell.Current.GoToAsync(path, parameter != null ? new Dictionary<string, object>() { ["P"] = parameter } : null);
        //}

        //public void ResetToHome()
        //{
        //    var navigation = Shell.Current.Navigation;
        //    var pages = navigation.NavigationStack;

        //    foreach (var item in pages.ToList())
        //    {
        //        if (item != null) navigation.RemovePage(item);
        //    }

        //    if (Shell.Current is AppShell s)
        //    {
        //        s.SetMainPage();
        //    }
        //}
    }
}
