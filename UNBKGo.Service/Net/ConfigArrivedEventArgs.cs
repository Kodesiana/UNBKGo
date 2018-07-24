using System;

namespace UNBKGo.Service.Net
{
    public class ConfigArrivedEventArgs : EventArgs
    {
        public UnbkConfig Config { get; set; }
    }
}
