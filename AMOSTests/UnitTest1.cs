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
using AMOS.Models.EXPORT_COMPONENT_HISTORY.v2_3;
using AMOS.Models.TRANSFER_SHIPMENT.v1_2;
using AMOS.Models.TRANSFER_SHIPMENT.v0_1;
using System.Xml.Serialization;
using System.Xml;

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
        public void TransferOrderFromXmlOrderHeader14_PassesFile_ReturnsExpectedValueForOrder()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_1_4.xml")));
            Assert.AreEqual("PX0000001", transportEnvelope.GetPayload<AMOS.Models.TRANSFER_ORDER.v1_4.transferOrder_1_4>().order.First().orderNumber);
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
        public void TransferExportComponentHistory_PassesFile_ReturnsExpectedValue()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("EXPORT_COMPONENT_HISTORY_2_3.xml")));
            var booking = transportEnvelope.GetPayload<exportComponentHistory>().booking.FirstOrDefault();

            Assert.AreEqual("AAA", booking.aircraft);
            Assert.AreEqual("A33F", booking.aircraftType);
            Assert.AreEqual("25-51", booking.ataChapter);
            Assert.AreEqual(null, booking.averagePrice);
            Assert.AreEqual(null, booking.batchExpiryDate);
            Assert.AreEqual(null, booking.batchNumber);
            Assert.AreEqual("1111111", booking.bookingID);
            Assert.AreEqual(null, booking.certificateNumber);
            Assert.AreEqual("S", booking.condition);
            Assert.AreEqual(null, booking.costCenter);
            Assert.AreEqual(null, booking.creatorOfEntry);
            Assert.AreEqual("7937", booking.cyclesBetweenInstallation);
            Assert.AreEqual("7937", booking.cyclesSinceNew);
            Assert.AreEqual(new DateTime(2020, 01, 17).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture), DateTime.ParseExact(booking.date, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture));
            Assert.AreEqual(null, booking.destinationLocation);
            Assert.AreEqual(null, booking.destinationStation);
            Assert.AreEqual(null, booking.destinationStore);
            Assert.AreEqual(null, booking.entityCode);
            Assert.AreEqual(null, booking.externalInvoiceNumber);
            Assert.AreEqual("Y", booking.failureConfirmed.ToString());
            Assert.AreEqual("True", booking.failureConfirmedSpecified.ToString());
            Assert.AreEqual(null, booking.higherPartNumber);
            Assert.AreEqual(null, booking.higherSerialNumber);
            Assert.AreEqual(null, booking.invoiceDate);
            Assert.AreEqual(null, booking.invoiceNumber);
            Assert.AreEqual("5305983", booking.labelNumber);
            Assert.AreEqual(null, booking.manufacturingDate);
            Assert.AreEqual("R", booking.materialClass);
            Assert.AreEqual(null, booking.materialType);
            Assert.AreEqual(new DateTime(2020, 01, 17).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture), DateTime.ParseExact(booking.orderDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture));
            Assert.AreEqual("R00000000", booking.orderNumber);
            Assert.AreEqual(null, booking.orderPosition);
            Assert.AreEqual(null, booking.originLocation);
            Assert.AreEqual(null, booking.originStation);
            Assert.AreEqual(null, booking.originStore);
            Assert.AreEqual(null, booking.owner);
            Assert.AreEqual("YG101-04", booking.partNumber);
            Assert.AreEqual(null, booking.higherPartNumber);
            Assert.AreEqual(null, booking.higherSerialNumber);
            Assert.AreEqual(null, booking.invoiceDate);
            Assert.AreEqual(null, booking.invoiceNumber);
            Assert.AreEqual("5305983", booking.labelNumber);
            Assert.AreEqual(null, booking.manufacturingDate);
            Assert.AreEqual("R", booking.materialClass);
            Assert.AreEqual(null, booking.materialType);
            Assert.AreEqual("2020-01-17", booking.orderDate);
            Assert.AreEqual("R00000000", booking.orderNumber);
            Assert.AreEqual(null, booking.orderPosition);
            Assert.AreEqual(null, booking.originLocation);
            Assert.AreEqual(null, booking.originStation);
            Assert.AreEqual(null, booking.originStore);
            Assert.AreEqual(null, booking.owner);
            Assert.AreEqual("YG101-04", booking.partNumber);
            Assert.AreEqual(null, booking.position);
            Assert.AreEqual(null, booking.projectNumber);
            Assert.AreEqual(null, booking.purchasePrice);
            Assert.AreEqual(Convert.ToDecimal(1.0), booking.quantity);
            Assert.AreEqual(true, booking.quantitySpecified);
            Assert.AreEqual(null, booking.recDetailNoI);
            Assert.AreEqual(null, booking.receiver);
            Assert.AreEqual("SD", booking.removalReason);
            Assert.AreEqual("Y", booking.repairable.ToString());
            Assert.AreEqual(false, booking.repairableSpecified);
            Assert.AreEqual("123456", booking.serialNumber);
            Assert.AreEqual(null, booking.text);
            Assert.AreEqual("47169", booking.timeBetweenInstallation);
            Assert.AreEqual("47169", booking.timeSinceNew);
            Assert.AreEqual("Y", booking.tool.ToString());
            Assert.AreEqual(false, booking.toolSpecified);
            Assert.AreEqual("7942", booking.totalAircraftCycles);
            Assert.AreEqual("47178", booking.totalAircraftHours);
            Assert.AreEqual(0, booking.transactionID);
            Assert.AreEqual(false, booking.transactionIDSpecified);
            Assert.AreEqual("EA", booking.unitOfMeasurement);
            Assert.AreEqual("YA", booking.voucherMode);
            Assert.AreEqual(null, booking.voucherNumber);
            Assert.AreEqual("1234567", booking.workorderNumber);

            /*
            Assert.AreEqual(new DateTime(2020, 10, 14).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture), DateTime.ParseExact(receiving.receivingHeader.bookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture));
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
            */
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
        public void FromZip_PassZipWithTwoFiles_ReturnsTransferOrder14()
        {
            using (FileStream fileStream = File.OpenRead("TRANSFER_ORDER_1_4.zip"))
            {
                var transportEnvelope = EnvelopeUtils.FromZip<transportEnvelope_0_1>(fileStream);
                Assert.AreEqual("2022-09-02", transportEnvelope.FirstOrDefault(e => e.Key.Equals("TRANSFER_ORDER.xml")).Value.GetPayload<AMOS.Models.TRANSFER_ORDER.v1_4.transferOrder_1_4>().order.First().orderDetail.First().targetDate);
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
            Assert.AreEqual("RETSHIP_111X1222", transportEnvelope.GetPayload<transferShipment_0_1>().shipment.First().awbNumber);
        }

        [TestMethod]
        public void ToXml_OutputsTransferShipmentWithNoDetailLine()
        {
            var transferShipment = new transferShipment_0_1();
            XmlSerializer serializer = new XmlSerializer(typeof(transferShipment_0_1));
            var transferShipmentXml = "shipmentDetail";


            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, transferShipment);
                    transferShipmentXml = sww.ToString(); 
                    
                }
            }

            Assert.AreEqual(transferShipmentXml.Contains("shipmentDetail"), false);
        }


        [TestMethod]
        public void FromXml_ReturnsTransferShipment1_2()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_SHIPMENT_1_2.xml")));
            Assert.AreEqual(AMOS.Models.TRANSFER_SHIPMENT.v1_2.shipmentHeaderTypeShipmentType.EO, transportEnvelope.GetPayload<transferShipment_1_2>().shipment.First().shipmentHeader.shipmentType);
        }

        [TestMethod]
        public void FromXml_ReturnsTransferShipment1_3()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_SHIPMENT_1_3.xml")));
            Assert.AreEqual(AMOS.Models.TRANSFER_SHIPMENT.v1_3.shipmentHeaderTypeShipmentType.EO, transportEnvelope.GetPayload<AMOS.Models.TRANSFER_SHIPMENT.v1_3.transferShipment_1_3>().shipment.First().shipmentHeader.shipmentType);
        }

        [TestMethod]
        public void FromXml_ReturnsTransferShipment1_2_ReturnsVersion0_1()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("transfer_shipment_0_1.xml")));
            Assert.AreEqual("0.1", transportEnvelope.GetPayload<transferShipment_0_1>().version);
        }

        [TestMethod]
        public void FromXml_ReturnsTransferShipment1_2_ReturnsVersion1_2()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_SHIPMENT_1_2.xml")));
            Assert.AreEqual("1.2", transportEnvelope.GetPayload<transferShipment_1_2>().version);
        }

        [TestMethod]
        public void FromXml_ReturnsTransferShipment1_3_ReturnsVersion1_3()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_SHIPMENT_1_3.xml")));
            Assert.AreEqual("1.3", transportEnvelope.GetPayload<AMOS.Models.TRANSFER_SHIPMENT.v1_3.transferShipment_1_3>().version);
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
        public void GetVersion_TransferOrder_ShouldReturn1_4()
        {
            var transportEnvelope = EnvelopeUtils.FromXml<transportEnvelope_0_1>(Encoding.UTF8.GetBytes(File.ReadAllText("TRANSFER_ORDER_1_4.xml")));
            Assert.AreEqual(1.4, transportEnvelope.GetVersion("transferOrder"));
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
