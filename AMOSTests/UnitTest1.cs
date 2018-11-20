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
        public void TransferPartFromXml_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transferPart = AmosTransportEnvelope.FromXml(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_PART_D31865-111.xml")));
            Assert.AreEqual("D31865-111", transferPart.Payload.TransferPart.Parts.First().PartNumber);
        }
    }
}
