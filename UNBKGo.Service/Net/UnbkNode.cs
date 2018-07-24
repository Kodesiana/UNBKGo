using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace UNBKGo.Service.Net
{
    public class UnbkNode
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public string MacAddress { get; set; }
        public string IpAddress { get; set; }

        private UnbkNode(TcpClient client, NetworkStream stream)
        {
            _client = client;
            _stream = stream;
        }

        public static async Task<UnbkNode> Create(TcpClient client)
        {
            var buff = new byte[1024];
            var stream = client.GetStream();
            
            var read = await stream.ReadAsync(buff, 0, buff.Length);
            var rightBuffer = new byte[read];
            Array.Copy(buff, 0, rightBuffer, 0, read);

            var welcome = new MessageFrame(rightBuffer).GetFramedString();
            if (!welcome.StartsWith(ServerCommand.Register)) return null;
            return new UnbkNode(client, stream)
            {
                MacAddress = welcome.Substring(4, welcome.Length - 4),
                IpAddress = ((IPEndPoint) client.Client.RemoteEndPoint).Address.ToString()
            };
        }

        public void Close()
        {
            _client.Close();
        }

        public async Task SendShutdownRequest()
        {
            await SendCommand(ServerCommand.TurnOff);
        }

        public async Task SendUpdateRequest()
        {
            await SendCommand(ServerCommand.Sync);
        }

        public async Task SendExambroStartRequest()
        {
            await SendCommand(ServerCommand.Start);
        }

        public async Task SendConfig(UnbkConfig config)
        {
            var command = ServerCommand.Combine(ServerCommand.Config, config.Serialize());
            await SendCommand(command);
        }

        private async Task SendCommand(string msg)
        {
            var buffer = new MessageFrame(msg).GetFramedBuffer();
            await _stream.WriteAsync(buffer, 0, buffer.Length);
            await _stream.FlushAsync();
        }
    }
}

