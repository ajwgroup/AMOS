using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace AMOS.Models.AMOS_TRANSPORT_ENVELOPE.v0_1
{
    public static class transportEnvelope_0_1Ext
    {
        public static T getPayload<T>(this transportEnvelope_0_1 envelope)
        {
            var doc = new System.Xml.XmlDocument();
            foreach (var node in envelope.payload.Any)
                doc.AppendChild(doc.ImportNode(node, true));

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader stringreader = new StringReader(doc.OuterXml))
                return (T)serializer.Deserialize(stringreader);
        }
    }
}
