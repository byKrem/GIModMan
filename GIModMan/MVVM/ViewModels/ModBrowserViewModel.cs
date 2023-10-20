using GIModMan.Core;
using GIModMan.MVVM.Models;
using GIModMan.MVVM.Models.API;
using GIModMan.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GIModMan.MVVM.ViewModels
{
    internal class ModBrowserViewModel : ObservableObject
    {
        private APIService _aPIService;
        private List<Mod> _mods;
        public List<Mod> Mods
        {
            get => _mods;
            set => Set(ref _mods, value);
        }

        private ObservableCollection<Button> _pageControlButtons;
        public ObservableCollection<Button> PageContorolButtons
        {
            get => _pageControlButtons;
            set => Set(ref _pageControlButtons, value);
        }

        private RelayCommand _openModProfile = new RelayCommand(execute =>
        {
            if (execute is Mod mod)
            {
                System.Diagnostics.Process.Start(mod.ProfileUrl.ToString());
            }
        }, canExecute => canExecute is Mod);
        public ICommand OpenModProfile => _openModProfile;

        private RelayCommand _openPage;

        public ModBrowserViewModel() 
        {
            _aPIService = new APIService();
            PageContorolButtons = new ObservableCollection<Button>();
            _openPage = new RelayCommand(async execute =>
            {
                if (execute is int page)
                {
                    RecordsList<Mod> response = await _aPIService.GetListAsync<Mod>(page);
                    Mods = response.Records;
                }
            });
            _ = LoadMods();
        }

        private async Task LoadMods()
        {
            RecordsList<Mod> response = await _aPIService.GetListAsync<Mod>(page: 1);

            Mods = response.Records;
            for(int i = 1; i <= response.Metadata.TotalPages; i++)
            {
                PageContorolButtons.Add(new Button()
                {
                    Content = i,
                    Command = _openPage,
                    CommandParameter = i
                });
            }
        }
    }
}
