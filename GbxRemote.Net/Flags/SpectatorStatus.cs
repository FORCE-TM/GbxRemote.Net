using System;

namespace GbxRemoteNet
{
    public class SpectatorStatus : IFlag
    {
        internal SpectatorStatus(int value)
        {
            var valueStr = value.ToString("D7");

            const char True = '1';

            CurrentTargetId = Convert.ToInt32(valueStr[..3]);
            AutoTarget = valueStr[3] == True;
            PureSpectator = valueStr[4] == True;
            TemporarySpectator = valueStr[5] == True;
            Spectator = valueStr[6] == True;
        }

        public bool Spectator { get; }
        public bool TemporarySpectator { get; }
        public bool PureSpectator { get; }
        public bool AutoTarget { get; }
        public int CurrentTargetId { get; }

        public override string ToString()
            => (Convert.ToInt32(Spectator)
                + Convert.ToInt32(TemporarySpectator) * 10
                + Convert.ToInt32(PureSpectator) * 100
                + Convert.ToInt32(AutoTarget) * 1000
                + CurrentTargetId * 10000)
                .ToString("D7");
    }
}
