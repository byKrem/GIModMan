using GIModMan.Core;
using GIModMan.MVVM.Models;
using System.Collections.Generic;

namespace GIModMan.MVVM.ViewModels
{
    internal class InstalledModsViewModel : ObservableObject
    {
        private List<Mod> _installedMods;
        public List<Mod> InstalledMods => _installedMods;

        public bool IsZeroModsInstalled
        {
            get => InstalledMods.Count == 0;
        }
        public InstalledModsViewModel()
        {
            _installedMods = new List<Mod>();
        }
    }
}
