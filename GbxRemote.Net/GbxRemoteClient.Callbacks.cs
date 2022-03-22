using System.Threading.Tasks;
using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;
using GbxRemoteNet.XmlRpc.ExtraTypes;
using GbxRemoteNet.XmlRpc.Packets;
using GbxRemoteNet.XmlRpc.Types;

namespace GbxRemoteNet
{
    public partial class GbxRemoteClient
    {
        public delegate Task CallbackAction<in T>(MethodCall call, T[] parameters);

        //public delegate Task ServerStartAction();
        //public delegate Task ServerStopAction();
        public delegate Task StatusChangedAction(int statusCode, string statusName);

        public delegate Task EchoAction(string internalParam, string publicParam);

        public delegate Task PlayerConnectAction(string login, bool isSpectator);

        public delegate Task PlayerDisconnectAction(string login);

        public delegate Task PlayerInfoChangedAction(PlayerInfo playerInfo);

        public delegate Task PlayerChatAction(int playerUid, string login, string text, bool isRegisteredCmd);

        public delegate Task PlayerCheckpointAction(int playerUid, string login, int timeOrScore, int curLap, int checkpointIndex);

        public delegate Task PlayerFinishAction(int playerUid, string login, int timeOrScore);

        public delegate Task PlayerIncoherenceAction(int playerUid, string login);

        public delegate Task PlayerManialinkPageAnswerAction(int playerUid, string login, int answer);

        public delegate Task BeginRaceAction(ChallengeInfo challenge);

        public delegate Task EndRaceAction(PlayerRanking[] rankings, ChallengeInfo challenge);

        public delegate Task BeginChallengeAction(ChallengeInfo challenge, bool warmUp, bool matchContinuation);

        public delegate Task EndChallengeAction(PlayerRanking[] rankings, ChallengeInfo challenge, bool wasWarmUp, bool matchContinuesOnNextChallenge, bool restartChallenge);

        public delegate Task BeginRoundAction();

        public delegate Task EndRoundAction();

        public delegate Task ChallengeListModifiedAction(int curChallengeIndex, int nextChallengeIndex, bool isListModified);

        public delegate Task VoteUpdatedAction(string stateName, string login, string cmdName, string cmdParam);

        public delegate Task BillUpdatedAction(int billId, int state, string stateName, int transactionId);

        public delegate Task TunnelDataReceivedAction(int playerUid, string login, Base64 data);

        public delegate Task ManualFlowControlTransitionAction(string transition);

        /// <summary>
        /// Triggered for all possible callbacks.
        /// </summary>
        public event CallbackAction<object> OnAnyCallback;

        //public event ServerStartAction OnServerStart;
        //public event ServerStopAction OnServerStop;

        /// <summary>
        /// When the server status changed.
        /// </summary>
        public event StatusChangedAction OnStatusChanged;

        /// <summary>
        /// When a echo message is sent. Can be used for communication with other XML-RPC clients.
        /// </summary>
        public event EchoAction OnEcho;

        /// <summary>
        /// When a player connects to the server.
        /// </summary>
        public event PlayerConnectAction OnPlayerConnect;

        /// <summary>
        /// When a player disconnects from the server.
        /// </summary>
        public event PlayerDisconnectAction OnPlayerDisconnect;

        /// <summary>
        /// When data about a player changed, it is usually called when a player joins or leaves. Gives you more detailed info about a player.
        /// </summary>
        public event PlayerInfoChangedAction OnPlayerInfoChanged;

        /// <summary>
        /// When a player sends a chat message.
        /// </summary>
        public event PlayerChatAction OnPlayerChat;

        /// <summary>
        /// When a player collects a checkpoint.
        /// </summary>
        public event PlayerCheckpointAction OnPlayerCheckpoint;

        /// <summary>
        /// When a player crosses the finish line or when a player is starting a new run (give up).
        /// </summary>
        public event PlayerFinishAction OnPlayerFinish;

        /// <summary>
        /// When a player's time turns invalid ("red time").
        /// </summary>
        public event PlayerIncoherenceAction OnPlayerIncoherence;

        /// <summary>
        /// When a player clicks a server-side manialink that has action="[number]".
        /// </summary>
        public event PlayerManialinkPageAnswerAction OnPlayerManialinkPageAnswer;

        /// <summary>
        /// When the server switches from Score to Race.
        /// </summary>
        public event BeginRaceAction OnBeginRace;

        /// <summary>
        /// When the server switches from Race to Score.
        /// </summary>
        public event EndRaceAction OnEndRace;

        /// <summary>
        /// When the challenge loads on the server.
        /// </summary>
        public event BeginChallengeAction OnBeginChallenge;

        /// <summary>
        /// When the challenge unloads from the server.
        /// </summary>
        public event EndChallengeAction OnEndChallenge;

        /// <summary>
        /// When the round begins.
        /// </summary>
        public event BeginRoundAction OnBeginRound;

        /// <summary>
        /// When the round ends.
        /// </summary>
        public event EndRoundAction OnEndRound;

