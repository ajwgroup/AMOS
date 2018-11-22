using AMOS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var transferOrder = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("R11111111", transferOrder.Payload.TransferOrder.Orders.First().OrderNumber);
        }

        [TestMethod]
        public void TransferOrderFromXmlOrderHeader_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transferOrder = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("EXW", transferOrder.Payload.TransferOrder.Orders.First().OrderHeader.DeliveryCondition.Code);
        }

        [TestMethod]
        public void TransferOrderFromXmlPart_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transferOrder = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("D31865-111", transferOrder.Payload.TransferOrder.Orders.First().OrderDetail.First().PartNumber.Value);
        }

        [TestMethod]
        public void TransferOrderFromXmlAircraftReg_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transferOrder = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("Z-ZZZZ", transferOrder.Payload.TransferOrder.Orders.First().OrderDetail.First().AircraftRegistration);
        }

        [TestMethod]
        public void TransferOrderFromXmlTargetDate_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transferOrder = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("2018-06-11", transferOrder.Payload.TransferOrder.Orders.First().OrderDetail.First().TargetDate);
        }

        
        [TestMethod]
        public void TransferOrderFromXmlAddressing_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transferOrder = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER.xml")));
            Assert.AreEqual("AJWMAIN", transferOrder.Payload.TransferOrder.Orders.First().OrderHeader.Addressing.ShipmentAddress.Code);
        }

        [TestMethod]
        public void TransferPartFromXml_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transferPart = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_PART_D31865-111.xml")));
            Assert.AreEqual("D31865-111", transferPart.Payload.TransferPart.Parts.First().PartNumber);
        }
    }
}
