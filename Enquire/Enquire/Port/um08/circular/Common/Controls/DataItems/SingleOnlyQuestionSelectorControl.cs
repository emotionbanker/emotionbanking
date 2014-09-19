using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public partial class SingleOnlyQuestionSelectorControl : UserControl
    {
        public String Header
        {
            get { return _headGroup.Text; }
            set { _headGroup.Text = value; }
        }

        public SingleOnlyQuestionSelectorControl()
        {
            InitializeComponent();
        }
    }
}
