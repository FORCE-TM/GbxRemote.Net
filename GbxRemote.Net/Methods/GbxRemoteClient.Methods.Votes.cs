using System.Collections.Generic;
using System.Threading.Tasks;
using GbxRemoteNet.XmlRpc;

namespace GbxRemoteNet
{
    /// <summary>
    /// Method Category: Votes
    /// </summary>
    public partial class GbxRemoteClient
    {
        /// <summary>
        /// Call a vote for a cmd. The command is a XML string corresponding to an XmlRpc request. Only available to Admin.
        /// </summary>
        public async Task<bool> CallVoteAsync(string cmd) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("CallVote", cmd)
            );

        /// <summary>
        /// Extended call vote. Same as CallVote, but you can additionally supply specific parameters for this vote: a ratio, a time out and who is voting. Special timeout values: a timeout of '0' means default, '1' means indefinite; a ratio of '-1' means default; Voters values: '0' means only active players, '1' means any player, '2' is for everybody, pure spectators included. Only available to Admin.
        /// </summary>
        public async Task<bool> CallVoteExAsync(string cmd, double ratio, int timeout, int who) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("CallVoteEx", cmd, ratio, timeout, who)
            );

        /// <summary>
        /// Used internally by game.
        /// </summary>
        public async Task<bool> InternalCallVoteAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("InternalCallVote")
            );

        /// <summary>
        /// Cancel the current vote. Only available to Admin.
        /// </summary>
        public async Task<bool> CancelVoteAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("CancelVote")
            );

        /// <summary>
        /// Returns the vote currently in progress. The returned structure is { CallerLogin, CmdName, CmdParam }.
        /// </summary>
        public async Task<CurrentCallVote> GetCurrentCallVoteAsync() =>
            (CurrentCallVote)XmlRpcTypes.ToNativeValue<CurrentCallVote>(
                await CallOrFaultAsync("GetCurrentCallVote")
            );

        /// <summary>
        /// Set a new timeout for waiting for votes. A zero value disables callvote. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetCallVoteTimeOutAsync(int timeout) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetCallVoteTimeOut", timeout)
            );

        /// <summary>
        /// Get the current and next timeout for waiting for votes. The struct returned contains two fields 'CurrentValue' and 'NextValue'.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetCallVoteTimeOutAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetCallVoteTimeOut")
            );

        /// <summary>
        /// Set a new default ratio for passing a vote. Must lie between 0 and 1. Only available to Admin.
        /// </summary>
        public async Task<bool> SetCallVoteRatioAsync(double ratio) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetCallVoteRatio", ratio)
            );

        /// <summary>
        /// Get the current default ratio for passing a vote. This value lies between 0 and 1.
        /// </summary>
        public async Task<double> GetCallVoteRatioAsync() =>
            (double)XmlRpcTypes.ToNativeValue<double>(
                await CallOrFaultAsync("GetCallVoteRatio")
            );

        /// <summary>
        /// Set new ratios for passing specific votes. The parameter is an array of structs {string Command, double Ratio}, ratio is in [0,1] or -1 for vote disabled. Only available to Admin.
        /// </summary>
        public async Task<bool> SetCallVoteRatiosAsync(IEnumerable<CallVoteRatio> ratios) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetCallVoteRatios", ratios)
            );

        /// <summary>
        /// Get the current ratios for passing votes.
        /// </summary>
        public async Task<CallVoteRatio[]> GetCallVoteRatiosAsync() =>
            (CallVoteRatio[])XmlRpcTypes.ToNativeValue<CallVoteRatio>(
                await CallOrFaultAsync("GetCallVoteRatios")
            );
    }
}
