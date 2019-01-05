using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UNBKGo.Service.IO;

namespace UNBKGo.Service.Net
{
    public abstract class TcpBase : IDisposable
    {
        protected TcpClient Client;
        protected NetworkStream Stream;

        private Thread _thread;
        private CancellationTokenSource _cancellation;
        
        protected void SetClient(TcpClient client)
        {
            Client = client;
            Client.NoDelay = true;
            Stream = client.GetStream();

            _cancellation = new CancellationTokenSource();
            _thread = new Thread(ReceiveCallback) { IsBackground = true };
            _thread.Start();
        }

        public void Close()
        {
            Dispose();
        }

        protected void SendCommand(Command command, object parameter)
        {
            var msg = new MessageFrame(command, parameter);
            Stream.Write(msg);
            Stream.Flush();
            Thread.Sleep(1000);
        }

        private void ReceiveCallback()
        {
            while (Client.Connected && !_cancellation.IsCancellationRequested)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        // receive the message
                        while (Stream.DataAvailable)
                        {
                            var buffer = new byte[1024];
                            Stream.Read(buffer, 0, buffer.Length);
                            ms.Write(buffer, 0, buffer.Length);
                        }

                        if (ms.Length == 0) continue;
                        OnMessageReceived(new MessageFrame(ms.ToArray()));
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
            }
        }

        protected abstract void OnMessageReceived(MessageFrame message);

        #region IDisposable Support
        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                Stream?.Close();
                Client?.Close();
            }

            Stream = null;
            Client = null;

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
