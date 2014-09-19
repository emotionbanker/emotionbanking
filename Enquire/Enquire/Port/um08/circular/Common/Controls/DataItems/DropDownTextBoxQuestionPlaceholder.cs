using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Controls.Utils;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class DropDownTextBoxQuestionPlaceholder : DropDownTextBoxQuestion
    {
        public DropDownTextBoxQuestionPlaceholder(QuestionPlaceholder q) :
            base(q.ToString(), -100000 - q.PID)
        {
            ImageIndex = 2;

            QId = -100000 - q.PID;
        }
    }
}
