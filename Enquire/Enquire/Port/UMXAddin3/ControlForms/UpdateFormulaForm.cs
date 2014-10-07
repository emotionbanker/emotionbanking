using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class UpdateFormulaForm : Form
    {
        private readonly Dictionary<Point, string> _formulas;
        private readonly Dictionary<int, Point> _positions;

        public UpdateFormulaForm(Dictionary<Point, string> formulas)
        {
            InitializeComponent();

            _formulas = formulas;
            _positions = new Dictionary<int, Point>();
            var sb = new StringBuilder();

            int position = 0;
            foreach (KeyValuePair<Point, string> formula in _formulas)
            {
                _positions.Add(position, formula.Key);
                sb.AppendFormat("{{{0}}}{1}{1}", formula.Value, Environment.NewLine);
                position++;
            }

            textBox1.Text = sb.ToString();
            textBox1.Select(0, 0);
        }

        public Dictionary<Point, string> Formulas
        {
            get { return _formulas; }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var strings = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int pos = 0; pos < strings.Length; pos++)
            {
                var coord = _positions[pos];

                var formula = strings[pos].Trim(new[] { '{', '}' });
                _formulas[coord] = formula;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
