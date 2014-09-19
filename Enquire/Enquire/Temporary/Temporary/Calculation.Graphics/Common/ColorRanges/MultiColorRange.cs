using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation.Graphics.Common.ColorRanges
{
    [Serializable]
    public class MultiColorRange : IColorRange
    {
        private readonly SingleColorRange[] _ranges;

        public SingleColorRange[] Ranges
        {
            get { return _ranges; }
        }

        public MultiColorRange(params SingleColorRange[] ranges)
        {
            _ranges = ranges;
        }

        public bool Contains(double val)
        {
            return _ranges.Any(range => range.Contains(val));
        }

        public bool ContainsInclusive(double val)
        {
            return _ranges.Any(range => range.ContainsInclusive(val));
        }

        public bool ContainsInclusiveHigh(double val)
        {
            return _ranges.Any(range => range.ContainsInclusiveHigh(val));
        }

        public bool ContainsInclusiveLow(double val)
        {
            return _ranges.Any(range => range.ContainsInclusiveLow(val));
        }

        /// <summary>
        /// Get Color for value, inclusive low
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public Color GetColor(double val)
        {
            foreach (SingleColorRange range in _ranges)
            {
                if (range.ContainsInclusiveLow(val)) return range.Color;
            }

            return SingleColorRange.GetDefaultColor();
        }
    }
}
