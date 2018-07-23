using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UNBKGo.Service
{
    public static class MessageFrame
    {
        public static byte[] StringToBuffer(string s)
        {
            return FrameBuffer(Encoding.UTF8.GetBytes(s));
        }

        public static string BufferToString(byte[] buffer)
        {
            return UnframeBuffer(buffer, out byte[] result) ? Encoding.UTF8.GetString(result) : null;
        }

        public static byte[] FrameBuffer(byte[] buffer)
        {
            var serialized = new List<byte>();
            serialized.AddRange(BitConverter.GetBytes((long) buffer.Length));
            serialized.AddRange(buffer);

            return serialized.ToArray();
        }

        public static bool UnframeBuffer(byte[] arr, out byte[] result)
        {
            var size = BitConverter.ToInt64(arr, 0);
            using (var ms = new MemoryStream(arr, 8, arr.Length - 8))
            {
                if (ms.Length != size)
                {
                    result = null;
                    return false;
                }
                else
                {
                    result = ms.ToArray();
                    return true;
                }
            }
        }
    }
}
