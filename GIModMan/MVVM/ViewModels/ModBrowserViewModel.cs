using GIModMan.Core;
using GIModMan.MVVM.Models;
using GIModMan.MVVM.Models.API;
using GIModMan.Services;
using System.Collections.Generic;
using System.Windows.Input;

namespace GIModMan.MVVM.ViewModels
{
    internal class ModBrowserViewModel : ObservableObject
    {
        private APIService _aPIService;
        private List<Mod> _mods;
        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }
        private int _totalPagesCount;
        public int TotalPagesCount
        {
            get => _totalPagesCount;
            set => Set(ref _totalPagesCount, value);
        }
        public List<Mod> Mods
        {
            get => _mods;
            set => Set(ref _mods, value);
        }

        private readonly RelayCommand _openModProfile = new RelayCommand(execute =>
        {
            System.Diagnostics.Process.Start((execute as Mod).ProfileUrl.ToString());
        }, canExecute => canExecute is Mod);
        public ICommand OpenModProfile => _openModProfile;

        private readonly RelayCommand _openNextPage;
        private readonly RelayCommand _openPrevPage;
        private readonly RelayCommand _openLastPage;
        private readonly RelayCommand _openFirstPage;
        public ICommand OpenNextPage => _openNextPage;
        public ICommand OpenPrevPage => _openPrevPage;
        public ICommand OpenLastPage => _openLastPage;
        public ICommand OpenFirstPage => _openFirstPage;

        public ModBrowserViewModel() 
        {
            _aPIService = new APIService();

            _openNextPage = new RelayCommand(execute =>
            {
                OpenPage(requiredPage: _currentPage + 1);
            }, canExecute => _currentPage + 1 <= _totalPagesCount);

            _openPrevPage = new RelayCommand(execute =>
            {
                OpenPage(requiredPage: _currentPage - 1);
            }, canExecute => _currentPage - 1 >= 1);

            _openLastPage = new RelayCommand(execute =>
            {
                OpenPage(requiredPage: _totalPagesCount);
            }, canExecute => _currentPage != _totalPagesCount);

            _openFirstPage = new RelayCommand(execute =>
            {
                OpenPage(requiredPage: 1);
            }, canExecute => _currentPage != 1);

            OpenPage(requiredPage: 1);
        }
        private async void OpenPage(int requiredPage)
        {
            RecordsList<Mod> response = await _aPIService.GetListAsync<Mod>(requiredPage);
            Mods = response.Records;

            TotalPagesCount = response.Metadata.TotalPages;
            CurrentPage = requiredPage;
        }
    }
}
