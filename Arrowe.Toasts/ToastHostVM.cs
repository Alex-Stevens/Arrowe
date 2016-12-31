using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Arrowe.Toasts
{
    public class ToastHostVM : INotifyPropertyChanged
    {
        private static ToastHostVM _singleton;
        public static ToastHostVM Singleton => _singleton ?? (_singleton = new ToastHostVM());

        private Task _pumpQueue;
        private readonly ConcurrentQueue<Toast> _messageQueue = new ConcurrentQueue<Toast>();

        private Toast _toast;
        private bool _isOpen;

        public Toast Toast
        {
            get
            {
                return _toast;
            }
            set
            {
                if (value != _toast)
                {
                    _toast = value;
                    OnPropertyChanged(nameof(Toast));
                }
            }
        }

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                if (value != _isOpen)
                {
                    _isOpen = value;
                    OnPropertyChanged(nameof(IsOpen));
                }
            }
        }

        public void AddToastToQueue(Toast toast)
        {
            _messageQueue.Enqueue(toast);

            if (_pumpQueue == null)
            {
                _pumpQueue = ConsumeAndDisplay();
                return;
            }

            if (_pumpQueue.IsCompleted)
            {
                _pumpQueue = ConsumeAndDisplay();
            }
        }

        private async Task ConsumeAndDisplay()
        {
            while (_messageQueue.Count > 0)
            {
                Toast toast = null;
                if(_messageQueue.TryDequeue(out toast))
                {
                    Toast = toast;
                }
                else
                {
                    continue;
                }

                IsOpen = true;
                toast.Displayed();
                await Task.Delay(3000);
            }

            IsOpen = false;
            await Task.Delay(200);
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
