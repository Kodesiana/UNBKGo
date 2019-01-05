using System.Windows;
using Castle.Windsor;
using UNBKGo.Monitor.Container;
using UNBKGo.Monitor.Views;

namespace UNBKGo.Monitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IWindsorContainer Container { get; } = new WindsorContainer();

        public App()
        {
            InitializeComponent();
            Container.Install(new ServiceInstaller());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = Container.Resolve<MainWindow>();
            MainWindow?.Show();
            base.OnStartup(e);
        }
    }
}
