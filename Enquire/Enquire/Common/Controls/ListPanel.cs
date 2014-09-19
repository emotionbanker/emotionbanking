using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Controls
{
    public partial class ListPanel : UserControl
    {
        public String Header
        {
            get { return _headerLabel.Text; }
            set { _headerLabel.Text = value; }
        }

        public Color HeaderColor
        {
            get { return _headerPanel.BackColor; }
            set { _headerPanel.BackColor = value; }
        }

        public Image HeadImage
        {
            get { return _imageBox.Image; }
            set { _imageBox.Image = value; }
        }

        public ListPanel()
        {
            InitializeComponent();
        }

    }
}
