using GIModMan.Core;
using GIModMan.MVVM.Models;
using GIModMan.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GIModMan.MVVM.ViewModels
{
    internal class ModBrowserViewModel : ObservableObject
    {
        private List<Mod> _mods;
        public List<Mod> Mods
        {
            get => _mods;
            set => Set(ref _mods, value);
        }

        private RelayCommand _openModProfile = new RelayCommand(execute =>
        {
            if (execute is Mod mod)
            {
                System.Diagnostics.Process.Start(mod.ProfileUrl.ToString());
            }
        }, canExecute => canExecute is Mod);
        public ICommand OpenModProfile => _openModProfile;

        public ModBrowserViewModel() 
        {
            _ = LoadMods();
        }

        private async Task LoadMods()
        {
            APIService aPIService = new APIService();
            Mods = await aPIService.GetListAsync<Mod>(page: 1);
        }
    }
}
