using System.Threading.Tasks;
using GbxRemoteNet.XmlRpc;
using GbxRemoteNet.XmlRpc.ExtraTypes;

namespace GbxRemoteNet
{
    /// <summary>
    /// Method Category: Replays
    /// </summary>
    public partial class GbxRemoteClient
    {
        /// <summary>
        /// Enable the autosaving of all replays (vizualisable replays with all players, but not validable) on the server. Only available to SuperAdmin.
        /// </summary>
        public async Task<bool> AutoSaveReplaysAsync(bool autoSave) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("AutoSaveReplays", autoSave)
            );

        /// <summary>
        /// Enable the autosaving on the server of validation replays, every time a player makes a new time. Only available to SuperAdmin.
        /// </summary>
        public async Task<bool> AutoSaveValidationReplaysAsync(bool autoSave) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("AutoSaveValidationReplays", autoSave)
            );

        /// <summary>
        /// Returns if autosaving of all replays is enabled on the server.
        /// </summary>
        public async Task<bool> IsAutoSaveReplaysEnabledAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("IsAutoSaveReplaysEnabled")
            );

        /// <summary>
        /// Returns if autosaving of validation replays is enabled on the server.
        /// </summary>
        public async Task<bool> IsAutoSaveValidationReplaysEnabledAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("IsAutoSaveValidationReplaysEnabled")
            );

        /// <summary>
        /// Saves the current replay (vizualisable replays with all players, but not validable). Pass a filename, or '' for an automatic filename. Only available to Admin.
        /// </summary>
        public async Task<bool> SaveCurrentReplayAsync(string fileName) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SaveCurrentReplay", fileName)
            );

        /// <summary>
        /// Saves a replay with the ghost of all the players' best race. First parameter is the login of the player (or '' for all players), Second parameter is the filename, or '' for an automatic filename. Only available to Admin.
        /// </summary>
        public async Task<bool> SaveBestGhostsReplayAsync(string login, string fileName) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SaveBestGhostsReplay", login, fileName)
            );

        /// <summary>
        /// Returns a replay containing the data needed to validate the current best time of the player. The parameter is the login of the player.
        /// </summary>
        public async Task<Base64> GetValidationReplayAsync(string login) =>
            (Base64)XmlRpcTypes.ToNativeValue<Base64>(
                await CallOrFaultAsync("GetValidationReplay", login)
            );
    }
}
