using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Tests.net
{
    [TestFixture]
    public class IOErrorTest
    {
        [Test]
        public void TestSpecialChar()
        {
            String fileName = @"c:\foo/Lauenhainer Straße.csv";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine("foo");
            }
        }
    }
}
