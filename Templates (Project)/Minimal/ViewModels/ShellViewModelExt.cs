using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Controls;
using Minimal.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Minimal.Mvvm;
using Minimal.Models;
using Minimal.Services.SettingsServices;

namespace Minimal.ViewModels
{
    public class ShellViewModelExt : Minimal.Mvvm.ViewModelBaseExt
    {
        public static ShellViewModelExt Instance { get; private set; }


        public ObservableCollection<NavigationButtonInfo> PrimaryButtons { get; set; }
        public ObservableCollection<NavigationButtonInfo> SecondaryButtons { get; set; }

        public bool UseShellBackButton { get { return SettingsService.Instance.UseShellBackButton; } set { SettingsService.Instance.UseShellBackButton = value; base.RaisePropertyChanged(); } }
        public int CacheMaxDurationDays { get { return SettingsService.Instance.CacheMaxDurationDays; } set { SettingsService.Instance.CacheMaxDurationDays = value; base.RaisePropertyChanged(); } }
        public bool ShowSplashScreen { get { return SettingsService.Instance.ShowSplashScreen; } set { SettingsService.Instance.ShowSplashScreen = value; base.RaisePropertyChanged(); } }

        private Visibility _busyIndicatorVisible = Visibility.Collapsed;
        public Visibility BusyIndicatorVisible { get { return _busyIndicatorVisible; } set { Set(ref _busyIndicatorVisible, value); } }

        private bool _busyIndicatorActive = false;
        public bool BusyIndicatorActive { get { return _busyIndicatorActive; } set { Set(ref _busyIndicatorActive, value); } }

        private string _busyIndicatorText = "BusyIndicatorText";
        public string BusyIndicatorText { get { return _busyIndicatorText; } set { Set(ref _busyIndicatorText, value); } }

        private string _applicationTitle = "ApplicationTitle";
        public string ApplicationTitle { get { return _applicationTitle; } set { Set(ref _applicationTitle, value); } }



        static ShellViewModelExt()
        {
            //there is always only one shell per app
            // implement singleton pattern
            Instance = Instance ?? new ShellViewModelExt();
        }

        
        private ShellViewModelExt()
        {
            ApplicationTitle = " Who wrote this sh*t";
            BusyIndicatorText = " busy bee";
            NavigationPattern = NavigationPattern.NavigationDrawer;
            ViewAction = ViewAction.Navigation;
            PrimaryNavigationEntryPath = "";

            PrimaryButtons = new ObservableCollection<NavigationButtonInfo>();
            SecondaryButtons = new ObservableCollection<NavigationButtonInfo>();
            //addTestButtoms();
        }

        public void SetBusyIndicator(bool busy, string text = null)
        {
            BusyIndicatorVisible = (busy)
                ? Visibility.Visible : Visibility.Collapsed;
            BusyIndicatorActive = busy;
            BusyIndicatorText = text ?? string.Empty;

            //Instance.BusyIndicator.Visibility = (busy)
            //    ? Visibility.Visible : Visibility.Collapsed;
            //Instance.BusyRing.IsActive = busy;
            //Instance.BusyText.Text = text ?? string.Empty;
        }





        internal void OnViewnNavigatedTo(ViewModelBaseExt viewModel)
        {
            
            addTestButtoms(viewModel is DetailPageViewModelExt);

            if (string.IsNullOrEmpty(PrimaryNavigationEntryPath))
            {
                //need to break it down




            }

            return;

        }

        
        



        private void addTestButtoms(bool addExtra=false)
        {
            NavigationButtonInfo navigationButtonInfo;

            Type type;
            string pageParameter;
            Symbol symbol;
            string text;

            type = Type.GetType("Minimal.Views.HomePage");
            if (PrimaryButtons.Any(p => p.PageType.Equals(type)) == false)
            {
                text = "Home";
                symbol = Symbol.Home;
                pageParameter = "Source=Shell";
                navigationButtonInfo = createNavigationButtonInfo(type, text, symbol, pageParameter);
                PrimaryButtons.Add(navigationButtonInfo);
            }

            type = Type.GetType("Minimal.Views.MasterPage");
            if (PrimaryButtons.Any(p => p.PageType.Equals(type)) == false)
            {
                text = "Master";
                symbol = Symbol.ImportAll;
                pageParameter = "Source=Shell";
                navigationButtonInfo = createNavigationButtonInfo(type, text, symbol, pageParameter);
                PrimaryButtons.Add(navigationButtonInfo);
            }

            type = Type.GetType("Minimal.Views.SettingsPageExt");
            if (SecondaryButtons.Any(p => p.PageType.Equals(type)) == false)
            {
                text = "Settings";
                symbol = Symbol.Setting;
                pageParameter = "Source=Shell";
                navigationButtonInfo = createNavigationButtonInfo(type, text, symbol, pageParameter);
                SecondaryButtons.Add(navigationButtonInfo);
            }

            type = Type.GetType("Minimal.Views.DetailPage");
            navigationButtonInfo = PrimaryButtons.FirstOrDefault(p => p.PageType.Equals(type));
            if (addExtra)
            {
                
                if (navigationButtonInfo == null)
                {
                    text = "DetailPage";
                    symbol = Symbol.Directions;
                    pageParameter = "Source=Shell";
                    navigationButtonInfo = createNavigationButtonInfo(type, text, symbol, pageParameter);
                    PrimaryButtons.Add(navigationButtonInfo);
                }
            }
            else
            {
                if(navigationButtonInfo != null)
                    PrimaryButtons.Remove(navigationButtonInfo);
            }
        }

        private static NavigationButtonInfo createNavigationButtonInfo(Type type, string text, Symbol symbol, string pageParameter)
        {
            NavigationButtonInfo navigationButtonInfo;
            StackPanel stackPanel;
            navigationButtonInfo = new NavigationButtonInfo();
            navigationButtonInfo.ClearHistory = true;
            navigationButtonInfo.PageParameter = pageParameter;
            navigationButtonInfo.PageType = type;
            stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackPanel.Children.Add(new SymbolIcon { Symbol = symbol, Width = 48, Height = 48 });
            stackPanel.Children.Add(new TextBlock { Text = text, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(12, 0, 0, 0) });
            navigationButtonInfo.Content = stackPanel;
            return navigationButtonInfo;
        }
    }
}
