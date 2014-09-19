using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Controls.Utils
{
    public partial class DropDownTextbox : UserControl
    {
        public String InitString { get; set; }

        public DropDownTextbox()
        {
            InitializeComponent();
        }
    }
}
