using System.Threading.Tasks;
using System.Windows.Forms;
using UNBKGo.Service.IO;
using UNBKGo.Service.Net;

namespace UNBKGo.Agent.Views
{
    public partial class MainView : Form
    {
        private readonly IClient _client = new Client();

        public MainView()
        {
            InitializeComponent();

            _client.Setup += _client_Setup;
            _client.Shutdown += _client_Shutdown;
            _client.Start += _client_Start;
            _client.Sync += _client_Sync;
            Task.Run(async () => await ConnectCallback());
        }
        
        private async Task ConnectCallback()
        {
            await _client.SearchServer();
        }

        private void _client_Sync(object sender, ClientSyncEventArgs e)
        {
            var host = _client.Host;
            FileRegistrar.GetUrlForFile(host, FileKind.Client);
            
        }

        private void _client_Start(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _client_Shutdown(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _client_Setup(object sender, ClientSetupEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
