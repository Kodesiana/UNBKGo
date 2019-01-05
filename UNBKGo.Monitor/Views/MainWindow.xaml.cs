using MahApps.Metro.Controls;
using UNBKGo.Monitor.ViewModels;

namespace UNBKGo.Monitor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            HamburgerMenuControl.Content = App.Container.Resolve<HomeViewModel>();
        }

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            HamburgerMenuControl.IsPaneOpen = false;
            switch (((HamburgerMenuGlyphItem)HamburgerMenuControl.SelectedItem).Label.ToUpperInvariant())
            {
                case "BERANDA":
                    HamburgerMenuControl.Content = App.Container.Resolve<HomeViewModel>();
                    break;

                case "JARINGAN":
                    HamburgerMenuControl.Content = App.Container.Resolve<NetworkViewModel>();
                    break;

                case "SERVER":
                    HamburgerMenuControl.Content = App.Container.Resolve<ServerViewModel>();
                    break;

                case "BERKAS":
                    HamburgerMenuControl.Content = App.Container.Resolve<FileStoreViewModel>();
                    break;

                case "WAKE ON LAN":
                    HamburgerMenuControl.Content = App.Container.Resolve<WakeLanViewModel>();
                    break;

                default:
                    HamburgerMenuControl.Content = App.Container.Resolve<HomeViewModel>();
                    break;
            }
        }

    }
}
