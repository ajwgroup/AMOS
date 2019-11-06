using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AMOS.Models.AMOS_TRANSPORT_ENVELOPE.v0_1
{
    public static class EnvelopeUtils
    {
        public static T FromXml<T>(byte[] byteArray) where T : ITransportEnvelope
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream memStream = new MemoryStream(byteArray);
            return (T)serializer.Deserialize(memStream);
        }

        public static T FromZip<T>(FileStream fileStream) where T : ITransportEnvelope
        {
            using (var archive = new ZipArchive(fileStream))
            {
                foreach(var entry in archive.Entries)
                {
                    if (!entry.Name.ToUpper().StartsWith("TRANSFER_ORDER") && !entry.Name.ToUpper().EndsWith(".XML"))
                        continue;

                    using (StreamReader sr = new StreamReader(entry.Open()))
                    {
                        return FromXml<T>(Encoding.UTF8.GetBytes(sr.ReadToEnd()));
                    }
                }
            }

            throw new Exception("Cannot find valid TRANSFER_ORDER file");
        }
    }
}
