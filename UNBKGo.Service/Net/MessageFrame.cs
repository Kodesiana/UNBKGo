using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace UNBKGo.Service.Net
{
    public class MessageFrame
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();
        private readonly byte[] _data;

        public static readonly object DefaultState = new object();

        public Command Command { get; set; }
        public object State { get; set; }

        public MessageFrame(byte[] msg)
        {
            // message length
            var size = BitConverter.ToInt64(msg, 0);
            if (msg.Length - 8 < size) throw new ProtocolViolationException("Message is fragmented.");

            // real message
            Command = (Command) BitConverter.ToInt64(msg, 8);
            State = Deserialize(msg.Skip(16).ToArray());
        }

        public MessageFrame(Command command, object state)
        {
            byte[] commandBuffer = BitConverter.GetBytes((long) command);
            byte[] stateBuffer = state == null ? Serialize(DefaultState) : Serialize(state);

            _data = BitConverter.GetBytes((long)(commandBuffer.Length + stateBuffer.Length))
                .Concat(commandBuffer)
                .Concat(stateBuffer).ToArray();
        }

        public byte[] ToBytes()
        {
            return _data;
        }

        private byte[] Serialize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                _formatter.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private object Deserialize(byte[] buffer)
        {
            using (var ms = new MemoryStream(buffer))
            {
                return _formatter.Deserialize(ms);
            }
        }
    }
}
