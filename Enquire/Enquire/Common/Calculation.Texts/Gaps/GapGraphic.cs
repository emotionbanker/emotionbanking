using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Calculation.Attributes;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark;

namespace Compucare.Enquire.Common.Calculation.Texts.Gaps
{
    public class GapGraphic : Gap
    {
        public enum GraphicsType
        {
            
        }

        [DataItemParameter]
        public GraphicsType Type { get; set; }

        [DataItemParameter]
        public Double RangeDelimiterLow { get; set; }

        [DataItemParameter]
        public Double RangeDelimiterHigh { get; set; }

        [DataItemParameter]
        public Int32 ImageSize { get; set; }

        [DataItemParameter]
        public Color ColorLow { get; set; }

        [DataItemParameter]
        public Color ColorMiddle { get; set; }

        [DataItemParameter]
        public Color ColorHigh { get; set; }

        [DataItemParameter]
        public Font ExclamationFont { get; set; }

        public GapGraphic()
        {
            ResultType = typeof (Image);
        }

        public override void Compute()
        {
            double value = Math.Abs(ValueA - ValueB);
            Bitmap retVal = new Bitmap(ImageSize, ImageSize);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(retVal);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color useColor = value < RangeDelimiterLow
                                 ? ColorLow
                                 : value > RangeDelimiterHigh
                                       ? ColorHigh
                                       : ColorMiddle;


            new ExclamationMark().Draw(g, useColor, ImageSize * 0.9f, ImageSize * 0.9f);

            Result = retVal;
        }
    }
}
