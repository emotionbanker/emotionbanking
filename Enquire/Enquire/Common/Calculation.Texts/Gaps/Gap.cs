using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Calculation.Attributes;

namespace Compucare.Enquire.Common.Calculation.Texts.Gaps
{
    [DataItem]
    public class Gap : BaseEnquireCalculation
    {
        #region Parameters

        [DataItemParameter]
        public Double ValueA { get; set; }

        [DataItemParameter]
        public Double ValueB { get; set; }

        [DataItemParameter]
        public Int32 Precision { get; set; }

        [DataItemParameter]
        public String Type { get; set; }

        #endregion Parameters

        public Gap()
        {
            ResultType = typeof (Double);
        }

        public override void Compute()
        {
            Result = Math.Round(Math.Abs(ValueA - ValueB), Precision);
        }
    }
}
