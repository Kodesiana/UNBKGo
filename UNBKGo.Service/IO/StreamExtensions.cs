using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UNBKGo.Service.Net;

namespace UNBKGo.Service.IO
{
    public static class StreamExtensions
    {
        private static readonly BinaryFormatter _formatter = new BinaryFormatter();

        public static void Write(this Stream stream, MessageFrame message)
        {
            var buffer = message.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
    }
}
