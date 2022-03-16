using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GbxRemoteNet {
    /// <summary>
    /// Method Category: Challenges
    /// </summary>
    public partial class GbxRemoteClient {
        /// <summary>
        /// Returns the current challenge index in the selection, or -1 if the challenge is no longer in the selection.
        /// </summary>
        public async Task<int> GetCurrentChallengeIndexAsync() =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("GetCurrentChallengeIndex")
            );

        /// <summary>
        /// Returns the challenge index in the selection that will be played next (unless the current one is restarted...)
        /// </summary>
        public async Task<int> GetNextChallengeIndexAsync() =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("GetNextChallengeIndex")
            );

        /// <summary>
        /// Sets the challenge index in the selection that will be played next (unless the current one is restarted...)
        /// </summary>
        public async Task<bool> SetNextChallengeIndexAsync(int challengeIndex) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetNextChallengeIndex")
            );

        /// <summary>
        /// Returns a struct containing the infos for the current challenge. The struct contains the following fields : Name, UId, FileName, Author, Environnement, Mood, BronzeTime, SilverTime, GoldTime, AuthorTime, CopperPrice, LapRace, NbLaps and NbCheckpoints.
        /// </summary>
        public async Task<MapInfo> GetCurrentChallengeInfoAsync() =>
            (MapInfo)XmlRpcTypes.ToNativeValue<MapInfo>(
                await CallOrFaultAsync("GetCurrentChallengeInfo")
            );

        /// <summary>
        /// Returns a struct containing the infos for the next challenge. The struct contains the following fields : Name, UId, FileName, Author, Environnement, Mood, BronzeTime, SilverTime, GoldTime, AuthorTime, CopperPrice and LapRace. (NbLaps and NbCheckpoints are also present but always set to -1)
        /// </summary>
        public async Task<MapInfo> GetNextChallengeInfoAsync() =>
            (MapInfo)XmlRpcTypes.ToNativeValue<MapInfo>(
                await CallOrFaultAsync("GetNextChallengeInfo")
            );

        /// <summary>
        /// Returns a struct containing the infos for the challenge with the specified filename. The struct contains the following fields : Name, UId, FileName, Author, Environnement, Mood, BronzeTime, SilverTime, GoldTime, AuthorTime, CopperPrice and LapRace. (NbLaps and NbCheckpoints are also present but always set to -1)
        /// </summary>
        public async Task<MapInfo> GetChallengeInfoAsync(string filename) =>
            (MapInfo)XmlRpcTypes.ToNativeValue<MapInfo>(
                await CallOrFaultAsync("GetChallengeInfo", filename)
            );

        /// <summary>
        /// Returns a boolean if the challenge with the specified filename matches the current server settings.
        /// </summary>
        public async Task<bool> CheckChallengeForCurrentServerParamsAsync(string filename) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("CheckChallengeForCurrentServerParams", filename)
            );

        /// <summary>
        /// Returns a list of challenges among the current selection of the server. This method take two parameters. The first parameter specifies the maximum number of infos to be returned, and the second one the starting index in the selection. The list is an array of structures. Each structure contains the following fields : Name, UId, FileName, Environnement, Author, GoldTime and CopperPrice.
        /// </summary>
        public async Task<MapInfo[]> GetChallengeListAsync(int maxInfos, int startIndex) =>
            (MapInfo[])XmlRpcTypes.ToNativeValue<MapInfo>(
                await CallOrFaultAsync("GetChallengeList", maxInfos, startIndex)
            );

        /// <summary>
        /// Add the challenge with the specified filename at the end of the current selection. Only available to Admin.
        /// </summary>
        public async Task<bool> AddChallengeAsync(string filename) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("AddChallenge", filename)
            );

        /// <summary>
        /// Add the list of challenges with the specified filenames at the end of the current selection. The list of challenges to add is an array of strings. Only available to Admin.
        /// </summary>
        public async Task<int> AddChallengeListAsync(IEnumerable<string> filenames) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("AddChallengeList", filenames)
            );

        /// <summary>
        /// Remove the challenge with the specified filename from the current selection. Only available to Admin.
        /// </summary>
        public async Task<bool> RemoveChallengeAsync(string filename) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("RemoveChallenge", filename)
            );

        /// <summary>
        /// Remove the list of challenges with the specified filenames from the current selection. The list of challenges to remove is an array of strings. Only available to Admin.
        /// </summary>
        public async Task<int> RemoveChallengeListAsync(IEnumerable<string> filenames) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("RemoveChallengeList", filenames)
            );

        /// <summary>
        /// Insert the challenge with the specified filename after the current challenge. Only available to Admin.
        /// </summary>
        public async Task<bool> InsertChallengeAsync(string filename) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("InsertChallenge", filename)
            );

        /// <summary>
        /// Insert the list of challenges with the specified filenames after the current challenge. The list of challenges to insert is an array of strings. Only available to Admin.
        /// </summary>
        public async Task<int> InsertChallengeListAsync(IEnumerable<string> filenames) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("InsertChallengeList", filenames)
            );

        /// <summary>
        /// Set as next challenge the one with the specified filename, if it is present in the selection. Only available to Admin.
        /// </summary>
        public async Task<bool> ChooseNextChallengeAsync(string filename) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChooseNextChallenge", filename)
            );

        /// <summary>
        /// Set as next challenges the list of challenges with the specified filenames, if they are present in the selection. The list of challenges to choose is an array of strings. Only available to Admin.
        /// </summary>
        public async Task<int> ChooseNextChallengeListAsync(IEnumerable<string> filenames) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("ChooseNextChallengeList", filenames)
            );
    }
}
