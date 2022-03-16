using System;
using GbxRemoteNet.XmlRpc.Types;

namespace GbxRemoteNet.XmlRpc
{
    /// <summary>
    /// Exception thrown if a fault occured.
    /// </summary>
    public class XmlRpcFaultException : Exception
    {
        /// <summary>
        /// Creates a new instance of the exception using the provided fault info.
        /// </summary>
        /// <param name="fault">Object containing info about the fault.</param>
        public XmlRpcFaultException(XmlRpcFault fault) : base(fault.FaultString)
        {
        }
    }
}
