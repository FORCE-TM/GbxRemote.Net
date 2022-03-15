using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbxRemoteNet {
    public class GbxRemoteClientOptions {
        /// <summary>
        /// Number of times to re-try connection if it fails.
        /// </summary>
        public int ConnectionRetries { get; set; } = 0;
        /// <summary>
        /// Milliseconds to wait before re-trying connection.
        /// </summary>
        public int ConnectionRetryTimeout { get; set; } = 1000;
    }
}
