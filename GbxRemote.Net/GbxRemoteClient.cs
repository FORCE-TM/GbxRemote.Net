using System.Threading.Tasks;
using GbxRemoteNet.XmlRpc;
using GbxRemoteNet.XmlRpc.Packets;
using GbxRemoteNet.XmlRpc.Types;

namespace GbxRemoteNet
{
    /// <summary>
    /// GBXRemote client for connecting to and managing TrackMania servers through XML-RPC.
    /// </summary>
    public partial class GbxRemoteClient : NadeoXmlRpcClient
    {
        private readonly GbxRemoteClientOptions options;

        /// <summary>
        /// Create a new instance of the GBXRemote client.
        /// </summary>
        /// <param name="host">The address to the TrackMania server. Default: 127.0.0.1</param>
        /// <param name="port">The port the XML-RPC server is listening to on your TrackMania server. Default: 5000</param>
        public GbxRemoteClient(string host, int port) : base(host, port)
        {
            options = new();

            OnCallback += GbxRemoteClient_OnCallback;
        }

        /// <summary>
        /// Create a new instance of the GBXRemote client.
        /// </summary>
        /// <param name="host">The address to the TrackMania server. Default: 127.0.0.1</param>
        /// <param name="port">The port the XML-RPC server is listening to on your TrackMania server. Default: 5000</param>
        /// <param name="options">Options for this <see cref="GbxRemoteClient"/>.</param>
        public GbxRemoteClient(string host, int port, GbxRemoteClientOptions options) : base(host, port)
        {
            this.options = options;

            OnCallback += GbxRemoteClient_OnCallback;
        }

        /// <summary>
        /// Call a remote method and throw an exception if a fault occured.
        /// </summary>
        private async Task<XmlRpcBaseType> CallOrFaultAsync(string method, params object[] args)
        {
            var msg = await CallAsync(method, MethodArgs(args));

            if (msg.IsFault)
            {
                throw new XmlRpcFaultException((XmlRpcFault)msg.ResponseData);
            }

            return msg.ResponseData;
        }

        /// <summary>
        /// Call a remote method on the server and return the recieved message.
        /// </summary>
        protected async Task<ResponseMessage> CallMethodAsync(string method, params object[] args)
        {
            return await CallAsync(method, MethodArgs(args));
        }

        /// <summary>
        /// Convert C# type values to XML-RPC type values and create an argument list.
        /// </summary>
        private static XmlRpcBaseType[] MethodArgs(params object[] args)
        {
            XmlRpcBaseType[] xmlRpcArgs = new XmlRpcBaseType[args.Length];

            for (int i = 0; i < args.Length; i++)
                xmlRpcArgs[i] = XmlRpcTypes.ToXmlRpcValue(args[i]);

            return xmlRpcArgs;
        }

        public async Task<bool> ConnectAsync()
            => await ConnectAsync(options.ConnectionRetries, options.ConnectionRetryTimeout);

        /// <summary>
        /// Connect and authenticate to the server.
        /// </summary>
        protected async Task<bool> ConnectAndAuthenticateAsync(string login, string password)
        {
            if (!await ConnectAsync(options.ConnectionRetries, options.ConnectionRetryTimeout))
                return false;

            if (await AuthenticateAsync(login, password))
                return true;

            // disconnect if login failed
            await DisconnectAsync();

            return false;
        }
    }
}
