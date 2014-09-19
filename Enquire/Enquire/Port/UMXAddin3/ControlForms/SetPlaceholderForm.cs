using System;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Controls;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
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