using Minimal.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Minimal.Views
{
    public sealed partial class SettingsPageExt : Page
    {
        public SettingsPageExt()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public SettingsPageViewModelExt ViewModel => this.DataContext as SettingsPageViewModelExt;
    }
}
