using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class UpdateFormulaForm : Form
    {
        public UpdateFormulaForm(string formula)
        {
            InitializeComponent();

            textBox1.Text = string.Format("{{{0}}}", formula);
            textBox1.Select(0, 0);
        }

        public string Formula { get; private set; }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Formula = textBox1.Text.Trim(new[] { '{', '}' });
            DialogResult = DialogResult.OK;
        }
    }
}
