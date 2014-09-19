using System;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public partial class SingleQuestionSelectorCrossingControl : SingleQuestionSelectorControl
    {
        public String CrossHeader
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }
        public SingleQuestionSelectorCrossingControl()
        {
            InitializeComponent();
        }
    }
}
