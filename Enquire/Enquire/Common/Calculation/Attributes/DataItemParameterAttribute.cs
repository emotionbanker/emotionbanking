using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation.Attributes
{
    public class DataItemParameterAttribute : Attribute
    {
        public String Default { get; set; }
        public String DisplayName { get; set; }
        public String Description { get; set; }
    }
}
