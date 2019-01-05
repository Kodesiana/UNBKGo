namespace UNBKGo.Service.Net
{
    public class NetworkProfile
    {
        public int Profile { get; set; }

        public string IpAddress { get; set; }
        public string SubnetMask { get; set; }
        public string DefaultGateway { get; set; }

        public string PrimaryDns { get; set; }
        public string SecondaryDns { get; set; }
    }
}
