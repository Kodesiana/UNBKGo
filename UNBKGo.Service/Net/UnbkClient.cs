using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace UNBKGo.Service.Net
{
    public class UnbkClient
    {
        private CancellationTokenSource _cancellation;
        private Thread _thread;
        private TcpClient _client;
        private NetworkStream _stream;

        public event EventHandler MachineShutdown;
        public event EventHandler<ConfigArrivedEventArgs> ConfigArrived;
        public event EventHandler ExambroStartRequested;
        public event EventHandler ExambroUpdateRequested;

        private UnbkClient(TcpClient client, NetworkStream stream)
        {
            _client = client;
            _stream = stream;

            _cancellation = new CancellationTokenSource();
            _thread = new Thread(ReceiveCallback) {IsBackground = true};
            _thread.Start();
        }

        private static async Task SendMacAddress(NetworkStream stream)
        {
            var command = ServerCommand.Combine(ServerCommand.Register, "ff:ee:ee:ee:rr:ee");
            var frame = new MessageFrame(command).GetFramedBuffer();
            await stream.WriteAsync(frame, 0, frame.Length);
            await stream.FlushAsync();
        }

        public static async Task<UnbkClient> Create(IPAddress address)
        {
            var client = new TcpClient();
            client.Connect(address, UnbkServer.ServerPort);
            var stream = client.GetStream();

            await SendMacAddress(stream);
            return new UnbkClient(client, stream);
        }

        public static async Task<UnbkClient> SearchServer()
        {
            using (var disoverer = new UdpClient())
            {
                disoverer.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                disoverer.Client.Bind(new IPEndPoint(IPAddress.Any, UnbkServer.DiscoveryPort));
                disoverer.EnableBroadcast = true;
                disoverer.AllowNatTraversal(true);
                
                // receive beacon
                var recv = await disoverer.ReceiveAsync();
                var beacon = new MessageFrame(recv.Buffer);

                // send mac
                if (beacon.GetFramedString() != ServerCommand.Beacon) return null;
                return await Create(recv.RemoteEndPoint.Address);
            }
        }

        public void Disconnect()
        {
            _cancellation.Cancel();
            _client.Close();
        }

        private async void ReceiveCallback()
        {
            while (_client.Connected)
            {
                try
                {
                    var message = new MessageFrame();
                    do
                    {
                        var buffer = new byte[1024];
                        var read = await _stream.ReadAsync(buffer, 0, buffer.Length);
                        var composed = new byte[read];
                        Array.Copy(buffer, 0, composed, 0, read);

                        message.WriteFramedBuffer(composed);
                    } while (!message.IsCompleted);

                    var raw = message.GetFramedString();
                    switch (ServerCommand.GetCommand(raw, out string content))
                    {
                        case ServerCommand.TurnOff:
                            OnShutdownRequested();
                            break;
                        case ServerCommand.Sync:
                            OnExambroUpdateRequested();
                            break;
                        case ServerCommand.Start:
                            OnExambroStartRequested();
                            break;
                        case ServerCommand.Config:
                            OnConfigArrived(new ConfigArrivedEventArgs
                            {
                                Config = UnbkConfig.Deserialize(content)
                            });
                            break;
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
            }
        }

        #region Event Invocator

        protected virtual void OnExambroStartRequested()
        {
            ExambroStartRequested?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnShutdownRequested()
        {
            MachineShutdown?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnExambroUpdateRequested()
        {
            ExambroUpdateRequested?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnConfigArrived(ConfigArrivedEventArgs e)
        {
            ConfigArrived?.Invoke(this, e);
        } 

        #endregion
    }
}
