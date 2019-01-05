using System.Net;
using System.Net.Sockets;
using UNBKGo.Service.IO;

namespace UNBKGo.Service.Net
{
    public class Node : TcpBase
    {
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public NodeStatus Status { get; set; }

        public Node(TcpClient client)
        {
            // request identification
            SetClient(client);
            IpAddress = ((IPEndPoint) client.Client.RemoteEndPoint).Address.ToString();
            SendCommand(Command.Identify, null);
        }
        
        #region Commands

        public void SendShutdown()
        {
            SendCommand(Command.TurnOff, null);
            SendCommand(Command.Ready, null);
        }

        public void SendSync(AppProfile profile)
        {
            SendCommand(Command.Sync, profile);
            SendCommand(Command.Ready, null);
        }

        public void SendExambroStart()
        {
            SendCommand(Command.StartExambro, null);
            SendCommand(Command.Ready, null);
        }

        public void SendConfig(NetworkProfile config)
        {
            SendCommand(Command.SequentialConfig, config);
            SendCommand(Command.Ready, null);
        }

        #endregion

        protected override void OnMessageReceived(MessageFrame message)
        {
            switch (message.Command)
            {
                case Command.Identify:
                    MacAddress = message.State.ToString();
                    break;

                case Command.Ready:
                    Status = NodeStatus.Connected;
                    break;

                case Command.Sync:
                    Status = NodeStatus.Syncing;
                    break;
            }
        }
    }
}

