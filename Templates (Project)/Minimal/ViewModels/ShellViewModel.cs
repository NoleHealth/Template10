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

namespace Minimal.ViewModels
{
    public class ShellViewModel : Minimal.Mvvm.ViewModelBase
    {
        public static ShellViewModel Instance { get; private set; }

        static ShellViewModel()
        {
            //there is always only one shell per app
            // implement singleton pattern
            Instance = Instance ?? new ShellViewModel();
        }

        private ShellViewModel()
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

        internal void OnViewnNavigatedTo(ViewModelBase viewModel)
        {
            throw new NotImplementedException();
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
