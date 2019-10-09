using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AMOS.Models.AMOS_TRANSPORT_ENVELOPE.v0_1
{
    public static class EnvelopeUtils
    {
        public static T FromXml<T>(byte[] byteArray)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream memStream = new MemoryStream(byteArray);
            return (T)serializer.Deserialize(memStream);
        }
    }
}
