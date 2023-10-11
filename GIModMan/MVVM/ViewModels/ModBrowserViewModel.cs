using GIModMan.Core;
using GIModMan.MVVM.Models;
using GIModMan.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public ModBrowserViewModel() 
        {
            _ = LoadMods();
        }

        private async Task LoadMods()
        {
            APIService aPIService = new APIService();
            Mods = await aPIService.GetListAsync<Mod>(1, 1);
        }
    }
}
