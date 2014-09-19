using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation.Graphics.Common.ColorRanges
{
    [Serializable]
    public class SingleColorRange : IColorRange
    {
        public Double From { get; set; }
        public Double To { get; set; }
        public Color Color { get; set; }

        private Double Low
        {
            get { return Math.Min(From, To); }
        }

        private Double High
        {
            get { return Math.Max(From, To); }
        }

        public SingleColorRange(double from, double to, Color color)
        {
            From = from;
            To = to;
            Color = color;
        }

        public static Color GetDefaultColor()
        {
            return Color.Gray;
        }

        public Color GetColor(double val)
        {
            if (ContainsInclusiveLow(val))
            {
                return Color;
            }

            return GetDefaultColor();
        }

        public bool Contains(double val)
        {
            return Low < val && val < High;
        }

        public bool ContainsInclusive(double val)
        {
            return Low <= val && val <= High;
        }

        public bool ContainsInclusiveLow(double val)
        {
            return Low <= val && val < High;
        }

        public bool ContainsInclusiveHigh(double val)
        {
            return Low < val && val <= High;
        }
    }
}
