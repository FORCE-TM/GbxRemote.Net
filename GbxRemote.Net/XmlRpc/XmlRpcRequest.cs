﻿using System.IO;
using System.Xml.Linq;

namespace GbxRemoteNet.XmlRpc
{
    /// <summary>
    /// Represents a XML-RPC request.
    /// </summary>
    public abstract class XmlRpcRequest
    {
        /// <summary>
        /// The XML document of the request.
        /// </summary>
        public XDocument MainDocument { get; set; }

        /// <summary>
        /// Create a new XML-RPC request with a specific name for
        /// the root element.
        /// </summary>
        /// <param name="rootElement">Name of the root element in the XML tree.</param>
        public XmlRpcRequest(string rootElement)
        {
            MainDocument = new XDocument(
                new XDeclaration("1.0", null, null),
                new XElement(rootElement)
            );
        }

        /// <summary>
        /// Generate formatted XML from the request data.
        /// </summary>
        /// <returns></returns>
        public string GenerateXML(SaveOptions options = SaveOptions.DisableFormatting)
        {
            var sw = new StringWriter();
            MainDocument.Save(sw, options);
            return sw.ToString();
        }
    }
}
