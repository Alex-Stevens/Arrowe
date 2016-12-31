using System;
using Windows.UI;
using Arrowe.Toasts;

namespace Arrowe.DemoApp.Toasts
{
    class SaveCompleteToast : Toast
    {
        public SaveCompleteToast()
        {
            View = new SaveCompleteToastView();
        }

        public static readonly Uri PASS_ICON = new Uri("ms-appx:///Assets/tick.png", UriKind.Absolute);
        public static readonly Uri FAIL_ICON = new Uri("ms-appx:///Assets/fail.png", UriKind.Absolute);
        public static readonly Uri WARNING_ICON = new Uri("ms-appx:///Assets/warning.png", UriKind.Absolute);

        private string _heading = "";
        private string _message = "";
        private Color _colour = Colors.Blue;
        private Uri _icon = null;

        public string Heading
        {
            get
            {
                return _heading;
            }
            set
            {
                if (value != _heading)
                {
                    _heading = value;
                    OnPropertyChanged(nameof(Heading));
                }
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (value != _message)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        public Color Colour
        {
            get
            {
                return _colour;
            }
            set
            {
                if (value != _colour)
                {
                    _colour = value;
                    OnPropertyChanged(nameof(Colour));
                }
            }
        }

        public Uri Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                if (value != _icon)
                {
                    _icon = value;
                    OnPropertyChanged(nameof(Icon));
                }
            }
        }

        public override void Displayed()
        {
        }

        public override void Tapped()
        {

        }
    }
}
