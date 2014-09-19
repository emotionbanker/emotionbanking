using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.DataModule.DataItem
{
    public interface IEnquireDataItem
    {
        //attributes
        String Identifier { get; set; }
        String Description { get; set; }
    }
}
