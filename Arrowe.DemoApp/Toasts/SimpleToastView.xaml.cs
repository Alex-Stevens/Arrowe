namespace Arrowe.DemoApp.Toasts
{
    public sealed partial class SimpleToastView
    {
        public SimpleToastView(SimpleToast context)
        {
            this.InitializeComponent();
            DataContext = context;
        }

        public void Play()
        {
            Media.Play();
        }
    }
}
