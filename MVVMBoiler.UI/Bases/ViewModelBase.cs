using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMBoiler.UI.Bases
{
    /// <summary>
    /// Wrapper for View Model
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
