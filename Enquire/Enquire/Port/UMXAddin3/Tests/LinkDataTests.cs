using System;
using NUnit.Framework;

namespace Compucare.Enquire.Legacy.UMXAddin3.Tests
{
    [TestFixture]
    public class LinkDataTests
    {
        [Test]
        public void TestDataConversion()
        {
            String linkString = "ADDIN umo:mw:147:1:2|1||";

            LinkData ld = new LinkData();

            ld.LoadFromString(linkString);

            Assert.AreEqual(linkString, ld.Settings);

            LinkData ld2 = new LinkData();

            ld2.LoadFromString(ld.ToXmlString());

            Assert.AreEqual(ld2.ToBasicString(), ld.ToBasicString());
        }


    }
}
