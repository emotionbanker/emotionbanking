using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Controls.Utils;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class DropDownTextBoxQuestion : DropDownTextBoxItem
    {
        public Int32 QId { get; set; }
        public Question Question { get; set; }

        public DropDownTextBoxQuestion(String id, Object q)
            : base(id, q)
        {
        }

        public DropDownTextBoxQuestion(Question q) : 
            base(q.ToString(), q.ID)
        {
            ImageIndex = 0;
            Question = q;
            QId = q.ID;
        }

    }
}
