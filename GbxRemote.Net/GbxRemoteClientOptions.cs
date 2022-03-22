using System;

namespace GbxRemoteNet
{
    public class GbxRemoteClientOptions
    {
        /// <summary>
        /// Amount of times to re-try connection if it fails.
        /// </summary>
        public int ConnectionRetries { get; set; } = 0;

        /// <summary>
        /// Milliseconds to wait before re-trying connection.
        /// </summary>
        public TimeSpan ConnectionRetryTimeout { get; set; } = TimeSpan.FromSeconds(1);

        /// <summary>
        /// The delegate that will be in charge of invoking the callback events.
        /// Leave as <see langword="null"/> to use the default (thread-safe) invoker.
        /// </summary>
        public GbxRemoteClient.CallbackInvoker CallbackInvoker { get; set; } = null;
    }
}
