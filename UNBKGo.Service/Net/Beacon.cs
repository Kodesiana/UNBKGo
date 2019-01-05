using System.Linq;
using System.Text;

namespace UNBKGo.Service.Net
{
    public static class Beacon
    {
        public static readonly byte[] BeaconPayload = Encoding.UTF8.GetBytes("UNBKGo");
        
        public static bool IsBeacon(byte[] buffer)
        {
            return buffer.SequenceEqual(BeaconPayload);
        }
    }
}
