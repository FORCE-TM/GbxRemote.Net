using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using GbxRemoteNet.XmlRpc.Packets;
using GbxRemoteNet.XmlRpc.Types;

namespace GbxRemoteNet.XmlRpc
{
    public class NadeoXmlRpcClient
    {
        private uint handler = 0x80000000;
        private readonly object handlerLock = new();
        private readonly ConcurrentDictionary<uint, ManualResetEvent> responseHandles = new();
        private readonly ConcurrentDictionary<uint, ResponseMessage> responseMessages = new();

        // connection
        private readonly string connectHost;
        private readonly int connectPort;
        private TcpClient tcpClient;
        private XmlRpcIO xmlRpcIO;

        // recvieve
        private Task taskRecvLoop;
        private CancellationTokenSource recvCancel;

        /// <summary>
        /// Generic action for events.
        /// </summary>
        /// <returns></returns>
        public delegate Task TaskAction();

        /// <summary>
        /// Action for the OnCallback event.
        /// </summary>
        /// <param name="call">Information about the call.</param>
        /// <returns></returns>
        protected delegate Task CallbackAction(MethodCall call);

        /// <summary>
        /// Invoked when the client is connected to the XML-RPC server.
        /// </summary>
        public event TaskAction OnConnected;

        /// <summary>
        /// Called when a callback occured from the XML-RPC server.
        /// </summary>
        protected event CallbackAction OnCallback;

        /// <summary>
        /// Triggered when the client has been disconnected from the server.
        /// </summary>
        public event TaskAction OnDisconnected;

        protected NadeoXmlRpcClient(string host, int port)
        {
            connectHost = host;
            connectPort = port;
        }

        /// <summary>
        /// Handles all responses from the XML-RPC server.
        /// </summary>
        private async void RecvLoop()
        {
            try
            {
                while (!recvCancel.IsCancellationRequested)
                {
                    ResponseMessage response = await ResponseMessage.FromIOAsync(xmlRpcIO);

                    if (response.IsCallback)
                    {
                        // invoke listeners and
                        // run callback handler in a new thread to avoid blocking of new responses
                        _ = Task.Run(() => OnCallback?.Invoke(new MethodCall(response)));
                    }
                    else if (responseHandles.ContainsKey(response.Header.Handle))
                    {
                        // attempt to signal the call method
                        responseMessages[response.Header.Handle] = response;
                        responseHandles[response.Header.Handle].Set();
                    }
                }
            }
            catch
            {
                await DisconnectAsync();
            }
        }

        /// <summary>
        /// Connect to the remote XMLRPC server.
        /// </summary>
        /// <param name="retries">Number of times to re-try connection.</param>
        /// <param name="retryTimeout">Number of milliseconds to wait between each re-try.</param>
        /// <returns></returns>
        protected async Task<bool> ConnectAsync(int retries = 0, TimeSpan? retryTimeout = null)
        {
            var connectAddr = await Dns.GetHostAddressesAsync(connectHost);

            tcpClient = new TcpClient();

            // try to connect
            while (retries >= 0)
            {
                try
                {
                    await tcpClient.ConnectAsync(connectAddr[0], connectPort);

                    if (tcpClient.Connected)
                        break;
                }
                catch
                {
                    // ignored
                }

                retries--;

                if (retries < 0)
                    break;

                await Task.Delay(retryTimeout ?? TimeSpan.FromSeconds(1));
            }

            if (retries < 0)
                return false; // connection failed

            xmlRpcIO = new XmlRpcIO(tcpClient);

            // check header
            var header = await ConnectHeader.FromIOAsync(xmlRpcIO);

            if (!header.IsValid)
            {
                throw new Exception($"Invalid protocol: {header.Protocol}");
            }

            recvCancel = new CancellationTokenSource();
            taskRecvLoop = new Task(RecvLoop, recvCancel.Token);
            taskRecvLoop.Start();

            OnConnected?.Invoke();
            return true;
        }

        /// <summary>
        /// Stop the recieve loop and disconnect.
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            try
            {
                recvCancel.Cancel();
                await taskRecvLoop;
                tcpClient.Close();
            }
            catch
            {
                // ignored
            }

            OnDisconnected?.Invoke();
        }

        /// <summary>
        /// Get the next handler value.
        /// </summary>
        /// <returns>The next handle value.</returns>
        private uint GetNextHandle()
        {
            // lock because we may access this in multiple threads
            lock (handlerLock)
            {
                if (handler + 1 == 0xffffffff)
                    handler = 0x80000000;

                return handler++;
            }
        }

        /// <summary>
        /// Call a remote method.
        /// </summary>
        /// <param name="method">Method name</param>
        /// <param name="args">Arguments to the method if available.</param>
        /// <returns>Response returned by the call.</returns>
        protected async Task<ResponseMessage> CallAsync(string method, params XmlRpcBaseType[] args)
        {
            uint handle = GetNextHandle();

            MethodCall call = new(method, handle, args);

            responseHandles[handle] = new ManualResetEvent(false);

            byte[] data = await call.Serialize();
            await xmlRpcIO.WriteBytesAsync(data);

            responseHandles[handle].WaitOne();
            var message = responseMessages[handle];
            return message;
        }
    }
}
