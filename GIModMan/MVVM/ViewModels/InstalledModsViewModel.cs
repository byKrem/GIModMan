using GIModMan.Core;

namespace GIModMan.MVVM.ViewModels
{
    internal class InstalledModsViewModel : ObservableObject
    {
        private bool _isZeroModsInstalled = true;
        public bool IsZeroModsInstalled
        {
            get => _isZeroModsInstalled;
            set => Set(ref _isZeroModsInstalled, value);
        }
        public InstalledModsViewModel()
        {

        }
    }
}
