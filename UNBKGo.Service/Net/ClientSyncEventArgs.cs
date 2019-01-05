using System;
using UNBKGo.Service.IO;

namespace UNBKGo.Service.Net
{
    public class ClientSyncEventArgs : EventArgs
    {
        public AppProfile Profile { get; set; }
    }
}
