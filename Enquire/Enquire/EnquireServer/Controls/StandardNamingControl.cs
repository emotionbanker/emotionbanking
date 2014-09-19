using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.EnquireServer.Controls
{
    public partial class StandardNamingControl : UserControl
    {
        public String DisplayName
        {
            get { return _textDisplayName.Text; }
            set { _textDisplayName.Text = value; }
        }

        public String Description
        {
            get { return _textDescription.Text; }
            set { _textDescription.Text = value; }
        }

        public StandardNamingControl()
        {
            InitializeComponent();
        }
    }
}
