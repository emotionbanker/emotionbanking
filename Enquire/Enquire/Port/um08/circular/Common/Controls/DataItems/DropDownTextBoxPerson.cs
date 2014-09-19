using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Controls.Utils;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class DropDownTextBoxPerson : DropDownTextBoxItem
    {
        public DropDownTextBoxPerson(PersonSetting p) : 
            base(p.ToString(), p)
        {
            ImageIndex = 0;
        }
    }
}
