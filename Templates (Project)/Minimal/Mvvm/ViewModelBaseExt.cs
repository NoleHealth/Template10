using Minimal.Models;
using Minimal.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Navigation;

namespace Minimal.Mvvm
{

    public abstract class ViewModelBaseExt : ViewModelBase
    {

        
        private string _title = "ViewModelBaseExt Title";
        public virtual string Title { get { return _title; } set { Set(ref _title, value); } }

        private NavigationPattern _navigationPattern = Models.NavigationPattern.NavigationDrawer;
        public NavigationPattern NavigationPattern { get { return _navigationPattern; } set { Set(ref _navigationPattern, value); } }

        private ViewAction _viewAction = ViewAction.Navigation;
        public ViewAction ViewAction { get { return _viewAction; } set { Set(ref _viewAction, value); } }

        private string _primaryNavigationEntryPath = string.Empty;
        public virtual string PrimaryNavigationEntryPath { get { return _primaryNavigationEntryPath; } set { Set(ref _primaryNavigationEntryPath, value); } }


        
        public IQueryable<string> SecondaryNavigationEntryPaths { get; set; } = new string[0].AsQueryable();
        public IQueryable<string> NavigationExitPaths { get; set; } = new string[0].AsQueryable();

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            ShellViewModelExt.Instance.OnViewnNavigatedTo(this); ;

        }
        public override string ToString()
        {

            if (string.IsNullOrEmpty(this.Title) == false)
                return this.Title;

            return base.ToString();
        }
    }
}