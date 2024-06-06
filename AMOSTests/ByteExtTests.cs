using AMOS.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AMOSTests
{
    [TestClass]
    public class ByteExtTests
    {
        [TestMethod]
        public void GetZipTransferOrderVersionWithXML14()
        {
            var file = "TRANSFER_ORDER_1_4.zip";
            var bytes = File.ReadAllBytes(file);
            bytes.GetXmlOrZipTransferOrderVersion("application/zip").Should().Be(1.4);
        }


        [TestMethod]
        public void GetZipTransferOrderVersion2()
        {
            var file = "TRANSFER_ORDER_0_14.zip";
            var bytes = File.ReadAllBytes(file);
            bytes.GetXmlOrZipTransferOrderVersion("application/zip").Should().Be(0.14);
        }

        [TestMethod]
        public void ZIPContainsOrderType()
        {
            var file = "TRANSFER_ORDER_0_14.zip";
            var bytes = File.ReadAllBytes(file);
            bytes.ZIPContainsOrderType(0.14, "R").Should().BeTrue();
        }

        [TestMethod]
        public void ZIPContainsOrderType_PassWrongVersion_ReturnsFalse()
        {
            var file = "TRANSFER_ORDER_0_14.zip";
            var bytes = File.ReadAllBytes(file);
            bytes.ZIPContainsOrderType(1.2, "R").Should().BeFalse();
        }

        [TestMethod]
        public void ZIPContainsOrderType_PassWrongOrderType_ReturnsFalse()
        {
            var file = "TRANSFER_ORDER_0_14.zip";
            var bytes = File.ReadAllBytes(file);
            bytes.ZIPContainsOrderType(0.14, "S").Should().BeFalse();
        }
    }
}
