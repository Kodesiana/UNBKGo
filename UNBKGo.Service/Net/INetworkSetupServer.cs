using System;
using System.Net;

namespace UNBKGo.Service.Net
{
    public interface INetworkSetupServer
    {
        IPAddress BaseAddress { get; set; }
        int AddressRange { get; set; }
        IPAddress SubnetMask { get; set; }
        IPAddress DefaultGateway { get; set; }
        IPAddress PrimaryDns { get; set; }
        IPAddress SecondaryDns { get; set; }

        event EventHandler<NetworkSetupEventArgs> Setup;
        event EventHandler<NetworkFinishedEventArgs> Finished;

        void Start();
        void Stop();
    }
}
