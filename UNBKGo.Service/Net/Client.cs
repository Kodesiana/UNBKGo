using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UNBKGo.Service.IO;

namespace UNBKGo.Service.Net
{
    public class Client : TcpBase, IClient
    {
        public event EventHandler Shutdown;
        public event EventHandler Start;
        public event EventHandler<ClientSetupEventArgs> Setup;
        public event EventHandler<ClientSyncEventArgs> Sync;

        public string Host { get; private set; }

        public Client()
        {
        }
        
        public async Task SearchServer()
        {
            using (var disoverer = new UdpClient())
            {
                disoverer.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                disoverer.Client.Bind(new IPEndPoint(IPAddress.Any, DiscoveryServer.DiscoveryPort));
                disoverer.EnableBroadcast = true;
                disoverer.AllowNatTraversal(true);

                // receive beacon
                var recv = await disoverer.ReceiveAsync();
                if (!Beacon.IsBeacon(recv.Buffer))
                    throw new ProtocolViolationException("The received beacon is not UNBKGo server.");

                var client = new TcpClient();
                client.Connect(recv.RemoteEndPoint.Address, DiscoveryServer.ServerPort);

                Host = recv.RemoteEndPoint.Address.ToString();
                SetClient(client);
            }
        }
        
        public void SendReady()
        {
            SendCommand(Command.Ready, null);
        }
        
        protected override void OnMessageReceived(MessageFrame message)
        {
            switch (message.Command)
            {
                case Command.Identify:
                    SendCommand(Command.Identify, "ff:ghg");
                    break;

                case Command.Sync:
                    SendCommand(Command.Sync, null);
                    OnSync(new ClientSyncEventArgs { Profile = (AppProfile)message.State });
                    break;

                case Command.StartExambro:
                    OnStart();
                    break;

                case Command.SequentialConfig:
                    OnSetup(new ClientSetupEventArgs { Profile = (NetworkProfile)message.State });
                    break;

                case Command.TurnOff:
                    OnShutdown();
                    break;
            }
        }

        #region Event Invocator

        protected virtual void OnShutdown()
        {
            Shutdown?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnStart()
        {
            Start?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSetup(ClientSetupEventArgs e)
        {
            Setup?.Invoke(this, e);
        }

        protected virtual void OnSync(ClientSyncEventArgs e)
        {
            Sync?.Invoke(this, e);
        }

        #endregion
    }
}
