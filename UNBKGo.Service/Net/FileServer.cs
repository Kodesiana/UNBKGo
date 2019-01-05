using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using UNBKGo.Service.IO;

namespace UNBKGo.Service.Net
{
    public class UnbkFileServer : IUnbkFileServer
    {
        private readonly IFileRegistrar _registrar;
        private readonly HttpListener _listener;
        private Thread _thread;
        
        public UnbkFileServer(IFileRegistrar registrar)
        {
            _registrar = registrar;
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:2805/");
        }

        public void Start()
        {
            _listener.Start();
            _thread = new Thread(ListenRequestCallback) {IsBackground = true};
            _thread.Start();
        }

        public void Stop()
        {
            _listener.Stop();
        }

        #region Private Methods

        private void ListenRequestCallback()
        {
            while (_listener.IsListening)
            {
                var context = _listener.GetContext();
                Task.Run(async () => await HandleRequestCallback(context));
            }
        }

        private async Task HandleRequestCallback(HttpListenerContext context)
        {
            var requestedFile = _registrar.GetDescriptorForRequest(context.Request.Url);
            context.Response.SendChunked = true;
            context.Response.StatusCode = requestedFile.IsExist ? 200 : 404;
            context.Response.ContentType = requestedFile.MimeType;

            using (var fs = new FileStream(requestedFile.FilePath, FileMode.Open))
            {
                await fs.CopyToAsync(context.Response.OutputStream);
            }

            context.Response.Close();
        }

        #endregion
    }
}
