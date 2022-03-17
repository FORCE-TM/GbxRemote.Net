using System.Collections.Generic;
using System.Threading.Tasks;
using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;
using GbxRemoteNet.XmlRpc.ExtraTypes;

namespace GbxRemoteNet
{
    /// <summary>
    /// Method Category: Server
    /// </summary>
    public partial class GbxRemoteClient
    {
        /// <summary>
        /// Returns a struct with the Name, Version and Build of the application remotely controled.
        /// </summary>
        public async Task<VersionInfo> GetVersionAsync() =>
            (VersionInfo)XmlRpcTypes.ToNativeValue<VersionInfo>(
                await CallOrFaultAsync("GetVersion")
            );

        /// <summary>
        /// Returns the current status of the server.
        /// </summary>
        public async Task<Status> GetStatusAsync() =>
            (Status)XmlRpcTypes.ToNativeValue<Status>(
                await CallOrFaultAsync("GetStatus")
            );

        /// <summary>
        /// Quit the application. Only available to SuperAdmin.
        /// </summary>
        public async Task<bool> QuitGameAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("QuitGame")
            );

        /// <summary>
        /// Write the data to the specified file. The filename is relative to the Tracks path. Only available to Admin.
        /// </summary>
        public async Task<bool> WriteFileAsync(string fileName, Base64 data) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("WriteFile", fileName, data)
            );

        /// <summary>
        /// Send the data to the specified player. Only available to Admin.
        /// </summary>
        public async Task<bool> TunnelSendDataToIdAsync(int id, Base64 data) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("TunnelSendDataToId", id, data)
            );

        /// <summary>
        /// Send the data to the specified player. Login can be a single login or a list of comma-separated logins. Only available to Admin.
        /// </summary>
        public async Task<bool> TunnelSendDataToLoginAsync(string login, Base64 data) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("TunnelSendDataToLogin", login, data)
            );

        /// <summary>
        /// Just log the parameters and invoke a callback. Can be used to talk to other xmlrpc clients connected, or to make custom votes. If used in a callvote, the first parameter will be used as the vote message on the clients. Only available to Admin.
        /// </summary>
        public async Task<bool> EchoAsync(string par1, string par2) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("Echo", par1, par2)
            );

        /// <summary>
        /// Returns the current number of coppers on the server account.
        /// </summary>
        public async Task<int> GetServerCoppersAsync() =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("GetServerCoppers")
            );

        /// <summary>
        /// Get some system infos, including connection rates (in kbps).
        /// </summary>
        public async Task<SystemInfo> GetSystemInfoAsync() =>
            (SystemInfo)XmlRpcTypes.ToNativeValue<SystemInfo>(
                await CallOrFaultAsync("GetSystemInfo")
            );

        /// <summary>
        /// Set the download and upload rates (in kbps).
        /// </summary>
        public async Task<bool> SetConnectionRatesAsync(int download, int upload) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetConnectionRates", download, upload)
            );

        /// <summary>
        /// Set a new server name in utf8 format. Only available to Admin.
        /// </summary>
        public async Task<bool> SetServerNameAsync(string name) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetServerName", name)
            );

        /// <summary>
        /// Get the server name in utf8 format.
        /// </summary>
        public async Task<string> GetServerNameAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetServerName")
            );

        /// <summary>
        /// Set a new server comment in utf8 format. Only available to Admin.
        /// </summary>
        public async Task<bool> SetServerCommentAsync(string comment) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetServerComment", comment)
            );

        /// <summary>
        /// Get the server comment in utf8 format.
        /// </summary>
        public async Task<string> GetServerCommentAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetServerComment")
            );

        /// <summary>
        /// Set whether the server should be hidden from the public server list (0 = visible, 1 = always hidden, 2 = hidden from nations). Only available to Admin.
        /// </summary>
        public async Task<bool> SetHideServerAsync(ServerVisibility visibility) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetHideServer", visibility)
            );

        /// <summary>
        /// Get whether the server wants to be hidden from the public server list.
        /// </summary>
        public async Task<ServerVisibility> GetHideServerAsync() =>
            (ServerVisibility)XmlRpcTypes.ToNativeValue<ServerVisibility>(
                await CallOrFaultAsync("GetHideServer")
            );

        /// <summary>
        /// Returns true if this is a relay server.
        /// </summary>
        public async Task<bool> IsRelayServerAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("IsRelayServer")
            );

        /// <summary>
        /// Set a new password for the server. Only available to Admin.
        /// </summary>
        public async Task<bool> SetServerPasswordAsync(string password) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetServerPassword", password)
            );

        /// <summary>
        /// Get the server password if called as Admin or Super Admin, else returns if a password is needed or not.
        /// </summary>
        public async Task<string> GetServerPasswordAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetServerPassword")
            );

        /// <summary>
        /// Set a new password for the spectator mode. Only available to Admin.
        /// </summary>
        public async Task<bool> SetServerPasswordForSpectatorAsync(string password) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetServerPasswordForSpectator", password)
            );

        /// <summary>
        /// Get the password for spectator mode if called as Admin or Super Admin, else returns if a password is needed or not.
        /// </summary>
        public async Task<string> GetServerPasswordForSpectatorAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetServerPasswordForSpectator")
            );

        /// <summary>
        /// Set a new maximum number of players. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetMaxPlayersAsync(int maxPlayers) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetMaxPlayers", maxPlayers)
            );

        /// <summary>
        /// Get the current and next maximum number of players allowed on server. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetMaxPlayersAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetMaxPlayers")
            );

        /// <summary>
        /// Set a new maximum number of Spectators. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetMaxSpectatorsAsync(int maxPlayers) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetMaxSpectators", maxPlayers)
            );

        /// <summary>
        /// Get the current and next maximum number of Spectators allowed on server. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetMaxSpectatorsAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetMaxSpectators")
            );

        /// <summary>
        /// Enable or disable peer-to-peer upload from server. Only available to Admin.
        /// </summary>
        public async Task<bool> EnableP2PUploadAsync(bool enable) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("EnableP2PUpload", enable)
            );

        /// <summary>
        /// Returns if the peer-to-peer upload from server is enabled.
        /// </summary>
        public async Task<bool> IsP2PUploadAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("IsP2PUpload")
            );

        /// <summary>
        /// Enable or disable peer-to-peer download for server. Only available to Admin.
        /// </summary>
        public async Task<bool> EnableP2PDownloadAsync(bool enable) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("EnableP2PDownload", enable)
            );

        /// <summary>
        /// Returns if the peer-to-peer download for server is enabled.
        /// </summary>
        public async Task<bool> IsP2PDownloadAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("IsP2PDownload")
            );

        /// <summary>
        /// Allow clients to download challenges from the server. Only available to Admin.
        /// </summary>
        public async Task<bool> AllowChallengeDownloadAsync(bool allow) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("AllowChallengeDownload", allow)
            );

        /// <summary>
        /// Returns if clients can download challenges from the server.
        /// </summary>
        public async Task<bool> IsChallengeDownloadAllowedAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("IsChallengeDownloadAllowed")
            );

        /// <summary>
        /// Returns the path of the game datas directory. Only available to Admin.
        /// </summary>
        public async Task<string> GameDataDirectoryAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GameDataDirectory")
            );

        /// <summary>
        /// Returns the path of the tracks directory. Only available to Admin.
        /// </summary>
        public async Task<string> GetTracksDirectoryAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetTracksDirectory")
            );

        /// <summary>
        /// Returns the path of the skins directory. Only available to Admin.
        /// </summary>
        public async Task<string> GetSkinsDirectoryAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetSkinsDirectory")
            );

        /// <summary>
        /// Set a new ladder mode between ladder disabled (0) and forced (1). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetLadderModeAsync(LadderMode mode) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetLadderMode", mode)
            );

        /// <summary>
        /// Get the current and next ladder mode on server. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<LadderMode>> GetLadderModeAsync() =>
            (CurrentNextValue<LadderMode>)XmlRpcTypes.ToNativeValue<CurrentNextValue<LadderMode>>(
                await CallOrFaultAsync("GetLadderMode")
            );

        /// <summary>
        /// Get the ladder points limit for the players allowed on this server. The struct returned contains two fields LadderServerLimitMin and LadderServerLimitMax.
        /// </summary>
        public async Task<LadderServerLimits> GetLadderServerLimitsAsync() =>
            (LadderServerLimits)XmlRpcTypes.ToNativeValue<LadderServerLimits>(
                await CallOrFaultAsync("GetLadderServerLimits")
            );

        /// <summary>
        /// Set the network vehicle quality to Fast (0) or High (1). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetVehicleNetQualityAsync(VehicleQuality quality) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetVehicleNetQuality", quality)
            );

        /// <summary>
        /// Get the current and next network vehicle quality on server. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<VehicleQuality>> GetVehicleNetQualityAsync() =>
            (CurrentNextValue<VehicleQuality>)XmlRpcTypes.ToNativeValue<CurrentNextValue<VehicleQuality>>(
                await CallOrFaultAsync("GetVehicleNetQuality")
            );

        /// <summary>
        /// Set new server options using the struct passed as parameters. This struct must contain the following fields : Name, Comment, Password, PasswordForSpectator, NextMaxPlayers, NextMaxSpectators, IsP2PUpload, IsP2PDownload, NextLadderMode, NextVehicleNetQuality, NextCallVoteTimeOut, CallVoteRatio, AllowChallengeDownload, AutoSaveReplays, and optionally for forever: RefereePassword, RefereeMode, AutoSaveValidationReplays, HideServer, UseChangingValidationSeed. Only available to Admin. A change of NextMaxPlayers, NextMaxSpectators, NextLadderMode, NextVehicleNetQuality, NextCallVoteTimeOut or UseChangingValidationSeed requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetServerOptionsAsync(ServerOptions options) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetServerOptions", options)
            );

        /// <summary>
        /// Optional parameter for compatibility: struct version (0 = united, 1 = forever). Returns a struct containing the server options: Name, Comment, Password, PasswordForSpectator, CurrentMaxPlayers, NextMaxPlayers, CurrentMaxSpectators, NextMaxSpectators, IsP2PUpload, IsP2PDownload, CurrentLadderMode, NextLadderMode, CurrentVehicleNetQuality, NextVehicleNetQuality, CurrentCallVoteTimeOut, NextCallVoteTimeOut, CallVoteRatio, AllowChallengeDownload and AutoSaveReplays, and additionally for forever: RefereePassword, RefereeMode, AutoSaveValidationReplays, HideServer, CurrentUseChangingValidationSeed, NextUseChangingValidationSeed.
        /// </summary>
        public async Task<ServerOptions> GetServerOptionsAsync(ServerType serverType = ServerType.Forever) =>
            (ServerOptions)XmlRpcTypes.ToNativeValue<ServerOptions>(
                await CallOrFaultAsync("GetServerOptions", serverType)
            );

        /// <summary>
        /// Defines the packmask of the server. Can be 'United', 'Nations', 'Sunrise', 'Original', or any of the environment names. (Only challenges matching the packmask will be allowed on the server, so that player connecting to it know what to expect.) Only available when the server is stopped. Only available to Admin.
        /// </summary>
        public async Task<bool> SetServerPackMaskAsync(string packmask) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetServerPackMask", packmask)
            );

        /// <summary>
        /// Get the packmask of the server.
        /// </summary>
        public async Task<string> GetServerPackMaskAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetServerPackMask")
            );

        /// <summary>
        /// Set the mods to apply on the clients. Parameters: Override, if true even the challenges with a mod will be overridden by the server setting; and Mods, an array of structures [{EnvName, Url}, ...]. Requires a challenge restart to be taken into account. Only available to Admin.
        /// </summary>
        public async Task<bool> SetForcedModsAsync(bool forced, IEnumerable<Mod> mods) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetForcedMods", forced, mods)
            );

        /// <summary>
        /// Get the mods settings.
        /// </summary>
        public async Task<ForcedMods> GetForcedModsAsync() =>
            (ForcedMods)XmlRpcTypes.ToNativeValue<ForcedMods>(
                await CallOrFaultAsync("GetForcedMods")
            );

        /// <summary>
        /// Set the music to play on the clients. Parameters: Override, if true even the challenges with a custom music will be overridden by the server setting, and a UrlOrFileName for the music. Requires a challenge restart to be taken into account. Only available to Admin.
        /// </summary>
        public async Task<bool> SetForcedMusicAsync(bool forced, string urlOrFileName) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetForcedMusic", forced, urlOrFileName)
            );

        /// <summary>
        /// Get the music setting.
        /// </summary>
        public async Task<MusicSetting> GetForcedMusicAsync() =>
            (MusicSetting)XmlRpcTypes.ToNativeValue<MusicSetting>(
                await CallOrFaultAsync("GetForcedMusic")
            );

        /// <summary>
        /// Defines a list of remappings for player skins. It expects a list of structs Orig, Name, Checksum, Url. Orig is the name of the skin to remap, or '*' for any other. Name, Checksum, Url define the skin to use. (They are optional, you may set value '' for any of those. All 3 null means same as Orig). Will only affect players connecting after the value is set. Only available to Admin.
        /// </summary>
        public async Task<bool> SetForcedSkinsAsync(IEnumerable<ForcedSkin> skins) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetForcedSkins", skins)
            );

        /// <summary>
        /// Get the current forced skins.
        /// </summary>
        public async Task<ForcedSkin[]> GetForcedSkinsAsync() =>
            (ForcedSkin[])XmlRpcTypes.ToNativeValue<ForcedSkin>(
                await CallOrFaultAsync("GetForcedSkins")
            );

        /// <summary>
        /// Returns the last error message for an internet connection. Only available to Admin.
        /// </summary>
        public async Task<string> GetLastConnectionErrorMessageAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetLastConnectionErrorMessage")
            );

        /// <summary>
        /// Set a new password for the referee mode. Only available to Admin.
        /// </summary>
        public async Task<bool> SetRefereePasswordAsync(string password) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetRefereePassword", password)
            );

        /// <summary>
        /// Get the password for referee mode if called as Admin or Super Admin, else returns if a password is needed or not.
        /// </summary>
        public async Task<string> GetRefereePasswordAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("GetRefereePassword")
            );

        /// <summary>
        /// Set the referee validation mode. 0 = validate the top3 players, 1 = validate all players. Only available to Admin.
        /// </summary>
        public async Task<bool> SetRefereeModeAsync(RefereeMode mode) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetRefereeMode", mode)
            );

        /// <summary>
        /// Get the referee validation mode.
        /// </summary>
        public async Task<RefereeMode> GetRefereeModeAsync() =>
            (RefereeMode)XmlRpcTypes.ToNativeValue<RefereeMode>(
                await CallOrFaultAsync("GetRefereeMode")
            );

        /// <summary>
        /// Set whether the game should use a variable validation seed or not. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetUseChangingValidationSeedAsync(bool useValidationSeed) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetUseChangingValidationSeed", useValidationSeed)
            );

        /// <summary>
        /// Get the current and next value of UseChangingValidationSeed. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<bool>> GetUseChangingValidationSeedAsync() =>
            (CurrentNextValue<bool>)XmlRpcTypes.ToNativeValue<CurrentNextValue<bool>>(
                await CallOrFaultAsync("GetUseChangingValidationSeed")
            );

        /// <summary>
        /// Stop the server. Only available to SuperAdmin.
        /// </summary>
        public async Task<bool> StopServerAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("StopServer")
            );

        /// <summary>
        /// Returns a struct containing the networks stats of the server. The structure contains the following fields : Uptime, NbrConnection, MeanConnectionTime, MeanNbrPlayer, RecvNetRate, SendNetRate, TotalReceivingSize, TotalSendingSize and an array of structures named PlayerNetInfos. Each structure of the array PlayerNetInfos contains the following fields : Login, IPAddress, LastTransferTime, DeltaBetweenTwoLastNetState, PacketLossRate. Only available to SuperAdmin.
        /// </summary>
        public async Task<NetworkStats> GetNetworkStatsAsync() =>
            (NetworkStats)XmlRpcTypes.ToNativeValue<NetworkStats>(
                await CallOrFaultAsync("GetNetworkStats")
            );

        /// <summary>
        /// Start a server on lan, using the current configuration. Only available to SuperAdmin.
        /// </summary>
        public async Task<bool> StartServerLanAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("StartServerLan")
            );

        /// <summary>
        /// Start a server on internet using the 'Login' and 'Password' specified in the struct passed as parameters. Only available to SuperAdmin.
        /// </summary>
        public async Task<bool> StartServerInternetAsync(ServerCredential credentials) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("StartServerInternet", credentials)
            );
    }
}
