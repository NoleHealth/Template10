﻿using System;

namespace Minimal.ViewModels
{
    public class SettingsPageViewModelExt : Minimal.Mvvm.ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPageViewModelExt()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                return;
            }
            _settings = Services.SettingsServices.SettingsService.Instance;
        }

        #region Settings

        public bool UseShellBackButton
        {
            get { return _settings.UseShellBackButton; }
            set { _settings.UseShellBackButton = value; base.RaisePropertyChanged(); }
        }

        private string _BusyText = "Please wait...";
        public string BusyText { get { return _BusyText; } set { Set(ref _BusyText, BusyText); } }
        public void ShowBusy() { ShellViewModelExt.Instance.SetBusyIndicator(true, _BusyText); }
        public void HideBusy() { ShellViewModelExt.Instance.SetBusyIndicator(false); }

        #endregion

        #region About

        public Uri Logo { get { return Windows.ApplicationModel.Package.Current.Logo; } }
        public string DisplayName { get { return Windows.ApplicationModel.Package.Current.DisplayName; } }
        public string Publisher { get { return Windows.ApplicationModel.Package.Current.PublisherDisplayName; } }
        public string Version
        {
            get
            {
                var ver = Windows.ApplicationModel.Package.Current.Id.Version;
                return ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString() + "." + ver.Revision.ToString();
            }
        }
        public Uri RateMe { get { return new Uri(""); } }

        #endregion  
    }
}
