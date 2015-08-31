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

namespace Minimal.ViewModels
{
    public class ShellViewModelExt : Minimal.Mvvm.ViewModelBaseExt
    {
        public static ShellViewModelExt Instance { get; private set; }

        static ShellViewModelExt()
        {
            //there is always only one shell per app
            // implement singleton pattern
            Instance = Instance ?? new ShellViewModelExt();
        }

        public override NavigationPattern NavigationPatternType { get; set; } = NavigationPattern.NavigationDrawer;
        public override ViewAction ViewPurposeType { get; set; } = ViewAction.Navigation;
        public override string PrimaryNavigationEntryPath { get; set; } = "";

        private ShellViewModelExt()
        {
            PrimaryButtons = new ObservableCollection<NavigationButtonInfo>();
            addTestButtoms();
        }


        private bool _showShellBackButton = false;
        public bool ShowShellBackButton { get { return _showShellBackButton; } set { Set(ref _showShellBackButton, value); } }

        private bool _showSplashScreen = true;
        public bool ShowSplashScreen { get { return _showSplashScreen; } set { Set(ref _showSplashScreen, value); } }

        private int _cacheMaxDurationDays = 2;
        public int CacheMaxDurationDays { get { return _cacheMaxDurationDays; } set { Set(ref _cacheMaxDurationDays, value); } }


        private Visibility _busyIndicatorVisible = Visibility.Collapsed;
        public Visibility BusyIndicatorVisible { get { return _busyIndicatorVisible; } set { Set(ref _busyIndicatorVisible, value); } }

        private bool _busyIndicatorActive = false;
        public bool BusyIndicatorActive { get { return _busyIndicatorActive; } set { Set(ref _busyIndicatorActive, value); } }

        private string _busyIndicatorText = "blow me";
        public string BusyIndicatorText { get { return _busyIndicatorText; } set { Set(ref _busyIndicatorText, value); } }


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
            
            if(string.IsNullOrEmpty(PrimaryNavigationEntryPath) == false)
            {
                //need to break it down


            }

            return;

        }

        public ObservableCollection<NavigationButtonInfo> PrimaryButtons { get; set; }

        

        private void addTestButtoms()
        {
            var navigationButtonInfo = new NavigationButtonInfo();
            navigationButtonInfo.ClearHistory = true;
            navigationButtonInfo.PageParameter = "";
            navigationButtonInfo.PageType = Type.GetType("Minimal.Views.MainPage");
            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackPanel.Children.Add(new SymbolIcon { Symbol = Symbol.Home, Width = 48, Height = 48 });
            stackPanel.Children.Add(new TextBlock { Text = "Main", VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(12, 0, 0, 0) });
            navigationButtonInfo.Content = stackPanel;

            PrimaryButtons.Add(navigationButtonInfo);


            navigationButtonInfo = new NavigationButtonInfo();
            navigationButtonInfo.ClearHistory = true;
            navigationButtonInfo.PageParameter = "";
            navigationButtonInfo.PageType = Type.GetType("Minimal.Views.HomePage");
            stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackPanel.Children.Add(new SymbolIcon { Symbol = Symbol.Home, Width = 48, Height = 48 });
            stackPanel.Children.Add(new TextBlock { Text = "Home", VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(12, 0, 0, 0) });
            navigationButtonInfo.Content = stackPanel;

            PrimaryButtons.Add(navigationButtonInfo);
        }
    }
}
