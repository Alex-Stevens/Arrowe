using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Arrowe.Toasts
{
    public abstract class Toast : INotifyPropertyChanged
    {
        public UserControl View { get; protected set; }
        public abstract void Displayed();
        public abstract void Tapped();

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
