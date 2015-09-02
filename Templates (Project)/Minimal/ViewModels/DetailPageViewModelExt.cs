using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Minimal.Models;

namespace Minimal.ViewModels
{
    public class DetailPageViewModelExt : Minimal.Mvvm.ViewModelBaseExt
    {
        Services.SecondaryTilesService.SecondaryTileService _SecondaryTileService;


        public DetailPageViewModelExt()
        {
            Title = "Details";
            NavigationPattern = NavigationPattern.Springboard;
            ViewAction = ViewAction.Navigation;
            PrimaryNavigationEntryPath = "";

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                this.Value = "Designtime value";
                return;
            }
            else
            {
                _SecondaryTileService = new Services.SecondaryTilesService.SecondaryTileService();
            }
        }

        bool _hasEverLoaded = false;
        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (_hasEverLoaded && (mode == NavigationMode.Forward || mode == NavigationMode.Back))
            {
                // (optional) When NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
                // then, don't call load if cached && navigating back/forward
                base.OnNavigatedTo(parameter, mode, state);
                return;
            }

            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(Value))) Value = state[nameof(Value)]?.ToString();
                // clear any cache
                state.Clear();
            }
            else
            {
                // use navigation parameter
                Value = string.Format("You passed '{0}'", parameter?.ToString());
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
            else
            {
                // (optional) When NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
                // then, create indicator that this has been pre-loaded
                _hasEverLoaded = true;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            args.Cancel = false;
        }

        private string _Value = "Default";
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        Services.SecondaryTilesService.PinCommand _pinCommand;
        public Services.SecondaryTilesService.PinCommand PinCommand
        {
            get
            {
                if (_pinCommand != null)
                    return _pinCommand;
                return _pinCommand = new Services.SecondaryTilesService.PinCommand
                {
                    Pin = () => _SecondaryTileService.PinExt(this),
                    Unpin = () => _SecondaryTileService.UnPinExt(this),
                    IsPinned = _SecondaryTileService.IsPinnedExt(this),
                };
            }
        }
    }
}
