using System;
using System.Threading.Tasks;
using GbxRemoteNet;

namespace BasicExample
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

            // get player list
            var players = await client.GetPlayerListAsync();

            foreach (var player in players)
            {
                var info = await client.GetDetailedPlayerInfoAsync(player.Login);

                Console.WriteLine($"Login: {player.Login}, NickName: {player.NickName}, IPAddress: {info.IPAddress}");
            }

            // disconnect and clean up
            await client.DisconnectAsync();
        }
    }
}
