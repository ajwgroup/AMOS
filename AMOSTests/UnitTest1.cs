using AMOS;
using AMOS.Models.AMOS_TRANSPORT_ENVELOPE.v0_1;
using AMOS.Models.TRANSFER_ORDER.v0_14;
using AMOS.Models.TRANSFER_PART.v0_14;
using AMOS.Models.TRANSFER_SHIPMENT.v1_1;
using AMOS.Models.TRANSFER_PART_DEFINITION.v1_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AMOS.Models.IMPORT_ORDER_CONFIRMATION.v0_1;
using AMOS.Models.TRANSFER_RECEIVING.v1_1;

namespace AMOSTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TransferOrderFromXml_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual("R11111111", transportEnvelope.GetPayload<transferOrder_0_14>().order.First().orderNumber);
        }

        [TestMethod]
        public void TransferOrderFromXmlOrderHeader014_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual("EXW", transportEnvelope.GetPayload<transferOrder_0_14>().order.First().orderHeader.deliveryCondition.code);
        }

        [TestMethod]
        public void TransferOrderFromXmlOrderHeader12_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_1_2.xml")));
            Assert.AreEqual("PX0000001", transportEnvelope.GetPayload<AMOS.Models.TRANSFER_ORDER.v1_2.transferOrder_1_2>().order.First().orderNumber);
        }

        [TestMethod]
        public void TransferOrderFromXmlPart_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual("D31865-111", transportEnvelope.GetPayload<transferOrder_0_14>().order.First().orderDetail.First().partNumber.Value);
        }


        [TestMethod]
        public void TransferOrderFromXmlAircraftReg_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual("Z-ZZZZ", transportEnvelope.GetPayload<transferOrder_0_14>().order.First().orderDetail.First().aircraftRegistration);
        }

        [TestMethod]
        public void TransferOrderFromXmlTargetDate_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual("2018-06-11", transportEnvelope.GetPayload<transferOrder_0_14>().order.First().orderDetail.First().targetDate);
        }

        [TestMethod]
        public void TransferOrderFromXmlTargetDateConvetToDateTime_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual(DateTime.Parse("11/06/2018 00:00:00", new CultureInfo("en-GB")), DateTime.ParseExact(transportEnvelope.GetPayload<transferOrder_0_14>().order.First().orderDetail.First().targetDate, "yyyy-MM-dd", null));
        }

        [TestMethod]
        public void TransferOrderFromXmlAddressing_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual("AJWMAIN", transportEnvelope.GetPayload<transferOrder_0_14>().order.First().orderHeader.addressing.shipmentAddress.code);
        }

        [TestMethod]
        public void TransferPartFromXml_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_PART_D31865-111.xml")));
            Assert.AreEqual("D31865-111", transportEnvelope.GetPayload<transferPart_0_14>().part.First().partNumber);
        }

        [TestMethod]
        public void TransferPartDefintionFromXml_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_PART_DEFINITION_6773E010000.xml")));
            Assert.AreEqual("6773E010000", transportEnvelope.GetPayload<transferPartDefinition_1_1>().part.First().partNumber);
        }

        [TestMethod]
        public void TransferReceiving_PassesFile_ReturnsExpectedValue()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_RECEIVING_1_1.xml")));
            var receiving = transportEnvelope.GetPayload<transferReceiving_1_1>().receiving.First();
            var item = transportEnvelope.GetPayload<transferReceiving_1_1>().receiving.First().items.First();

            Assert.AreEqual("12345", receiving.receivingHeader.awbNumber);
            Assert.AreEqual(new DateTime(2020,10,14).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture), DateTime.ParseExact(receiving.receivingHeader.bookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture));
            Assert.AreEqual("12345", item.partType.ItemRotable.certificateNumber);
            Assert.AreEqual("R16990520", item.origin.ItemOrder.orderNumber.Value);
            Assert.AreEqual("1", item.origin.ItemOrder.orderPosition);
            Assert.AreEqual(null, item.origin.ItemPickSlip?.pickslipNumber);
            Assert.AreEqual(new DateTime(2020, 10, 14).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture), DateTime.ParseExact(receiving.receivingHeader.deliveryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture));
            Assert.AreEqual("A-11-111", item.location.location);
            Assert.AreEqual("DUB", item.location.station);
            Assert.AreEqual("AJW", item.location.store);
            Assert.AreEqual("2758", item.partNumber.Value);
            Assert.AreEqual("999999", item.recDetailNoI);
            Assert.AreEqual("123123", receiving.id.Item);
            Assert.AreEqual("123456", item.partType.ItemRotable.serialNumber);
            Assert.AreEqual(null, item.partType.ItemNonRotable?.quantity);
        }

        [TestMethod]
        public void FromZip_PassZipWithTwoFiles_ReturnsTransferOrder()
        {
            using (FileStream fileStream = File.OpenRead("TRANSFER_ORDER_0_14.zip"))
            {
                var transportEnvelope = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                Assert.AreEqual("2018-06-11", transportEnvelope.FirstOrDefault(e => e.Key.Equals("TRANSFER_ORDER_0_14.xml")).Value.GetPayload<transferOrder_0_14>().order.First().orderDetail.First().targetDate);
            }
        }

        [TestMethod]
        public void FromZip_PassZipWithTwoFiles_ReturnsTransferPart()
        {
            using (FileStream fileStream = File.OpenRead("TRANSFER_ORDER_0_14.zip"))
            {
                var transportEnvelope = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                Assert.AreEqual("D31865-111", transportEnvelope.FirstOrDefault(e => e.Key.Equals("TRANSFER_PART_D31865-111.xml")).Value.GetPayload<transferPart_0_14>().part.First().partNumber);
            }
        }

        [TestMethod]
        public void FromXml_ReturnsTransferShipment()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("transfer_shipment.xml")));
            Assert.AreEqual("RETSHIP_111X1222", transportEnvelope.GetPayload<transferShipment_1_1>().shipment.First().awbNumber);
        }

        /*[TestMethod]
        public void FromXml_ReturnsTransferShipment12()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("transfer_shipment_1_2.xml")));
            Assert.AreEqual("555111222", transportEnvelope.getPayload<AMOS.Models.TRANSFER_SHIPMENT.v1_2.transferShipment_1_2>().shipment.First().shipmentHeader.awbNumber);
        }*/

        [TestMethod]
        public void FromXml_ReturnsImportOrderConfirmation()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("import_order_confirmation.xml")));
            Assert.AreEqual("R1111111", transportEnvelope.GetPayload<importOrderConfirmation_0_1>().orderConfirmation.First().orderNumber);
        }

        [TestMethod]
        public void GetVersion_TransferOrder_ShouldReturn014()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_0_14.xml")));
            Assert.AreEqual(0.14, transportEnvelope.GetVersion("transferOrder"));
        }

        [TestMethod]
        public void GetVersion_TransferOrder_ShouldReturn012()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_1_2.xml")));
            Assert.AreEqual(1.2, transportEnvelope.GetVersion("transferOrder"));
        }

        [TestMethod]
        public void GetVersion_TransferOrder_ShouldReturnNull()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_1_2.xml")));
            Assert.AreEqual(null, transportEnvelope.GetVersion("ainthere"));
        }

        [TestMethod]
        public void GetVersion_TransferPartDefinition_ShouldReturn11()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_PART_DEFINITION_6773E010000.xml")));
            Assert.AreEqual(1.1, transportEnvelope.GetVersion("transferPartDefinition"));
        }

        [TestMethod]
        public void FromXml_ReturnsImportOrderConfirmation2()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("import_order_confirmation.xml")));
            Assert.AreEqual("R1111111", transportEnvelope.GetPayload<importOrderConfirmation_0_1>().orderConfirmation.First().orderNumber);
        }
    }
}
