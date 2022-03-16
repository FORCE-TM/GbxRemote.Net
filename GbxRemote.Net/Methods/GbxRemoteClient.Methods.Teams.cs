using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;
using System.Threading.Tasks;

namespace GbxRemoteNet {
    /// <summary>
    /// Method Category: Teams
    /// </summary>
    public partial class GbxRemoteClient {
        /// <summary>
        /// Set a new points limit for team mode (value set depends on UseNewRulesTeam). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetTeamPointsLimitAsync(int maxPoints) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetTeamPointsLimit", maxPoints)
            );

        /// <summary>
        /// Get the current and next points limit for team mode (values returned depend on UseNewRulesTeam). The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetTeamPointsLimitAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetTeamPointsLimit")
            );

        /// <summary>
        /// Set a new number of maximum points per round for team mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetMaxPointsTeamAsync(int maxPoints) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetMaxPointsTeam", maxPoints)
            );

        /// <summary>
        /// Get the current and next number of maximum points per round for team mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetMaxPointsTeamAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetMaxPointsTeam")
            );

        /// <summary>
        /// Set if new rules are used for team mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetUseNewRulesTeamAsync(bool newRules) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetUseNewRulesTeam", newRules)
            );

        /// <summary>
        /// Get if the new rules are used for team mode (Current and next values). The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<string>> GetUseNewRulesTeamAsync() =>
            (CurrentNextValue<string>)XmlRpcTypes.ToNativeValue<CurrentNextValue<string>>(
                await CallOrFaultAsync("GetUseNewRulesTeam")
            );

        /// <summary>
        /// Force the team of the player. Only available in team mode. You have to pass the login and the team number (0 or 1). Only available to Admin.
        /// </summary>
        public async Task<bool> ForcePlayerTeamAsync(string playerLogin, int cameraType) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ForcePlayerTeam", playerLogin, cameraType)
            );

        /// <summary>
        /// Force the team of the player. Only available in team mode. You have to pass the playerid and the team number (0 or 1). Only available to Admin.
        /// </summary>
        public async Task<bool> ForcePlayerTeamIdAsync(int playerId, int cameraType) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ForcePlayerTeamId", playerId, cameraType)
            );
    }
}
