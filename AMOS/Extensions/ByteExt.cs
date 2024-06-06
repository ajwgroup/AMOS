using AMOS.Models.AMOS_TRANSPORT_ENVELOPE.v0_1;
using AMOS.Models.TRANSFER_ORDER.v0_14;
using AMOS.Models.TRANSFER_ORDER.v1_2;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Linq;

namespace AMOS.Extensions
{
    public static class ByteExt
    {
        public static double? GetXmlOrZipTransferReceivingVersion(this byte[] data, string mimeType)
        {
            try
            {
                var convertedFile = data.TryCompressFile(mimeType, "TRANSFER_RECEIVING", "transferReceiving");
                mimeType = convertedFile.Item1;
                data = convertedFile.Item2;
            }
            catch (InvalidOperationException)
            {
                // Wrong file type
                return null;
            }

            double? version = null;
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                    version = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_RECEIVING", StringComparison.OrdinalIgnoreCase)).Value?.GetVersion("transferReceiving");
                }

                File.Delete(path);
            }

            return version;
        }


        public static double? GetXmlOrZipTransferShipmentVersion(this byte[] data, string mimeType)
        {
            try
            {
                var convertedFile = data.TryCompressFile(mimeType, "TRANSFER_SHIPMENT", "transferShipment");
                mimeType = convertedFile.Item1;
                data = convertedFile.Item2;
            }
            catch (InvalidOperationException)
            {
                // Wrong file type
                return null;
            }

            double? version = null;
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                    version = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_SHIPMENT", StringComparison.OrdinalIgnoreCase)).Value?.GetVersion("transferShipment");
                }

                File.Delete(path);
            }

            return version;
        }

        public static Tuple<string, byte[]> TryCompressFile(this byte[] data, string mimeType, string targetFileNameWithoutExtension, string payloadType)
        {
            if (mimeType.StartsWith("application/xml") || mimeType.StartsWith("text/xml"))
            {
                data = data.AssembleAMOSZipForXMLData(targetFileNameWithoutExtension, payloadType);
                mimeType = "application/zip";
            }

            return new Tuple<string, byte[]>(mimeType, data);
        }


        public static double? GetXmlOrZipTransferWorkorderVersion(this byte[] data, string mimeType)
        {
            try
            {
                var convertedFile = data.TryCompressFile(mimeType, "TRANSFER_WORKORDER", "transferWorkorder");
                mimeType = convertedFile.Item1;
                data = convertedFile.Item2;
            }
            catch (InvalidOperationException)
            {
                // Wrong file type
                return null;
            }

            double? version = null;
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                    version = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_WORKORDER", StringComparison.OrdinalIgnoreCase)).Value?.GetVersion("transferWorkorder");
                }

                File.Delete(path);
            }

            return version;
        }

        public static double? GetXmlOrZipTransferComponentVersion(this byte[] data, string mimeType)
        {
            try
            {
                var convertedFile = data.TryCompressFile(mimeType, "EXPORT_COMPONENT_HISTORY", "exportComponentHistory");
                mimeType = convertedFile.Item1;
                data = convertedFile.Item2;
            }
            catch (InvalidOperationException)
            {
                // Wrong file type
                return null;
            }

            double? version = null;
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                    version = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("EXPORT_COMPONENT_HISTORY", StringComparison.OrdinalIgnoreCase)).Value?.GetVersion("exportComponentHistory");
                }

                File.Delete(path);
            }

            return version;
        }

        public static double? GetXmlOrZipTransferOrderVersion(this byte[] data, string mimeType)
        {
            try
            {
                var convertedFile = data.TryCompressFile(mimeType, "TRANSFER_ORDER", "transferOrder");
                mimeType = convertedFile.Item1;
                data = convertedFile.Item2;
            }
            catch (InvalidOperationException)
            {
                // Wrong file type
                return null;
            }

            double? version = null;
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                    version = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_ORDER", StringComparison.OrdinalIgnoreCase)).Value?.GetVersion("transferOrder");
                }

                File.Delete(path);
            }

            return version;
        }

        public static double? GetXmlOrZipTransferPartVersion(this byte[] data, string mimeType)
        {
            try
            {
                var convertedFile = data.TryCompressFile(mimeType, "TRANSFER_PART", "transferPart");
                mimeType = convertedFile.Item1;
                data = convertedFile.Item2;
            }
            catch (InvalidOperationException)
            {
                // Wrong file type
                return null;
            }

            double? version = null;
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                    version = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_PART", StringComparison.OrdinalIgnoreCase) && !e.Key.StartsWith("TRANSFER_PART_DEFINITION", StringComparison.OrdinalIgnoreCase)).Value
                        ?.GetVersion("transferPart");
                }

                File.Delete(path);
            }

            return version;
        }

        public static double? GetXmlOrZipTransferPartDefintionVersion(this byte[] data, string mimeType)
        {
            try
            {
                var convertedFile = data.TryCompressFile(mimeType, "TRANSFER_PART_DEFINITION", "transferPartDefinition");
                mimeType = convertedFile.Item1;
                data = convertedFile.Item2;
            }
            catch (InvalidOperationException)
            {
                // Wrong file type
                return null;
            }

            double? version = null;
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                    version = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_PART_DEFINITION", StringComparison.OrdinalIgnoreCase)).Value?.GetVersion("transferPartDefinition");
                }

                File.Delete(path);
            }

            return version;
        }

        public static byte[] AssembleAMOSZipForXMLData(this byte[] data, string fileNameWithoutExtension, string payloadType)
        {
            var guid = Guid.NewGuid().ToString();
            Directory.CreateDirectory(Path.Combine(Path.GetTempPath() + "/" + guid));
            File.WriteAllBytes(Path.Combine(Path.GetTempPath() + "/" + guid + "/" + fileNameWithoutExtension + ".xml"), data);

            // Validate the file is payloadType
            if (File.ReadAllText(Path.Combine(Path.GetTempPath() + "/" + guid + "/" + fileNameWithoutExtension + ".xml")).Contains(@"<payload type=""" + payloadType + @""""))
            {
                var targetGuid = Guid.NewGuid().ToString();
                Directory.CreateDirectory(Path.Combine(Path.GetTempPath() + "/" + targetGuid));

                ZipFile.CreateFromDirectory(Path.Combine(Path.GetTempPath() + "/" + guid), Path.Combine(Path.GetTempPath() + "/" + targetGuid) + "/" + fileNameWithoutExtension + ".zip");

                data = File.ReadAllBytes(Path.Combine(Path.GetTempPath() + "/" + targetGuid) + "/" + fileNameWithoutExtension + ".zip");
                // Cleanup Zip dir
                Directory.Delete(Path.Combine(Path.GetTempPath() + "/" + targetGuid), true);
            }
            else
            {
                throw new InvalidOperationException("Invalid file type");
            }

            // Cleanup
            Directory.Delete(Path.Combine(Path.GetTempPath() + "/" + guid), true);

            return data;
        }

        public static bool ZIPContainsOrderType(this byte[] data, double version, string orderType)
        {
            using (var stream = new MemoryStream(data))
            {
                if (!Directory.Exists(Path.GetTempPath()))
                {
                    Directory.CreateDirectory(Path.GetTempPath());
                }

                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Path.GetTempPath(), fileName);
                File.WriteAllBytes(
                    path,
                    data
                );

                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    var transportEnvelopes = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);

                    if (transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_ORDER", StringComparison.OrdinalIgnoreCase)).Value?.GetVersion("transferOrder") != version)
                    {
                        return false;
                    }

                    switch (version)
                    {
                        case 0.14:
                            var result014 = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_ORDER", StringComparison.OrdinalIgnoreCase));
                            if (result014.Value == null)
                            {
                                return false;
                            }

                            return result014.Value.GetPayload<transferOrder_0_14>().order.Any(e => e.orderHeader.orderType.Equals(orderType));
                        case 1.2:
                            var result12 = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_ORDER", StringComparison.OrdinalIgnoreCase));
                            if (result12.Value == null)
                            {
                                return false;
                            }

                            return result12.Value.GetPayload<transferOrder_1_2>().order.Any(e => e.orderHeader.orderType.Equals(orderType));
                        case 1.4:
                            var result14 = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_ORDER", StringComparison.OrdinalIgnoreCase));
                            if (result14.Value == null)
                            {
                                return false;
                            }

                            return result14.Value.GetPayload<AMOS.Models.TRANSFER_ORDER.v1_5.transferOrder_1_5>().order.Any(e => e.orderHeader.orderType.Equals(orderType));
                        case 1.5:
                            var result15 = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_ORDER", StringComparison.OrdinalIgnoreCase));
                            if (result15.Value == null)
                            {
                                return false;
                            }

                            return result15.Value.GetPayload<AMOS.Models.TRANSFER_ORDER.v1_5.transferOrder_1_5>().order.Any(e => e.orderHeader.orderType.Equals(orderType));
                        case 2.0:
                            var result20 = transportEnvelopes.FirstOrDefault(e => e.Key.StartsWith("TRANSFER_ORDER", StringComparison.OrdinalIgnoreCase));
                            if (result20.Value == null)
                            {
                                return false;
                            }

                            return result20.Value.GetPayload<AMOS.Models.TRANSFER_ORDER.v2_0.transferOrder_2_0>().order.Any(e => e.orderHeader.orderType.Equals(orderType));
                        default:
                            return false;
                    }
                }
            }
        }
    }
}
