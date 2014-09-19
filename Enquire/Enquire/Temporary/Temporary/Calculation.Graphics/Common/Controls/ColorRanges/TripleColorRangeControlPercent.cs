using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges
{
    public class TripleColorRangeControlPercent : TripleColorRangeControl
    {
        public TripleColorRangeControlPercent()
        {
            MaxValue = 100;
            MinValue = 0;

            RangeHigh = 75;
            RangeMid = 25;

            ColorHigh = Color.Green;
            ColorLow = Color.Red;
        }
    }
}
