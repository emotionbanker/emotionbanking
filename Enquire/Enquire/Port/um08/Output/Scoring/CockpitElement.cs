using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring
{
    public class CockpitElement
    {
        public string top, b1, b2, b3;
        public int pts, avg;

        public CockpitElement(string t, string bb1, string bb2, string bb3, int pts, int avg)
        {
            top = t;
            b1 = bb1;
            b2 = bb2;
            b3 = bb3;
            this.pts = pts;
            this.avg = avg;
        }
    }
}
