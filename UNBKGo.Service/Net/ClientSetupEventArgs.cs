using System;

namespace UNBKGo.Service.Net
{
    public class ClientSetupEventArgs : EventArgs
    {
        public NetworkProfile Profile { get; set; }
    }
}
