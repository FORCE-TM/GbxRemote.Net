using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;
using System.Threading.Tasks;

namespace GbxRemoteNet {
    /// <summary>
    /// Method Category: Game Flow
    /// </summary>
    public partial class GbxRemoteClient {
        /// <summary>
        /// Restarts the challenge, with an optional boolean parameter DontClearCupScores (only available in cup mode). Only available to Admin.
        /// </summary>
        public async Task<bool> RestartChallengeAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("RestartChallenge")
            );

        /// <summary>
        /// Switch to next challenge, with an optional boolean parameter DontClearCupScores (only available in cup mode). Only available to Admin.
        /// </summary>
        public async Task<bool> NextChallengeAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("NextChallenge")
            );

        /// <summary>
        /// In Rounds or Laps mode, force the end of round without waiting for all players to giveup/finish. Only available to Admin.
        /// </summary>
        public async Task<bool> ForceEndRoundAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ForceEndRound")
            );

        /// <summary>
        /// Set new game settings using the struct passed as parameters. This struct must contain the following fields : GameMode, ChatTime, RoundsPointsLimit, RoundsUseNewRules, RoundsForcedLaps, TimeAttackLimit, TimeAttackSynchStartPeriod, TeamPointsLimit, TeamMaxPoints, TeamUseNewRules, LapsNbLaps, LapsTimeLimit, FinishTimeout, and optionally: AllWarmUpDuration, DisableRespawn, ForceShowAllOpponents, RoundsPointsLimitNewRules, TeamPointsLimitNewRules, CupPointsLimit, CupRoundsPerChallenge, CupNbWinners, CupWarmUpDuration. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetGameInfosAsync(GameInfo gameInfo) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetGameInfos", gameInfo)
            );

        /// <summary>
        /// Optional parameter for compatibility: struct version (0 = united, 1 = forever). Returns a struct containing the current game settings, ie: GameMode, ChatTime, NbChallenge, RoundsPointsLimit, RoundsUseNewRules, RoundsForcedLaps, TimeAttackLimit, TimeAttackSynchStartPeriod, TeamPointsLimit, TeamMaxPoints, TeamUseNewRules, LapsNbLaps, LapsTimeLimit, FinishTimeout, and additionally for version 1: AllWarmUpDuration, DisableRespawn, ForceShowAllOpponents, RoundsPointsLimitNewRules, TeamPointsLimitNewRules, CupPointsLimit, CupRoundsPerChallenge, CupNbWinners, CupWarmUpDuration.
        /// </summary>
        public async Task<GameInfo> GetCurrentGameInfoAsync(int serverType=1) =>
            (GameInfo)XmlRpcTypes.ToNativeValue<GameInfo>(
                await CallOrFaultAsync("GetCurrentGameInfo", serverType)
            );

        /// <summary>
        /// Optional parameter for compatibility: struct version (0 = united, 1 = forever). Returns a struct containing the game settings for the next challenge, ie: GameMode, ChatTime, NbChallenge, RoundsPointsLimit, RoundsUseNewRules, RoundsForcedLaps, TimeAttackLimit, TimeAttackSynchStartPeriod, TeamPointsLimit, TeamMaxPoints, TeamUseNewRules, LapsNbLaps, LapsTimeLimit, FinishTimeout, and additionally for version 1: AllWarmUpDuration, DisableRespawn, ForceShowAllOpponents, RoundsPointsLimitNewRules, TeamPointsLimitNewRules, CupPointsLimit, CupRoundsPerChallenge, CupNbWinners, CupWarmUpDuration.
        /// </summary>
        public async Task<GameInfo> GetNextGameInfoAsync(int serverType=1) =>
            (GameInfo)XmlRpcTypes.ToNativeValue<GameInfo>(
                await CallOrFaultAsync("GetNextGameInfo", serverType)
            );

        /// <summary>
        /// Optional parameter for compatibility: struct version (0 = united, 1 = forever). Returns a struct containing two other structures, the first containing the current game settings and the second the game settings for next challenge. The first structure is named CurrentGameInfos and the second NextGameInfos.
        /// </summary>
        public async Task<CurrentNextValue<GameInfo>> GetGameInfosAsync(int serverType=1) =>
            (CurrentNextValue<GameInfo>)XmlRpcTypes.ToNativeValue<CurrentNextValue<GameInfo>>(
                await CallOrFaultAsync("GetGameInfos", serverType)
            );

        /// <summary>
        /// Set a new game mode between Rounds (0), TimeAttack (1), Team (2), Laps (3), Stunts (4) and Cup (5). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetGameModeAsync(int gamemode) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetGameMode", gamemode)
            );

        /// <summary>
        /// Get the current game mode.
        /// </summary>
        public async Task<int> GetGameModeAsync() =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("GetGameMode")
            );

        /// <summary>
        /// Sets whether the server is in warm-up phase or not. Only available to Admin.
        /// </summary>
        public async Task<bool> SetWarmUpAsync(bool useWarmup) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetWarmUp", useWarmup)
            );

        /// <summary>
        /// Returns whether the server is in warm-up phase.
        /// </summary>
        public async Task<bool> GetWarmUpAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("GetWarmUp")
            );

        /// <summary>
        /// Set a new finish timeout (for rounds/laps mode) value in milliseconds. 0 means default. 1 means adaptative to the duration of the challenge. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetFinishTimeoutAsync(int finishTimeout) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetFinishTimeout", finishTimeout)
            );

        /// <summary>
        /// Get the current and next FinishTimeout. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetFinishTimeoutAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetFinishTimeout")
            );

        /// <summary>
        /// Set whether to enable the automatic warm-up phase in all modes. 0 = no, otherwise it's the duration of the phase, expressed in number of rounds (in rounds/team mode), or in number of times the gold medal time (other modes). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetAllWarmUpDurationAsync(int warmupDuration) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetAllWarmUpDuration", warmupDuration)
            );

        /// <summary>
        /// Get whether the automatic warm-up phase is enabled in all modes. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetAllWarmUpDurationAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetAllWarmUpDuration")
            );

        /// <summary>
        /// Set whether to disallow players to respawn. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetDisableRespawnAsync(bool disableRespawn) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetDisableRespawn", disableRespawn)
            );

        /// <summary>
        /// Get whether players are disallowed to respawn. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<bool>> GetDisableRespawnAsync() =>
            (CurrentNextValue<bool>)XmlRpcTypes.ToNativeValue<CurrentNextValue<bool>>(
                await CallOrFaultAsync("GetDisableRespawn")
            );

        /// <summary>
        /// Set whether to override the players preferences and always display all opponents (0=no override, 1=show all, other value=minimum number of opponents). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetForceShowAllOpponentsAsync(int playersPreferenceOverride) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetForceShowAllOpponents", playersPreferenceOverride)
            );

        /// <summary>
        /// Get whether players are forced to show all opponents. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetForceShowAllOpponentsAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetForceShowAllOpponents")
            );

        /// <summary>
        /// Set a new time limit for time attack mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetTimeAttackLimitAsync(int timelimit) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetTimeAttackLimit", timelimit)
            );

        /// <summary>
        /// Get the current and next time limit for time attack mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetTimeAttackLimitAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetTimeAttackLimit")
            );

        /// <summary>
        /// Set a new synchronized start period for time attack mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetTimeAttackSynchStartPeriodAsync(int syncStartPeriod) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetTimeAttackSynchStartPeriod", syncStartPeriod)
            );

        /// <summary>
        /// Get the current and synchronized start period for time attack mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetTimeAttackSynchStartPeriodAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetTimeAttackSynchStartPeriod")
            );

        /// <summary>
        /// Set a new time limit for laps mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetLapsTimeLimitAsync(int timelimit) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetLapsTimeLimit", timelimit)
            );

        /// <summary>
        /// Get the current and next time limit for laps mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetLapsTimeLimitAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetLapsTimeLimit")
            );

        /// <summary>
        /// Set a new number of laps for laps mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetNbLapsAsync(int nbrLaps) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetNbLaps", nbrLaps)
            );

        /// <summary>
        /// Get the current and next number of laps for laps mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetNbLapsAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetNbLaps")
            );

        /// <summary>
        /// Set a new number of laps for rounds mode (0 = default, use the number of laps from the challenges, otherwise forces the number of rounds for multilaps challenges). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetRoundForcedLapsAsync(int nbrLaps) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetRoundForcedLaps", nbrLaps)
            );

        /// <summary>
        /// Get the current and next number of laps for rounds mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetRoundForcedLapsAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetRoundForcedLaps")
            );

        /// <summary>
        /// Set a new points limit for rounds mode (value set depends on UseNewRulesRound). Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetRoundPointsLimitAsync(int limit) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetRoundPointsLimit", limit)
            );

        /// <summary>
        /// Get the current and next points limit for rounds mode (values returned depend on UseNewRulesRound). The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<string>> GetRoundPointsLimitAsync() =>
            (CurrentNextValue<string>)XmlRpcTypes.ToNativeValue<CurrentNextValue<string>>(
                await CallOrFaultAsync("GetRoundPointsLimit")
            );

        /// <summary>
        /// Set the points used for the scores in rounds mode. Points is an array of decreasing integers for the players from the first to last. And you can add an optional boolean to relax the constraint checking on the scores. Only available to Admin.
        /// </summary>
        public async Task<bool> SetRoundCustomPointsAsync(int[] points, bool scoreConstraintCheck = false) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetRoundCustomPoints", points, scoreConstraintCheck)
            );

        /// <summary>
        /// Gets the points used for the scores in rounds mode.
        /// </summary>
        public async Task<int[]> GetRoundCustomPointsAsync() =>
            (int[])XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("GetRoundCustomPoints")
            );

        /// <summary>
        /// Set if new rules are used for rounds mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetUseNewRulesRoundAsync(bool newRules) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetUseNewRulesRound", newRules)
            );

        /// <summary>
        /// Get if the new rules are used for rounds mode (Current and next values). The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<string>> GetUseNewRulesRoundAsync() =>
            (CurrentNextValue<string>)XmlRpcTypes.ToNativeValue<CurrentNextValue<string>>(
                await CallOrFaultAsync("GetUseNewRulesRound")
            );

        /// <summary>
        /// Set the points needed for victory in Cup mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetCupPointsLimitAsync(int points) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetCupPointsLimit", points)
            );

        /// <summary>
        /// Get the points needed for victory in Cup mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetCupPointsLimitAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetCupPointsLimit")
            );

        /// <summary>
        /// Sets the number of rounds before going to next challenge in Cup mode. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetCupRoundsPerChallengeAsync(int nbrRounds) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetCupRoundsPerChallenge", nbrRounds)
            );

        /// <summary>
        /// Get the number of rounds before going to next challenge in Cup mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetCupRoundsPerChallengeAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetCupRoundsPerChallenge")
            );

        /// <summary>
        /// Set whether to enable the automatic warm-up phase in Cup mode. 0 = no, otherwise it's the duration of the phase, expressed in number of rounds. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetCupWarmUpDurationAsync(int duration) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetCupWarmUpDuration", duration)
            );

        /// <summary>
        /// Get whether the automatic warm-up phase is enabled in Cup mode. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetCupWarmUpDurationAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetCupWarmUpDuration")
            );

        /// <summary>
        /// Set the number of winners to determine before the match is considered over. Only available to Admin. Requires a challenge restart to be taken into account.
        /// </summary>
        public async Task<bool> SetCupNbWinnersAsync(int nbWinners) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("SetCupNbWinners", nbWinners)
            );

        /// <summary>
        /// Get the number of winners to determine before the match is considered over. The struct returned contains two fields CurrentValue and NextValue.
        /// </summary>
        public async Task<CurrentNextValue<int>> GetCupNbWinnersAsync() =>
            (CurrentNextValue<int>)XmlRpcTypes.ToNativeValue<CurrentNextValue<int>>(
                await CallOrFaultAsync("GetCupNbWinners")
            );

        /// <summary>
        /// Enable control of the game flow: the game will wait for the caller to validate state transitions. Only available to Admin.
        /// </summary>
        public async Task<bool> ManualFlowControlEnableAsync(bool enabled) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ManualFlowControlEnable", enabled)
            );

        /// <summary>
        /// Allows the game to proceed. Only available to Admin.
        /// </summary>
        public async Task<bool> ManualFlowControlProceedAsync() =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ManualFlowControlProceed")
            );

        /// <summary>
        /// Returns whether the manual control of the game flow is enabled. 0 = no, 1 = yes by the xml-rpc client making the call, 2 = yes, by some other xml-rpc client. Only available to Admin.
        /// </summary>
        public async Task<int> ManualFlowControlIsEnabledAsync() =>
            (int)XmlRpcTypes.ToNativeValue<int>(
                await CallOrFaultAsync("ManualFlowControlIsEnabled")
            );

        /// <summary>
        /// Returns the transition that is currently blocked, or '' if none. (That's exactly the value last received by the callback.) Only available to Admin.
        /// </summary>
        public async Task<string> ManualFlowControlGetCurTransitionAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("ManualFlowControlGetCurTransition")
            );

        /// <summary>
        /// Returns the current match ending condition. Return values are: 'Playing', 'ChangeMap' or 'Finished'.
        /// </summary>
        public async Task<string> CheckEndMatchConditionAsync() =>
            (string)XmlRpcTypes.ToNativeValue<string>(
                await CallOrFaultAsync("CheckEndMatchCondition")
            );
    }
}
