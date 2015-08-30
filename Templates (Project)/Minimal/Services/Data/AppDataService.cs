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

        private AppDataService()
        {
          //  _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public IQueryable<ViewFunction> GetViewFunctions()
        {
            return new List<ViewFunction>();
        }


    }
}