        /// <summary>
        /// FIX ME
        /// </summary>
        public event ChallengeListModifiedAction OnChallengeListModified;

        /// <summary>
        /// FIX ME
        /// </summary>
        public event VoteUpdatedAction OnVoteUpdated;

        /// <summary>
        /// When the server receives a transaction from a player, check the bill state.
        /// </summary>
        public event BillUpdatedAction OnBillUpdated;

        /// <summary>
        /// Can be used with <see cref="TunnelSendDataToLoginAsync"/> to communicate with the game server from the relay or the other way around.
        /// </summary>
        public event TunnelDataReceivedAction OnTunnelDataReceived;

        /// <summary>
        /// FIX ME
        /// </summary>
        public event ManualFlowControlTransitionAction OnManualFlowControlTransition;

        /// <summary>
        /// Main callback handler.
        /// </summary>
        private async Task GbxRemoteClient_OnCallback(MethodCall call)
        {
            switch (call.Method)
            {
                //case "TrackMania.ServerStart":
                //    OnServerStart?.Invoke();
                //    break;

                //case "TrackMania.ServerStop":
                //    OnServerStop?.Invoke();
                //    break;

                case "TrackMania.StatusChanged":
                    OnStatusChanged?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                    );
                    break;

                case "TrackMania.Echo":
                    OnEcho?.Invoke(
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                    );
                    break;

                case "TrackMania.PlayerConnect":
                    OnPlayerConnect?.Invoke(
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[1])
                    );
                    break;

                case "TrackMania.PlayerDisconnect":
                    OnPlayerDisconnect?.Invoke(
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[0])
                    );
                    break;

                case "TrackMania.PlayerInfoChanged":
                    OnPlayerInfoChanged?.Invoke(
                        (PlayerInfo)XmlRpcTypes.ToNativeValue<PlayerInfo>(call.Arguments[0])
                    );
                    break;

                case "TrackMania.PlayerChat":
                    OnPlayerChat?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[2]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[3])
                    );
                    break;

                case "TrackMania.PlayerCheckpoint":
                    OnPlayerCheckpoint?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[2]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[3]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[4])
                    );
                    break;

                case "TrackMania.PlayerFinish":
                    OnPlayerFinish?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[2])
                    );
                    break;

                case "TrackMania.PlayerIncoherence":
                    OnPlayerIncoherence?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                    );
                    break;

                case "TrackMania.PlayerManialinkPageAnswer":
                    OnPlayerManialinkPageAnswer?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[2])
                    );
                    break;

                case "TrackMania.BeginRace":
                    OnBeginRace?.Invoke(
                        (ChallengeInfo)XmlRpcTypes.ToNativeValue<ChallengeInfo>(call.Arguments[0])
                    );
                    break;

                case "TrackMania.EndRace":
                    OnEndRace?.Invoke(
                        (PlayerRanking[])XmlRpcTypes.ToNativeValue<PlayerRanking[]>(call.Arguments[0]),
                        (ChallengeInfo)XmlRpcTypes.ToNativeValue<ChallengeInfo>(call.Arguments[1])
                    );
                    break;

                case "TrackMania.BeginChallenge":
                    OnBeginChallenge?.Invoke(
                        (ChallengeInfo)XmlRpcTypes.ToNativeValue<ChallengeInfo>(call.Arguments[0]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[1]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[2])
                    );
                    break;

                case "TrackMania.EndChallenge":
                    OnEndChallenge?.Invoke(
                        (PlayerRanking[])XmlRpcTypes.ToNativeValue<PlayerRanking[]>(call.Arguments[0]),
                        (ChallengeInfo)XmlRpcTypes.ToNativeValue<ChallengeInfo>(call.Arguments[1]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[2]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[3]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[4])
                    );
                    break;

                case "TrackMania.BeginRound":
                    OnBeginRound?.Invoke();
                    break;

                case "TrackMania.EndRound":
                    OnEndRound?.Invoke();
                    break;

                case "TrackMania.ChallengeListModified":
                    OnChallengeListModified?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[1]),
                        (bool)XmlRpcTypes.ToNativeValue<bool>(call.Arguments[2])
                    );
                    break;

                case "TrackMania.VoteUpdated":
                    OnVoteUpdated?.Invoke(
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[2]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[3])
                    );
                    break;

                case "TrackMania.BillUpdated":
                    OnBillUpdated?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[1]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[2]),
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[3])
                    );
                    break;

                case "TrackMania.TunnelDataReceived":
                    OnTunnelDataReceived?.Invoke(
                        (int)XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                        (Base64)XmlRpcTypes.ToNativeValue<Base64>(call.Arguments[2])
                    );
                    break;

                case "TrackMania.ManualFlowControlTransition":
                    OnManualFlowControlTransition?.Invoke(
                        (string)XmlRpcTypes.ToNativeValue<string>(call.Arguments[0])
                    );
                    break;
            }

            // always invoke the OnAnyCallback event
            OnAnyCallback?.Invoke(call, (object[])XmlRpcTypes.ToNativeValue<object>(
                new XmlRpcArray(call.Arguments)
            ));
        }
    }
}
