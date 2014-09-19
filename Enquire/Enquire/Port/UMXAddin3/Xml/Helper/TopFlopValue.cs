using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Calculation.Texts.TopFlop;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Helper
{
    public class TopFlopValue : IComparable<TopFlopValue>
    {
        public double Value;
        public String Text;
        public String Id;
        public double HistValue;
        public double diff;

        public ResultSorting sorting;
        public ResultOrdering ordering;

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(TopFlopValue other)
        {
            // -1 precedes
            // 0 equal
            // 1 follows

            if (sorting == ResultSorting.CurrentOnly || sorting == ResultSorting.Current)
            {
                return ordering == ResultOrdering.Highest && (other.Value - Value) > 0 ? -1 : 1;
            }

            if (sorting == ResultSorting.Change)
            {
                return ordering == ResultOrdering.Highest && (other.diff - diff) > 0 ? -1 : 1;
            }

            if (sorting == ResultSorting.Historic)
            {
                return ordering == ResultOrdering.Highest && (other.HistValue - HistValue) > 0 ? -1 : 1;
            }

            return 0;
        }
    }
}
