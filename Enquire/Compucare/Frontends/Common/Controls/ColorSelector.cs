using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;

namespace Compucare.Frontends.Common.Controls
{
    public partial class ColorSelector : UserControl
    {
        public event CommonEventHandler<Color> ColorChanged;

        public Color Color
        {
            get { return _colorPanel.BackColor; }
            set 
            { 
                _colorPanel.BackColor = value;
                _colorDialog.Color = value;
                EventHelper.Fire(ColorChanged, value);
            }
        }

        public ColorSelector()
        {
            InitializeComponent();

            Color = Color.Black;
        }

        private void _selectButton_Click(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color = _colorDialog.Color;
            }
        }
    }
}
