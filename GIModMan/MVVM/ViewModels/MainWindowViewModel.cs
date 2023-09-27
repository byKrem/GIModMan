using GIModMan.Core;
using System.Windows;
using System.Windows.Input;

namespace GIModMan.MVVM.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        private bool _isInstalledMods = true;
        private bool _isModBrowser;
        private bool _isSettings;
        private bool _isConfigs;

        public bool IsInstalledMods
        {
            get => _isInstalledMods;
            set => Set(ref _isInstalledMods, value);
        }
        public bool IsModBrowser
        {
            get => _isModBrowser;
            set => Set(ref _isModBrowser, value);
        }
        public bool IsSettings
        {
            get => _isSettings;
            set => Set(ref _isSettings, value);
        }
        public bool IsConfigs
        {
            get => _isConfigs;
            set => Set(ref _isConfigs, value); 
        }

        private RelayCommand _shutdownCommand;
        public ICommand ShutdownCommand => _shutdownCommand;

        public MainWindowViewModel()
        {
            _shutdownCommand = new RelayCommand(execute =>
            {
                Application.Current.Shutdown();
            });
        }
    }
}
