using System;

namespace GbxRemoteNet
{
    public class PlayerStatus : IFlag
    {
        internal PlayerStatus(int value)
        {
            var valueStr = value.ToString("D7");

            const char True = '1';

            HasPlayerSlot = valueStr[0] == True;
            IsServer = valueStr[1] == True;
            IsManagedByAnOtherServer = valueStr[2] == True;
            IsUsingStereoscopy = valueStr[3] == True;
            IsPodiumReady = valueStr[4] == True;
            IsReferee = valueStr[5] == True;
            ForceSpectator = (SpectatorMode)Convert.ToInt32(valueStr[6].ToString());
        }

        public SpectatorMode ForceSpectator { get; }
        public bool IsReferee { get; }
        public bool IsPodiumReady { get; }
        public bool IsUsingStereoscopy { get; }
        public bool IsManagedByAnOtherServer { get; }
        public bool IsServer { get; }
        public bool HasPlayerSlot { get; }

        public override string ToString()
            => (Convert.ToInt32(ForceSpectator)
                + Convert.ToInt32(IsReferee) * 10
                + Convert.ToInt32(IsPodiumReady) * 100
                + Convert.ToInt32(IsUsingStereoscopy) * 1000
                + Convert.ToInt32(IsManagedByAnOtherServer) * 10000
                + Convert.ToInt32(IsServer) * 100000
                + Convert.ToInt32(HasPlayerSlot) * 1000000)
                .ToString("D7");
    }
}
