using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation
{
    public class BaseEnquireCalculation : IEnqurieCalculation
    {
        public Type ResultType { get; set; }
        public object Result { get; set; }

        public virtual void Compute()
        {
        }
    }
}
