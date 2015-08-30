using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minimal.Mvvm
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-MVVM
    public abstract class ViewModelBase : Template10.Mvvm.ViewModelBase
    {
        // the only thing that matters here is Template10.Services.NavigationService.INavagable

        public string PrimaryNavigationEntryPath { get; set; } = "";
        public IEnumerable<string> SecondaryNavigationEntryPaths { get; set; } = new string[0];
        public IEnumerable<string> NavigationExitPaths { get; set; } = new string[0];

        
    }
}