using System;
using System.IO;
using System.Text;

namespace UNBKGo.Service.Net
{
    public class MessageFrame
    {
        private MemoryStream _ms;

        public long TotalLength { get; private set; } = -1;
        public bool IsCompleted => _ms.Length - 8 == TotalLength;

        public MessageFrame()
        {
            _ms = new MemoryStream();
        }

        public MessageFrame(byte[] buffer)
        {
            _ms = new MemoryStream();

            TotalLength = BitConverter.ToInt64(buffer, 0);
            _ms.Write(buffer, 0, buffer.Length);
        }

        public MessageFrame(string message)
        {
            _ms = new MemoryStream();
            var buffer = Encoding.UTF8.GetBytes(message);
            var lengthBuffer = BitConverter.GetBytes(buffer.LongLength);

            _ms.Write(lengthBuffer, 0, lengthBuffer.Length);
            _ms.Write(buffer, 0, buffer.Length);
        }

        public void WriteFramedBuffer(byte[] buffer)
        {
            if (TotalLength == -1) TotalLength = BitConverter.ToInt64(buffer, 0);
            _ms.Write(buffer, 0, buffer.Length);
        }

        public byte[] GetFramedBuffer()
        {
            _ms.Position = 0;
            return _ms.ToArray();
        }

        public string GetFramedString()
        {
            _ms.Position = 0;

            var buffer = new byte[8];
            _ms.Read(buffer, 0, buffer.Length);
            var size = BitConverter.ToInt64(buffer, 0);

            buffer = new byte[size];
            _ms.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
