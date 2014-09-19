using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring;
using NUnit.Framework;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Tests.ScoringTest
{
    [TestFixture]
    public class ScoringTest
    {
        [Test]
        public void GenerateCockpit()
        {
            ScoringCockpit07 cockpit = new ScoringCockpit07();
            Bitmap bmp = cockpit.CreateCockpit(GetList());

            bmp.Save(@"C:\Users\mac\Desktop\cockpits\cockpit.png", ImageFormat.Png);
        }

        private ArrayList GetList()
        {
            ArrayList retVal = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                retVal.Add(CreateElement());
            }

            return retVal;
        }

        private CockpitElement CreateElement()
        {
            int pts = 407;
            return new CockpitElement(pts + "", "bb1", "bb2", "bb3", pts, pts);
        }
    }
}
