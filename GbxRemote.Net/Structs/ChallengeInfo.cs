namespace GbxRemoteNet
{
    public class ChallengeInfo
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Author { get; set; }
        public string Environment { get; set; }
        public string Mood { get; set; }
        public int BronzeTime { get; set; }
        public int SilverTime { get; set; }
        public int GoldTime { get; set; }
        public int AuthorTime { get; set; }
        public int CopperPrice { get; set; }
        public bool LapRace { get; set; }
        public int NbLaps { get; set; }
        public int NbCheckpoints { get; set; }
    }
}
