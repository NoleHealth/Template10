using Minimal.Models;
using Minimal.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Navigation;

namespace Minimal.Mvvm
{

    public abstract class ViewModelBaseExt : ViewModelBase
    {


        public abstract string PrimaryNavigationEntryPath { get; set; }


        public abstract NavigationPattern NavigationPatternType { get; set; }
        public abstract ViewAction ViewPurposeType { get; set; }

        public IQueryable<string> SecondaryNavigationEntryPaths { get; set; } = new string[0].AsQueryable();
        public IQueryable<string> NavigationExitPaths { get; set; } = new string[0].AsQueryable();

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            ShellViewModelExt.Instance.OnViewnNavigatedTo(this); ;

        }

    }
}