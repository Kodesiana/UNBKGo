using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UNBKGo.Service;

namespace UNBKGo.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server...");
            var discoveryService = new UnbkDiscoveryServer();
            discoveryService.StartDiscovery();

            Console.Read();
            Console.WriteLine();

            Console.WriteLine("Trying to find server...");
            var server = new UnbkServer();
            server.StartListening();

            Console.Read();
            Console.WriteLine();
        }

        
    }
}
