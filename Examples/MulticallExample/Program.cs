using GbxRemoteNet;
using GbxRemoteNet.XmlRpc.Types;
using System;
using System.Threading.Tasks;

namespace MulticallExample
{
    internal class Program
    {
        private static async Task Main()
        {
            // create client instance
            var client = new GbxRemoteClient("127.0.0.1", 5000);

            // connect
            if (!await client.ConnectAsync())
            {
                Console.WriteLine("Failed to login.");
                return;
            }

            // authenticate
            if (!await client.AuthenticateAsync("SuperAdmin", "SuperAdmin"))
            {
                Console.WriteLine("Failed to authenticate.");
                return;
            }

            Console.WriteLine("Connected and authenticated!");

            // build the multicall
            MultiCall multicall = new();
            multicall.Add(client.GetChatLinesAsync)
                .Add("system.methodHelp", "Authenticate")
                .Add(nameof(client.GetVersionAsync))
                .Add("NonExistentMethod");

            // send all the calls
            object[] results = await client.MultiCallAsync(multicall);

            foreach (var result in results)
            {
                if (result is XmlRpcFault fault)
                {
                    Console.WriteLine($"Method call failed: ({fault.FaultCode}) {fault.FaultString}");
                }
                else
                {
                    Console.WriteLine($"Method Result: {result}");
                }
            }

            // disconnect and clean up
            await client.DisconnectAsync();
        }
    }
}
