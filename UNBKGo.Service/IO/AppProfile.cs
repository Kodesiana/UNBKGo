using System;

namespace UNBKGo.Service.IO
{
    [Serializable]
    public class AppProfile
    {
        public string ChromeHash { get; set; }
        public string ExamBrowserHash { get; set; }
        public string NetFrameworkHash { get; set; }
        public string ClientHash { get; set; }
    }
}
