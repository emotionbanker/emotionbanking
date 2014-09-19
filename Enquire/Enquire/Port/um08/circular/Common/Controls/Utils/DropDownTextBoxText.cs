using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Controls.Utils
{
    public class DropDownTextBoxText : DropDownTextBoxItem
    {
        public DropDownTextBoxText(string displayName, string value) : 
            base(displayName, value)
        {
        }

        public DropDownTextBoxText(string value) :
            base(value, value)
        {
        }
    }
}
