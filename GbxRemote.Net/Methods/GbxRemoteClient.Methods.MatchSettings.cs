using GbxRemoteNet.XmlRpc;
using System.Threading.Tasks;

namespace GbxRemoteNet {
    /// <summary>
    /// Method Category: Match Settings
    /// </summary>
    public partial class GbxRemoteClient {
        /// <summary>
        /// Set a list of challenges defined in the playlist with the specified filename as the current selection of the server, and load the gameinfos from the same file. Only available to Admin.
        /// </summary>
        public async Task<int> LoadMatchSettingsAsync(string filename) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("LoadMatchSettings", filename)
            );

        /// <summary>
        /// Add a list of challenges defined in the playlist with the specified filename at the end of the current selection. Only available to Admin.
        /// </summary>
        public async Task<int> AppendPlaylistFromMatchSettingsAsync(string filename) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("AppendPlaylistFromMatchSettings", filename)
            );

        /// <summary>
        /// Save the current selection of challenge in the playlist with the specified filename, as well as the current gameinfos. Only available to Admin.
        /// </summary>
        public async Task<int> SaveMatchSettingsAsync(string filename) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("SaveMatchSettings", filename)
            );

        /// <summary>
        /// Insert a list of challenges defined in the playlist with the specified filename after the current challenge. Only available to Admin.
        /// </summary>
        public async Task<int> InsertPlaylistFromMatchSettingsAsync(string filename) =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("InsertPlaylistFromMatchSettings", filename)
            );
    }
}
