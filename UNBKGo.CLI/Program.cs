using System;
using System.Threading;
using System.Threading.Tasks;
using UNBKGo.Service.IO;
using UNBKGo.Service.Net;

namespace UNBKGo.CLI
{
    class Program
    {
        private static AutoResetEvent _reset = new AutoResetEvent(false);
        private static AutoResetEvent _resetNodeAdded = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Task.Run(() => RunTask());
            _reset.WaitOne();
            Console.Read();
        }

        private static async void RunTask()
        {
            var discoveryService = new DiscoveryServer();
            discoveryService.NodeConnected += DiscoveryService_NodeConnected;

            // start server
            Console.WriteLine("Starting server...");
            discoveryService.Start();
            Console.WriteLine("Server started!");
            Console.WriteLine();

            // find server
            Console.WriteLine("Trying to find server...");
            var client = await Client.SearchServer();
            Console.WriteLine("Server found! Connected");
            Console.WriteLine();

            client.Shutdown += ClientMachineShutdown;
            client.Sync += Client_ExambroUpdateRequested;
            

            // shutdown
            _resetNodeAdded.WaitOne();
            var node = discoveryService.Nodes[0];

            Console.WriteLine();
            Console.WriteLine("Shutdown signal...");
            node.SendShutdown();
            Console.WriteLine("Signal sent.");
            
            // sync
            Console.WriteLine();
            Console.WriteLine("Sync signal...");
            node.SendSync(new AppProfile
            {
                ChromeHash = "rrrrr",
                ExamBrowserHash = "yddhgfghfhg",
                NetFrameworkHash = "dfgdgdgfdgfgd"
            });
            Console.WriteLine("Signal sent.");

            Console.Read();
            _reset.Set();
        }

        private static void DiscoveryService_NodeConnected(object sender, NodeConnectedEventArgs e)
        {
            Console.WriteLine("Node conneced");
            _resetNodeAdded.Set();
        }

        private static void Client_ExambroUpdateRequested(object sender, ClientSyncEventArgs e)
        {
            Console.WriteLine("Chrome {0}", e.Profile.ChromeHash);
            Console.WriteLine("ExamBrowser {0}", e.Profile.ExamBrowserHash);
            Console.WriteLine("Net Framework {0}", e.Profile.NetFrameworkHash);
            Console.WriteLine("UPDATE Init");
        }

        private static void ClientMachineShutdown(object sender, EventArgs e)
        {
            Console.WriteLine("SHUTDOWN Init");
        }
    }
}
