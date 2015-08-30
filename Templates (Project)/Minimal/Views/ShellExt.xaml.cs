using Minimal.ViewModels;
using Template10.Services.NavigationService;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Minimal.Views
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SplitView
    public sealed partial class ShellExt : Page
    {
        //private static Shell Instance { get; set; }

        public ShellViewModelExt ViewModel { get { return DataContext as ShellViewModelExt; } private set { DataContext = value; } }

        public ShellExt(NavigationService navigationService)
        {
            //Instance = this;
            this.ViewModel = ShellViewModelExt.Instance;
            this.InitializeComponent();
            MyHamburgerMenu.NavigationService = navigationService;
            this.ViewModel = ShellViewModelExt.Instance;

        }

        
    }
}
