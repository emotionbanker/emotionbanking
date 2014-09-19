using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using umfrage2._2007.Controls;
using umfrage2;

namespace UMXAddin3.ControlForms
{
    public partial class SetPlaceholderForm : Form
    {
        public SetPlaceholderForm(Evaluation eval)
        {
            InitializeComponent();

            SettingsControl_Placeholders phc = new SettingsControl_Placeholders(eval);

            phc.Dock = DockStyle.Fill;
            PlaceholderControlPanel.Controls.Add(phc);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}