namespace UNBKGo.Service.Net
{
    public class UnbkConfig
    {
        public string IpAddress { get; set; }
        public string SubnetMask { get; set; }
        public string DefaultGateway { get; set; }

        public string PrimaryDns { get; set; }
        public string SecondaryDns { get; set; }

        public string Serialize()
        {
            return $"{IpAddress}|{SubnetMask}|{DefaultGateway}|{PrimaryDns}|{SecondaryDns}";
        }

        public static UnbkConfig Deserialize(string raw)
        {
            var configs = raw.Split('|');
            return new UnbkConfig
            {
                IpAddress = configs[0],
                SubnetMask = configs[1],
                DefaultGateway = configs[2],

                PrimaryDns = configs[3],
                SecondaryDns = configs[4]
            };
        }
    }
}
