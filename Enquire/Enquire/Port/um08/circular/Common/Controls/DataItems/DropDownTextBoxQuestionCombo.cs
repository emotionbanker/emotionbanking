using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Controls.Utils;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class DropDownTextBoxQuestionCombo : DropDownTextBoxQuestion
    {
        public DropDownTextBoxQuestionCombo(QuestionCombo q) : 
            base(q.ToString(), (q.ID * -1) - 100)
        {
            ImageIndex = 1;

            QId = (q.ID * -1) - 100;
        }
    }
}
