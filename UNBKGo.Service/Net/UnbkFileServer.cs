using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace UNBKGo.Service.Net
{
    public class UnbkFileServer
    {
        public const string ClientAppUri = "/client";
        public const string NetFrameworkUri = "/netfx";
        public const string ChromeUri = "/chrome";
        public const string ExambroUri = "/exambro";

        private HttpListener _listener;
        

        public UnbkFileServer()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:2805/");
        }

        public void Start()
        {
            _listener.Start();
            Task.Run(() => ListenRequestCallback());
        }

        private void ListenRequestCallback()
        {
            while (_listener.IsListening)
            {
                var context = _listener.GetContext();
                Task.Run(() => HandleRequestCallback(context));
            }
        }

        private void HandleRequestCallback(HttpListenerContext context)
        {
            var requestedFile = GetFilePath(context.Request.Url, out string contentType);
            context.Response.StatusCode = 200;
            context.Response.SendChunked = true;
            context.Response.ContentType = contentType;

            using (var fs = new FileStream(requestedFile, FileMode.Open))
            {
                fs.CopyTo(context.Response.OutputStream);
            }

            context.Response.Close();
        }

        private string GetFilePath(Uri uri, out string contentType)
        {
            contentType = "application/octet-stream";
            string setupPath = AppDomain.CurrentDomain.BaseDirectory;
            switch (uri.AbsolutePath)
            {
                case ClientAppUri:
                    return Path.Combine(setupPath, "www", "UNBKGoClient.zip");

                case NetFrameworkUri:
                    return Path.Combine(setupPath, "www", "NetFxSetup.exe");

                case ChromeUri:
                    return Path.Combine(setupPath, "www", "ChromeSetup.exe");

                case ExambroUri:
                    return Path.Combine(setupPath, "www", "Exambro.zip");

                default:
                    contentType = "text/html";
                    return Path.Combine(setupPath, "www", "index.html");
            }
        }
    }
}
