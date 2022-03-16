namespace GbxRemoteNet.Structs
{
    public class GameInfo
    {
        // Duplicate in NewGameInfo
        public const int GAMEMODE_ROUNDS = 0;
        public const int GAMEMODE_TIMEATTACK = 1;
        public const int GAMEMODE_TEAM = 2;
        public const int GAMEMODE_LAPS = 3;
        public const int GAMEMODE_STUNTS = 4;
        public const int GAMEMODE_CUP = 5;

        public int GameMode { get; set; }
        public int NbChallenge { get; set; }
        public int ChatTime { get; set; }
        public int FinishTimeout { get; set; }
        public int AllWarmUpDuration { get; set; }
        public bool DisableRespawn { get; set; }
        public int ForceShowAllOpponents { get; set; }
        public int RoundsPointsLimit { get; set; }
        public int RoundsForcedLaps { get; set; }
        public bool RoundsUseNewRules { get; set; }
        public int RoundsPointsLimitNewRules { get; set; }
        public int TeamPointsLimit { get; set; }
        public int TeamMaxPoints { get; set; }
        public bool TeamUseNewRules { get; set; }
        public int TeamPointsLimitNewRules { get; set; }
        public int TimeAttackLimit { get; set; }
        public int TimeAttackSynchStartPeriod { get; set; }
        public int LapsNbLaps { get; set; }
        public int LapsTimeLimit { get; set; }
        public int CupPointsLimit { get; set; }
        public int CupRoundsPerChallenge { get; set; }
        public int CupNbWinners { get; set; }
        public int CupWarmUpDuration { get; set; }
    }
}
