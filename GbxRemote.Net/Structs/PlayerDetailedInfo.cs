namespace GbxRemoteNet.Structs
{
    public class PlayerDetailedInfo
    {
        public string Login { get; set; }
        public string NickName { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public string Path { get; set; }
        public string Language { get; set; }
        public string ClientVersion { get; set; }
        public string IPAddress { get; set; }
        public int DownloadRate { get; set; }
        public int UploadRate { get; set; }
        public bool IsSpectator { get; set; }
        public bool IsInOfficialMode { get; set; }
        public bool IsReferee { get; set; }
        public FileDesc Avatar { get; set; }
        public Skin[] Skins { get; set; }
        public LadderStats LadderStats { get; set; }
        public int HoursSinceZoneInscription { get; set; }
        public int OnlineRights { get; set; }
    }
}
