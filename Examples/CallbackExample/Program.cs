using GbxRemoteNet;
using GbxRemoteNet.XmlRpc.Packets;
using GbxRemoteNet.XmlRpc.Types;
using System;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using GbxRemoteNet.Structs;

namespace CallbackExample {
    class Program {
        static CancellationTokenSource cancelToken = new CancellationTokenSource();

        static async Task Main(string[] args) {
            // create client instance
            GbxRemoteClient client = new("127.0.0.1", 5000);

            // connect and login
            if (!await client.LoginAsync("SuperAdmin", "SuperAdmin")) {
                Console.WriteLine("Failed to login.");
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

        private static Task Client_OnDisconnected() {
            Console.WriteLine("Client disconnected, exiting ...");
            cancelToken.Cancel();
            return Task.CompletedTask;
        }

        private static Task Client_OnConnected() {
            Console.WriteLine("Connected!");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerInfoChanged(SPlayerInfo playerInfo) {
            Console.WriteLine($"Player info changed for: {playerInfo.NickName}");
            return Task.CompletedTask;
        }

        private static Task Client_OnStatusChanged(int statusCode, string statusName) {
            Console.WriteLine($"[Status Changed] {statusCode}: {statusName}");
            return Task.CompletedTask;
        }

        private static Task Client_OnBeginChallenge(SChallengeInfo challenge, bool warmUp, bool matchContinuation)
        {
            Console.WriteLine($"Begin challenge: {challenge.Name}");
            return Task.CompletedTask;
        }

        private static Task Client_OnEndChallenge(SPlayerRanking[] rankings, SChallengeInfo challenge, bool wasWarmUp, bool matchContinuesOnNextChallenge, bool restartChallenge) {
            Console.WriteLine($"End challenge: {challenge.Name}");
            return Task.CompletedTask;
        }

        private static Task Client_OnEndMatch(SPlayerRanking[] rankings, int winnerTeam) {
            Console.WriteLine("Match ended, rankings:");
            foreach (var ranking in rankings)
                Console.WriteLine($"- {ranking.Login}: {ranking.Rank}");

            return Task.CompletedTask;
        }

        private static Task Client_OnBeginMatch() {
            Console.WriteLine("New match begun.");
            return Task.CompletedTask;
        }

        private static Task Client_OnEcho(string internalParam, string publicParam) {
            Console.WriteLine($"[Echo] internal: {internalParam}, public: {publicParam}");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerChat(int playerUid, string login, string text, bool isRegisteredCmd) {
            Console.WriteLine($"[Chat] {login}: {text}");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerDisconnect(string login) {
            Console.WriteLine($"Player disconnected: {login}");
            return Task.CompletedTask;
        }

        private static Task Client_OnPlayerConnect(string login, bool isSpectator) {
            Console.WriteLine($"Player connected: {login}");
            return Task.CompletedTask;
        }

        private static Task Client_OnAnyCallback(MethodCall call, object[] pars) {
            Console.WriteLine($"[Any callback] {call.Method}:");
            foreach (var par in pars) {
                Console.WriteLine($"- {par}");
            }

            return Task.CompletedTask;
        }
    }
}
