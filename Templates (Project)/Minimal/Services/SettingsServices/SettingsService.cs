﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.SettingsServices
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SettingsService
    public class SettingsService
    {
        public static SettingsService Instance { get; private set; }

        static SettingsService()
        {
            // implement singleton pattern
            Instance = Instance ?? new SettingsService();
        }

        Template10.Services.SettingsService.SettingsHelper _helper;

        private SettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public bool UseShellBackButton
        {
            get { return _helper.Read<bool>(nameof(UseShellBackButton), true); }
            set
            {
                _helper.Write(nameof(UseShellBackButton), value);
                Template10.Common.BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
                {
                    Template10.Common.BootStrapper.Current.ShowShellBackButton = value;
                    Template10.Common.BootStrapper.Current.UpdateShellBackButton();
                    Template10.Common.BootStrapper.Current.NavigationService.Refresh();
                });
            }
        }

        public int CacheMaxDurationDays
        {
            get { return _helper.Read<int>(nameof(CacheMaxDurationDays), 2); }
            set
            {
                _helper.Write(nameof(CacheMaxDurationDays), value);
                Template10.Common.BootStrapper.Current.NavigationService.Refresh();
            }
        }

        public bool ShowSplashScreen
        {
            get { return _helper.Read<bool>(nameof(ShowSplashScreen), true); }
            set
            {
                _helper.Write(nameof(ShowSplashScreen), value);
                Template10.Common.BootStrapper.Current.NavigationService.Refresh();
            }
        }

        
    }
}
