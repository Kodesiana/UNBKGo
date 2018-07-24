using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UNBKGo.Service;
using UNBKGo.Service.Net;

namespace UNBKGo.CLI
{
    class Program
    {
        private static AutoResetEvent _reset = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Task.Run(() => RunTask());
            _reset.WaitOne();
        }

        private static async void RunTask()
        {
            // start server
            Console.WriteLine("Starting server...");
            Console.Read();
            Console.WriteLine();

            var discoveryService = new UnbkServer();
            discoveryService.Start();
            

            // find server
            Console.WriteLine("Trying to find server...");
            Console.ReadKey();
            Console.WriteLine();

            var client = await UnbkClient.SearchServer();
            client.MachineShutdown += ClientMachineShutdown;
            client.ExambroUpdateRequested += Client_ExambroUpdateRequested;
            
            // shutdown
            Console.WriteLine("Shutdown signal...");
            Console.ReadKey();
            Console.WriteLine();
            await discoveryService.Nodes[0].SendShutdownRequest();
            
            // shutdown
            Console.WriteLine("Shutdown signal...");
            Console.ReadKey();
            Console.WriteLine();
            await discoveryService.Nodes[0].SendUpdateRequest();

            Console.ReadKey();
            _reset.Set();
        }

        private static void Client_ExambroUpdateRequested(object sender, EventArgs e)
        {
            Debug.Print("UPDATE Init");
        }

        private static void ClientMachineShutdown(object sender, EventArgs e)
        {
            Debug.Print("SHUTDOWN Init");
        }
    }
}
