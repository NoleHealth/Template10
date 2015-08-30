using Minimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal.Services.Data
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SettingsService
    public class AppDataService
    {
        public static AppDataService Instance { get; private set; }

        static AppDataService()
        {
            // implement singleton pattern
            Instance = Instance ?? new AppDataService();
            
        }

        //Template10.Services.SettingsService.SettingsHelper _helper;
        private ViewActionInfo[] _vps;
        private NavigationPatternInfo[] _nps;

        private AppDataService()
        {
            //  _helper = new Template10.Services.SettingsService.SettingsHelper();
            loadViewPurposes();
            loadNavigationPatterns();
        }

        public IQueryable<ViewActionInfo> ViewPurposes()
        {
            return _vps.Select(p => p).AsQueryable();
        }
        public IQueryable<NavigationPatternInfo> NavigationPatterns()
        {
            return _nps.Select(p => p).AsQueryable();
        }


        private void loadNavigationPatterns()
        {
            //Xamarin bok pg 217
            _nps = new NavigationPatternInfo[] {
                new NavigationPatternInfo()
                {
                    ID = NavigationPattern.Hierarchical,
                    Name = "Hierarchical",
                    Description = "A stack-based..."
                },
                new NavigationPatternInfo()
                {
                    ID = NavigationPattern.Modal,
                    Name = "Modal",
                    Description = "A screen that interupts..."
                },
                new NavigationPatternInfo()
                {
                    ID = NavigationPattern.DrilldownList,
                    Name = "Drill-down list",
                    Description = "A list of tappable items..."
                },
                new NavigationPatternInfo()
                {
                    ID = NavigationPattern.NavigationDrawer,
                    Name = "Navigation drawer",
                    Description = "A navigation menu that slides over from the left side at the tap of an icon (hamburger)..."
                },
                new NavigationPatternInfo()
                {
                    ID = NavigationPattern.Tabs,
                    Name = "Tabs",
                    Description = "A bar containig serveral folder like buttons..."
                },
                new NavigationPatternInfo()
                {
                    ID = NavigationPattern.Springboard,
                    Name = "Springboard",
                    Description = "Also referred to as a dashboard, this is a grid of tappable icons invoking new pages."
                },
                new NavigationPatternInfo()
                {
                    ID = NavigationPattern.Carousel,
                    Name = "Carousel",
                    Description = "Screen-sized panels that slide horizontally and sometimes contain large images."
                }
            };
        }
        private void loadViewPurposes()
        {
            _vps = new ViewActionInfo[] {
                new ViewActionInfo()
                 {
                    ID = ViewAction.Navigation,
                    Name = "Navigate",
                    Description = "Navigate to another page."
                },
                new ViewActionInfo()
                 {
                    ID = ViewAction.CRUD,
                    Name = "Crud",
                    Description = "Modify data."
                }
            };
        }

        //new NavigationPattern()
        //{
        //    ID = 1,
        //            Name = "Crud",
        //            Description = "View that is used to edit data."
        //        }


        
        
        
        


    }
}