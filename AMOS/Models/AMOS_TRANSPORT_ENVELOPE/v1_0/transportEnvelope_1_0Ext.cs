using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AMOS.Models.AMOS_TRANSPORT_ENVELOPE.v1_0
{
    public static class transportEnvelope_1_0Ext
    {
        public static T getPayload<T>(this transportEnvelope_1_0 envelope)
        {
            var doc = new System.Xml.XmlDocument();
            foreach (var node in envelope.payload.Any)
                doc.AppendChild(doc.ImportNode(node, true));

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader stringreader = new StringReader(doc.OuterXml))
                return (T)serializer.Deserialize(stringreader);
        }

        public static Double? GetVersion(this transportEnvelope_1_0 envelope, string payloadTypeLowerCase)
        {
            if (envelope.payload == null)
                return null;

            if (envelope.payload.type == null)
                return null;

            if (envelope.payload.type.ToLower().Equals(payloadTypeLowerCase.ToLower()))
                return Convert.ToDouble(envelope.payload.version);

            return null;
        }
    }
}
