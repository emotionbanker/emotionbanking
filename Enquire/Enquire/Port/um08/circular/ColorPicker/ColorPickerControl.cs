using System;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;
using System.Drawing.Drawing2D;
using Compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange;

namespace Compucare.Enquire.Common.Controls.Utils.ColorPicker
{
    public partial class ColorPickerControl : UserControl
    {
        public event CommonEventHandler Changed;
        

        public ColorPickerControl() :
            this("?", Color.Black, 1, DashStyle.Dot, "?")
        {
        }

        public ColorPickerControl(String text, Color c, Int32 width, DashStyle dash, String key)
        {
            InitializeComponent();

            TextChanged += ColorPickerControlTextChanged;
            _colorButton.Click += ColorButtonClick;
            _textName.TextChanged += TextNameTextChanged;
            _textWidth.TextChanged += TextNameTextChanged;
            _comboBoxDashStyles.TextChanged += TextNameTextChanged;
            _lb_ChangeProperties.Text = key;
            

            Text = text;
            SetColor(c);
            
             _comboBoxDashStyles.Text = dash.ToString();
            _textWidth.Text = width.ToString();
        }

        void TextNameTextChanged(object sender, EventArgs e)
        {
            ChangeProperties();
            EventHelper.Fire(Changed);
            
        }
        
        void ColorButtonClick(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetColor(_colorDialog.Color);
                ChangeProperties();
            }
        }

        void ChangeProperties()
        {
            try
            {
                HistoricChangeDiagramProperties hcdp2 = (HistoricChangeDiagramProperties)HistoricChangeController.questionstable2[_lb_ChangeProperties.Text];
                hcdp2.setDashText(_textName.Text);
                hcdp2.setDashColour(_colorButton.BackColor);
                hcdp2.setDashWidth(Convert.ToInt32(_textWidth.Text));
                hcdp2.setDashStyle(GetDashStyle());
            }
            catch
            {

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
            _textName.Text = Text;
        }

        public String GetText()
        {
            return _textName.Text;
        }

        public DashStyle GetDashStyle()
        {
            if (_comboBoxDashStyles.Text.Equals("Solid"))
                return DashStyle.Solid;
            else if (_comboBoxDashStyles.Text.Equals("Dash"))
                return DashStyle.Dash;
            else if (_comboBoxDashStyles.Text.Equals("DashDot"))
                return DashStyle.DashDot;
            else if (_comboBoxDashStyles.Text.Equals("DashDotDot"))
                return DashStyle.DashDotDot;
            else if (_comboBoxDashStyles.Text.Equals("Dot"))
                return DashStyle.Dot;
            else
                return DashStyle.Solid;  
        }

        public Int32 GetWidth()
        {
            return Int32.Parse(_textWidth.Text);
        }

        private void ColorPickerControl_Load(object sender, EventArgs e)
        {

        }

    }
}
