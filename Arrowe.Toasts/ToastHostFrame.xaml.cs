using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Arrowe.Toasts
{
    public sealed partial class ToastHostFrame
    {
        Frame frame;

        public ToastHostFrame(Frame f)
        {
            InitializeComponent();

            frame = f;
            Children.Add(frame);
            DataContext = ToastHostVM.Singleton;

            toastContent.SizeChanged += (s, e) => thePopup.HorizontalOffset = ActualWidth - toastContent.ActualWidth - thePopup.Margin.Right;

        }

        private void ThePopup_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Toast t = ((ContentControl) sender).DataContext as Toast;
            t.Tapped();
        }
    }
}
