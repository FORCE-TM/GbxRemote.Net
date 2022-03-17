using System;
using System.Threading;
using System.Threading.Tasks;
using GbxRemoteNet;
using GbxRemoteNet.Structs;

namespace CallbackExample
{
    internal class Program
    {
        private static readonly CancellationTokenSource cancelToken = new();

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

            // register callback events
            client.OnPlayerConnect += Client_OnPlayerConnect;
            client.OnPlayerDisconnect += Client_OnPlayerDisconnect;
            client.OnPlayerChat += Client_OnPlayerChat;
            client.OnEcho += Client_OnEcho;
            client.OnBeginChallenge += Client_OnBeginChallenge;
            client.OnEndChallenge += Client_OnEndChallenge;
            client.OnStatusChanged += Client_OnStatusChanged;
            client.OnPlayerInfoChanged += Client_OnPlayerInfoChanged;
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;

            // enable callbacks
            await client.EnableCallbacksAsync();

            // wait indefinitely or until disconnect
            WaitHandle.WaitAny(new[] { cancelToken.Token.WaitHandle });
        }

        private static Task Client_OnDisconnected()
        {
            Console.WriteLine("Client disconnected, exiting ...");
            cancelToken.Cancel();
            return Task.CompletedTask;
        }

        private static Task Client_OnConnected()
        {
            Console.WriteLine("Connected!");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerInfoChanged(PlayerInfo playerInfo)
        {
            Console.WriteLine($"Player info changed for: {playerInfo.NickName}");
            return Task.CompletedTask;
        }

        private static Task Client_OnStatusChanged(int statusCode, string statusName)
        {
            Console.WriteLine($"[Status Changed] {statusCode}: {statusName}");
            return Task.CompletedTask;
        }

        private static Task Client_OnBeginChallenge(ChallengeInfo challenge, bool warmUp, bool matchContinuation)
        {
            Console.WriteLine($"Begin challenge: {challenge.Name}");
            return Task.CompletedTask;
        }

        private static Task Client_OnEndChallenge(PlayerRanking[] rankings, ChallengeInfo challenge, bool wasWarmUp, bool matchContinuesOnNextChallenge, bool restartChallenge)
        {
            Console.WriteLine($"End challenge: {challenge.Name}");
            return Task.CompletedTask;
        }

        private static Task Client_OnEcho(string internalParam, string publicParam)
        {
            Console.WriteLine($"[Echo] internal: {internalParam}, public: {publicParam}");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerChat(int playerUid, string login, string text, bool isRegisteredCmd)
        {
            Console.WriteLine($"[Chat] {login}: {text}");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerDisconnect(string login)
        {
            Console.WriteLine($"Player disconnected: {login}");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerConnect(string login, bool isSpectator)
        {
            Console.WriteLine($"Player connected: {login}");
            return Task.CompletedTask;
        }
    }
}
