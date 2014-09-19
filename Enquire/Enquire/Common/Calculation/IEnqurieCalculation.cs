using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation
{
    public interface IEnqurieCalculation
    {
        Type ResultType { get; }
        object Result { get; }

        void Compute();
    }
}
