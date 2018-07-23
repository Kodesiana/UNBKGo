using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UNBKGo.Service
{
    public class UnbkClient
    {
        private readonly UdpClient _client;
        private CancellationTokenSource _connectCancellation;

        public event EventHandler ShutdownRequested;
        public event EventHandler ExambroStartRequested;
        public event EventHandler ExambroUpdateRequested;

        public UnbkClient(IPAddress remoteHost)
        {
            _client = new UdpClient();
            _connectCancellation = new CancellationTokenSource();
        }

        public static async Task<UnbkClient> SearchServer()
        {
            using (var disoverer = new UdpClient())
            {
                disoverer.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                disoverer.Client.Bind(new IPEndPoint(IPAddress.Any, 0));
                disoverer.EnableBroadcast = true;
                disoverer.AllowNatTraversal(true);
                
                // receive beacon
                var recv = await disoverer.ReceiveAsync();
                var beacon = MessageFrame.BufferToString(recv.Buffer);
                
                // send mac
                if (beacon != "UNBKGo") return null;
                var buffer = MessageFrame.StringToBuffer("MAC ADDRESS");
                await disoverer.SendAsync(buffer, buffer.Length, recv.RemoteEndPoint);
                return new UnbkClient(recv.RemoteEndPoint.Address);
            }
        }

        public void Disconnect()
        {
            _connectCancellation.Cancel();
        }

        private async void DiscoveryCallback()
        {
            while (!_connectCancellation.IsCancellationRequested)
            {
                var packet = await _client.ReceiveAsync();
                var command = MessageFrame.BufferToString(packet.Buffer);


                await Task.Delay(1000);
            }
        }


        protected virtual void OnExambroStartRequested()
        {
            ExambroStartRequested?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnShutdownRequested()
        {
            ShutdownRequested?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnExambroUpdateRequested()
        {
            ExambroUpdateRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
