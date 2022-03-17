namespace GbxRemoteNet.Structs
{
    public class PlayerInfo
    {
        public string Login { get; set; }
        public string NickName { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int LadderRanking { get; set; }
        public SpectatorStatus SpectatorStatus { get; set; }
        public PlayerStatus Flags { get; set; }
    }
}
