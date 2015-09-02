using Minimal.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Minimal.Views
{
    public sealed partial class DetailPageExt : Page
    {
        public DetailPageExt()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public DetailPageViewModelExt ViewModel => DataContext as DetailPageViewModelExt; 
    }
}
