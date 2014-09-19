using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation.Graphics.Common.ColorRanges
{
    public interface IColorRange
    {
        bool Contains(double val);
        bool ContainsInclusive(double val);
        bool ContainsInclusiveHigh(double val);
        bool ContainsInclusiveLow(double val);

        /// <summary>
        /// Get Color for value, inclusive low
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        Color GetColor(double val);
    }
}
