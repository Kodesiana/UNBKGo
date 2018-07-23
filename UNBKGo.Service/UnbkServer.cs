using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UNBKGo.Service
{
    public class UnbkServer
    {
        public const int ServerPort = 2106;
        public const int DiscoveryPort = 2105;
        public static readonly IPEndPoint BroadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, DiscoveryPort);

        private readonly byte[] _discoveryBeacon = Encoding.UTF8.GetBytes("UNBKGo");
        private readonly Thread _discoveryThread;
        private readonly Thread _serverThread;
        private readonly CancellationTokenSource _serverCancellation;
        private readonly UdpClient _discoveryClient;
        private readonly TcpListener _serverListener;

        public HashSet<UnbkNode> Nodes { get; }

        public UnbkServer()
        {
            // server
            _serverListener = new TcpListener(IPAddress.Loopback, ServerPort);
            
            // discovery
            _discoveryClient = new UdpClient();
            _discoveryClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _discoveryClient.Client.Bind(new IPEndPoint(IPAddress.Any, DiscoveryPort));
            _discoveryClient.AllowNatTraversal(true);

            Nodes = new HashSet<UnbkNode>();
            _serverCancellation = new CancellationTokenSource();
            _discoveryThread = new Thread(DiscoveryCallback) {IsBackground = true};
            _serverThread = new Thread(ListenCallback) {IsBackground = true};
        }

        #region Server

        public void StartListening()
        {
            _serverListener.Start();
            _discoveryThread.Start();
            _serverThread.Start();
        }

        public void Stop()
        {
            _serverCancellation.Cancel();
        }
        
        public async Task SendWakeOnRequest(string macAddress)
        {
            byte[] datagram = new byte[102];
            string[] macDigits = macAddress.Split(macAddress.Contains("-") ? '-' : ':');

            if (macDigits.Length != 6)
            {
                throw new ArgumentException("Incorrect MAC address supplied!");
            }

            // fill 6 bytes with 0xFF
            for (int i = 0; i < 6; i++)
            {
                datagram[i] = 0xff;
            }

            // fill remaining buffer to MAC address
            var start = 6;
            for (var i = 0; i < 16; i++)
            {
                for (var x = 0; x < 6; x++)
                {
                    datagram[start + i * 6 + x] = byte.Parse(macDigits[x], NumberStyles.HexNumber);
                }
            }
            var endpoint = new IPEndPoint(IPAddress.Broadcast, 8900);
            await _discoveryClient.SendAsync(datagram, datagram.Length, endpoint);
        }

        private async void ListenCallback()
        {
            while (!_serverCancellation.IsCancellationRequested)
            {
                var client = await _serverListener.AcceptTcpClientAsync();
                Nodes.Add(new UnbkNode(client));
            }
        }

        private async void DiscoveryCallback()
        {
            while (!_serverCancellation.IsCancellationRequested)
            {
                await _discoveryClient.SendAsync(_discoveryBeacon, _discoveryBeacon.Length, BroadcastEndPoint);
                await Task.Delay(1000);
            }
        }

        #endregion

    }
}
