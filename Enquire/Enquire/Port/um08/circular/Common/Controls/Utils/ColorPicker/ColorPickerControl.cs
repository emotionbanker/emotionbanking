using System;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.Common.Controls.Utils.ColorPickerUtil
{
    public partial class ColorPickerControl : UserControl
    {
        public event CommonEventHandler Changed;

        public ColorPickerControl() :
            this ("?", Color.Black)
        {
        }

        public ColorPickerControl(String text, Color c)
        {
            InitializeComponent();

            TextChanged += ColorPickerControlTextChanged;
            _colorButton.Click += ColorButtonClick;

            Text = text;
            SetColor(c);
        }
        
        void ColorButtonClick(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetColor(_colorDialog.Color);
            }
        }

        public void SetColor(Color c)
        {
            _colorDialog.Color = c;
            _colorButton.BackColor = c;
            EventHelper.Fire(Changed);
        }

        public Color GetColor()
        {
            return _colorButton.BackColor;
        }

        void ColorPickerControlTextChanged(object sender, EventArgs e)
        {
            _textLabel.Text = Text;
        }

        private void ColorPickerControl_Load(object sender, EventArgs e)
        {

        }
    }
}
