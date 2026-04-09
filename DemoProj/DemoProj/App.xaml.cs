using Microsoft.Extensions.DependencyInjection;

namespace DemoProj
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            UserAppTheme = AppTheme.Light;
            return new Window(new AppShell());
        }
    }
}