using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace UNBKGo.Service
{
    public class UnbkNode
    {
        private TcpClient _client;
        private IPEndPoint _endPoint;

        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        
        public UnbkNode(TcpClient client)
        {
            _client = client;
            IpAddress = ((IPEndPoint) client.Client.RemoteEndPoint).Address.ToString();
        }

        public async Task SendShutdownRequest()
        {
            await SendCommand(MessageFrame.StringToBuffer(ServerCommand.TurnOff));
        }

        public async Task SendUpdateRequest()
        {
            await SendCommand(MessageFrame.StringToBuffer(ServerCommand.Sync));
        }

        public async Task SendExambroStartRequest()
        {
            await SendCommand(MessageFrame.StringToBuffer(ServerCommand.Start));
        }

        public async Task SendCommand(byte[] msg)
        {
            await _client.SendAsync(msg, msg.Length, _endPoint);
        }

        private void ReceiveCallback()
        {
            while (_client.Connected)
            {
                
            }
        }
    }
}
