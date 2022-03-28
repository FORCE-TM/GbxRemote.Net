using System.Threading.Tasks;
using GbxRemoteNet.XmlRpc;

namespace GbxRemoteNet
{
    public partial class GbxRemoteClient
    {
        /// <summary>
        /// Allow user authentication by specifying a login and a password, to gain access to the set of functionalities corresponding to this authorization level.
        /// </summary>
        public async Task<bool> AuthenticateAsync(string login, string password) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("Authenticate", login, password)
            );

        /// <summary>
        /// Change the password for the specified login/user. Only available to SuperAdmin.
        /// </summary>
        public async Task<bool> ChangeAuthPasswordAsync(string login, string password) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("ChangeAuthPassword", login, password)
            );

        /// <summary>
        /// Allow the GameServer to call you back.
        /// </summary>
        public async Task<bool> EnableCallbacksAsync(bool enable = true) =>
            (bool)XmlRpcTypes.ToNativeValue<bool>(
                await CallOrFaultAsync("EnableCallbacks", enable)
            );
    }
}
