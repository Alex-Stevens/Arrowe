using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Arrowe.Toasts;

namespace Arrowe.DemoApp
{
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer { get; set; }
        private Random random;

        public MainPage()
        {
            this.InitializeComponent();

            random = new Random((int)System.DateTime.Now.Ticks);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(8);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Toast toast;
            int random = this.random.Next(0, 2);

            if (random == 0)
            {
                toast = new Toasts.SimpleToast()
                {
                    Colour = Colors.Green,
                    Heading = "Pass",
                    Message = "Success",
                    Icon = Toasts.SimpleToast.PASS_ICON,
                    Sound = null
                };
            }
            else
            {
                toast = new Toasts.SimpleToast()
                {
                    Colour = Colors.Red,
                    Heading = "Fail",
                    Message = "Unable to complete task",
                    Icon = Toasts.SimpleToast.FAIL_ICON,
                    Sound = Toasts.SimpleToast.ERROR_SOUND
                };
            }

            ToastHostVM.Singleton.AddToastToQueue(toast);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var toast = new Toasts.SaveCompleteToast()
            {
                Colour = Colors.Pink,
                Message = "This is a generated toast",
                Icon = Toasts.SimpleToast.PASS_ICON
            };

            ToastHostVM.Singleton.AddToastToQueue(toast);
        }
    }
}
