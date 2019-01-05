using System;
using System.Threading.Tasks;

namespace UNBKGo.Service.Net
{
    public interface IClient
    {
        event EventHandler<ClientSetupEventArgs> Setup;
        event EventHandler Shutdown;
        event EventHandler Start;
        event EventHandler<ClientSyncEventArgs> Sync;

        string Host { get; }

        void SendReady();
        Task SearchServer();
    }
}