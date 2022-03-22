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
    }
}
