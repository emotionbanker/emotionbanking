using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class UpdateFormulaForm : Form
    {
        private string _formula;
        private readonly bool _tableMode;
        private readonly Dictionary<Point, string> _formulas;
        private readonly Dictionary<int, Point> _positions;


        public UpdateFormulaForm(Dictionary<Point, string> formulas)
        {
            InitializeComponent();

            _tableMode = true;
            _formulas = formulas;
            _positions = new Dictionary<int, Point>();
            var sb = new StringBuilder();

            int position = 0;
            foreach (KeyValuePair<Point, string> formula in _formulas)
            {
                _positions.Add(position, formula.Key);
                sb.AppendFormat("{{{0}}}\n\n", formula.Value);
                position++;
            }

            txtFormulas.Text = sb.ToString();
            txtFormulas.Select(0, 0);
        }

        public UpdateFormulaForm(string formula)
        {
            InitializeComponent();

            _formula = formula;
            _tableMode = false;

            txtFormulas.Text = string.Format("{{{0}}}\n\n", _formula);
            txtFormulas.Select(0, 0);
        }

        /// <summary>
        /// Returns formulas with respective Cell coordinates. Use when a table is selected.
        /// </summary>
        public Dictionary<Point, string> Formulas
        {
            get { return _formulas; }
        }

        /// <summary>
        /// Returns single formula. Use when a single shape is selected.
        /// </summary>
        public string Formula
        {
            get { return _formula; }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var strings = txtFormulas.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (!_tableMode)
            {
                _formula = strings[0].Trim(new[] { '{', '}' });
            }
            else
            {
                for (int pos = 0; pos < strings.Length && pos < _positions.Count; pos++)
                {
                    var coord = _positions[pos];
                    var formula = strings[pos].Trim(new[] { '{', '}' });
                    _formulas[coord] = formula;
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFind.Text) && !string.IsNullOrEmpty(txtReplace.Text))
            {
                if (!string.IsNullOrEmpty(txtFormulas.SelectedText))
                {
                    int selectionStart = txtFormulas.SelectionStart;
                    int selectionLength = txtFormulas.SelectionLength;

                    txtFormulas.Text = txtFormulas.Text.Remove(selectionStart, selectionLength)
                        .Insert(selectionStart, txtReplace.Text);
                    txtFormulas.Select(selectionStart, selectionLength);
                }
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFind.Text) && !string.IsNullOrEmpty(txtReplace.Text))
            {
                txtFormulas.Text = txtFormulas.Text.Replace(txtFind.Text, txtReplace.Text);
            }
        }

        private void btnSelectPrevious_Click(object sender, EventArgs e)
        {
            int startIndex = 0;
            int endIndex = txtFormulas.SelectionStart;
            txtFormulas.Find(txtFind.Text, startIndex, endIndex, RichTextBoxFinds.Reverse);
        }

        private void btnSelectNext_Click(object sender, EventArgs e)
        {
            int startIndex = txtFormulas.SelectionStart + txtFormulas.SelectionLength;
            int endIndex = txtFormulas.TextLength;
            txtFormulas.Find(txtFind.Text, startIndex, endIndex, RichTextBoxFinds.None);
        }
    }
}
