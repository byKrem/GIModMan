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

        private RelayCommand _closeWindowCommand = new RelayCommand(execute =>
        {
            SystemCommands.CloseWindow(execute as Window);
        }, canExecute => canExecute is Window);

        private RelayCommand _minimizeWindowCommand = new RelayCommand(execute =>
        {
            SystemCommands.MinimizeWindow(execute as Window);
        }, canExecute => canExecute is Window);
        public ICommand CloseWindowCommand => _closeWindowCommand;
        public ICommand MinimizeWindowCommand => _minimizeWindowCommand;

        public MainWindowViewModel()
        {
        }
    }
}
