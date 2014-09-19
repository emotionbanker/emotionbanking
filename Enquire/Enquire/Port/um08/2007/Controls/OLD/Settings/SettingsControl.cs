using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl : UserControl
    {
        Evaluation eval;

        public SettingsControl(Evaluation eval)
        {
            InitializeComponent();

            this.eval = eval;

            LoadControl(new SettingsControl_DB(eval));
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

        private void DbButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl_DB(eval));
            UncheckAll();
            DbButton.Checked = true;
            
        }

        private void PersonsButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl_Persons(eval));
            UncheckAll();
            PersonsButton.Checked = true;
        }

        private void TargetButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl_Targets(eval));
            UncheckAll();
            TargetButton.Checked = true;
        }

        private void QuestionButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl_Questions(eval));
            UncheckAll();
            QuestionButton.Checked = true;
        }

        private void VisButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl_Vis(eval));
            UncheckAll();
            VisButton.Checked = true;
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl_Historic(eval));
            UncheckAll();
            HistoryButton.Checked = true;
        }
    }
}
