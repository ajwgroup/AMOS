using AMOS;
using AMOS.Models.AMOS_TRANSPORT_ENVELOPE.v0_1;
using AMOS.Models.TRANSFER_ORDER.v0_14;
using AMOS.Models.TRANSFER_PART.v0_14;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AMOSTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TransferOrderFromXml_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("R11111111", transportEnvelope.getPayload<transferOrder_0_14>().order.First().orderNumber);
        }

        [TestMethod]
        public void TransferOrderFromXmlOrderHeader_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("EXW", transportEnvelope.getPayload<transferOrder_0_14>().order.First().orderHeader.deliveryCondition.code);
        }

        [TestMethod]
        public void TransferOrderFromXmlPart_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("D31865-111", transportEnvelope.getPayload<transferOrder_0_14>().order.First().orderDetail.First().partNumber.Value);
        }

        [TestMethod]
        public void TransferOrderFromXmlAircraftReg_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("Z-ZZZZ", transportEnvelope.getPayload<transferOrder_0_14>().order.First().orderDetail.First().aircraftRegistration);
        }

        [TestMethod]
        public void TransferOrderFromXmlTargetDate_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("2018-06-11", transportEnvelope.getPayload<transferOrder_0_14>().order.First().orderDetail.First().targetDate);
        }

        [TestMethod]
        public void TransferOrderFromXmlTargetDateConvetToDateTime_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual(DateTime.Parse("11/06/2018 00:00:00", new CultureInfo("en-GB")), DateTime.ParseExact(transportEnvelope.getPayload<transferOrder_0_14>().order.First().orderDetail.First().targetDate, "yyyy-MM-dd", null));
        }

        [TestMethod]
        public void TransferOrderFromXmlAddressing_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("AJWMAIN", transportEnvelope.getPayload<transferOrder_0_14>().order.First().orderHeader.addressing.shipmentAddress.code);
        }

        [TestMethod]
        public void TransferPartFromXml_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_PART_D31865-111.xml")));
            Assert.AreEqual("D31865-111", transportEnvelope.getPayload<transferPart_0_14>().part.First().partNumber);
        }
    }
}
