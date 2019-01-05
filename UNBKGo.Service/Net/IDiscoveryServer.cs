using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UNBKGo.Service.Net
{
    public interface IDiscoveryServer
    {
        List<Node> Nodes { get; }

        event EventHandler<NodeConnectedEventArgs> NodeConnected;

        Task SendWakeOnRequest(string macAddress);
        void Start();
        void Stop();
    }
}