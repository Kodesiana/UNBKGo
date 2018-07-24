namespace UNBKGo.Service.Net
{
    public class ServerCommand
    {
        public const string TurnOff = "OFF";
        public const string Sync = "SYN";
        public const string Start = "STR";
        public const string Config = "CFG";
        public const string Register = "REG";
        public const string Beacon = "UNBKGo";

        public static string Combine(string command, string content)
        {
            return command + "|" + content;
        }

        public static string GetContent(string s)
        {
            return s.Substring(4, s.Length - 4);
        }

        public static string GetCommand(string s, out string content)
        {
            if (s.Contains("|"))
            {
                var split = s.Split('|');
                content = split[1];
                return split[0];
            }
            else
            {
                content = "";
                return s;
            }
        }
    }
}
