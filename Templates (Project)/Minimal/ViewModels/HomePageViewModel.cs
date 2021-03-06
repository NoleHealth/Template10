﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimal.Models;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace Minimal.ViewModels
{
    
    public class HomePageViewModel : Minimal.Mvvm.ViewModelBaseExt
    {
        
        private string _Value = string.Empty;
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        public HomePageViewModel()
        {
            Title = "Home";
            NavigationPattern = NavigationPattern.Springboard;
            ViewAction = ViewAction.Navigation;
            PrimaryNavigationEntryPath = "";

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                Value = "Designtime value";
                this.Title = "Designtime Home Page from VM";
                return;
            }

        }


        public void GotoDetailsPage()
        {
            this.NavigationService.Navigate(typeof(Views.DetailPage), this.Value);
        }

        #region Navigation overrides


        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(Value))) Value = state[nameof(Value)]?.ToString();
                // clear any cache
                state.Clear();
            }
            base.OnNavigatedTo(parameter, mode, state);
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(Value)] = Value;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            base.OnNavigatingFrom(args);
        }

        #endregion

    }
}
