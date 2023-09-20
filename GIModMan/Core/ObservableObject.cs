using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GIModMan.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        protected bool Set<T>(ref T field, T newVal, [CallerMemberName] string propName = null)
        {
            if(Equals(field, newVal))
            {
                return false;
            }

            field = newVal;
            OnPropertyChanged(propName);
            return true;
        }
    }
}
