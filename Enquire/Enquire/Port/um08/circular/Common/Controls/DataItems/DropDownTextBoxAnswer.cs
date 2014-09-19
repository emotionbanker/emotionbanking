using System;
using Compucare.Enquire.Common.Controls.Utils;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    class DropDownTextBoxAnswer : DropDownTextBoxItem
    {
        public String Answer { get; set; }

        public DropDownTextBoxAnswer(String answer) : 
            base(answer, answer)
        {
            ImageIndex = 0;
            Answer = answer;
        }

    }
}
