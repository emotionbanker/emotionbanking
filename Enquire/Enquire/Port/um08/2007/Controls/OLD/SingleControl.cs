using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2007.Controls
{
    public partial class SingleControl : UserControl
    {
        Evaluation eval;

        public SingleControl(Evaluation eval)
        {
            InitializeComponent();

            this.eval = eval;

            LoadControl(new OutputControl_PercentMatrix(eval));
        }

        private void LoadControl(Control c)
        {
            c.Dock = DockStyle.Fill;

            MainPane.Controls.Clear();

            MainPane.Controls.Add(c);
        }

        private void UncheckAll()
        {
            foreach (ToolStripButton c in SettingsToolstrip.Items)
            {
                c.Checked = false;
            }
        }

        private void PmButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_PercentMatrix(eval));
            UncheckAll();
            PmButton.Checked = true;
        }

        private void MButton_Click(object sender, EventArgs e)
        {
            //LoadControl(new OutputControl_Matrix(eval));
            UncheckAll();
            MButton.Checked = true;
        }
    }
}
