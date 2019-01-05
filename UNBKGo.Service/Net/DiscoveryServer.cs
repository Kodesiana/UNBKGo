using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace UNBKGo.Service.Net
{
    public class DiscoveryServer : IDiscoveryServer
    {
        public const int ServerPort = 2106;
        public const int DiscoveryPort = 2105;
        
        private readonly CancellationTokenSource _serverCancellation;
        private readonly Thread _discoveryThread;
        private readonly Thread _serverThread;
        private readonly UdpClient _discoveryClient;
        private readonly TcpListener _serverClient;

        public event EventHandler<NodeConnectedEventArgs> NodeConnected;

        public List<Node> Nodes { get; }

        public DiscoveryServer()
        {
            Nodes = new List<Node>();
            _serverClient = new TcpListener(IPAddress.Any, ServerPort);
            _discoveryClient = new UdpClient();
            _discoveryClient.AllowNatTraversal(true);

            _serverCancellation = new CancellationTokenSource();
            _discoveryThread = new Thread(DiscoveryCallback) {IsBackground = true};
            _serverThread = new Thread(ListenCallback) {IsBackground = true};
        }

        #region Server

        public void Start()
        {
            _discoveryThread.Start();
            _serverClient.Start();
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

            // send
            await _discoveryClient.SendAsync(datagram, datagram.Length, new IPEndPoint(IPAddress.Broadcast, 8900));
        }

        private async void ListenCallback()
        {
            while (!_serverCancellation.IsCancellationRequested)
            {
                var client = await _serverClient.AcceptTcpClientAsync();
                var node = new Node(client);
                Nodes.Add(node);
                OnNodeConnected(new NodeConnectedEventArgs
                {
                    Node = node
                });
            }
        }

        private async void DiscoveryCallback()
        {
            var endPoint = new IPEndPoint(IPAddress.Broadcast, DiscoveryPort);
            while (!_serverCancellation.IsCancellationRequested)
            {
                await _discoveryClient.SendAsync(Beacon.BeaconPayload, Beacon.BeaconPayload.Length, endPoint);
                await Task.Delay(1000);
            }
        }

        #endregion

        protected virtual void OnNodeConnected(NodeConnectedEventArgs e)
        {
            NodeConnected?.Invoke(this, e);
        }
    }
}
