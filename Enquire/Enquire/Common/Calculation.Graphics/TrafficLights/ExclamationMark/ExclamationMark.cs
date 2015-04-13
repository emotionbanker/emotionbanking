using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Compucare.Enquire.Common.Calculation.Attributes;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark
{
    [DataItem]
    public class ExclamationMark : BaseEnquireCalculation
    {
        #region Parameters

        [DataItemParameter(Default = "0", DisplayName = "Value", Description = "The exclamation mark value.")]
        public Double Value { get; set; }

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

        #endregion Parameters

        #region Constants

        public const String ExclamationString = "!";

        #endregion Constants

        public ExclamationMark()
        {
            ResultType = typeof(Image);
        }

        public override void Compute()
        {
            //TODO: compute always as command, event on finished
            Bitmap retVal = new Bitmap(ImageSize, ImageSize);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(retVal);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color useColor = Value < RangeDelimiterLow
                                 ? ColorLow
                                 : Value > RangeDelimiterHigh
                                       ? ColorHigh
                                       : ColorMiddle;

            
            Draw(g, useColor, ImageSize*0.9f, ImageSize*0.9f);

            Result = retVal;
        }

        public virtual void Draw(System.Drawing.Graphics g, Color useColor, float wid, float hei)
        {
            SolidBrush colorBrush = new SolidBrush(useColor);

            float pad = wid/4;
            float rad = wid/4;

            //draw triangle
            g.FillPolygon(colorBrush, new [] {new PointF(pad, 0), new PointF(wid-pad, 0), new PointF(wid/2, hei-hei/3) });

            //draw dot
            g.FillEllipse(colorBrush, wid/2 - rad/2,hei- hei/4, rad, hei/4);
        }
    }
}
