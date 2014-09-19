using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Vis : UserControl
    {
        private Evaluation eval;

        public SettingsControl_Vis(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            UpdateControls();
        }

        private void UpdateControls()
        {
            PersonBox.Items.Clear();

            foreach (Person p in eval.Persons)
            {
                PersonBox.Items.Add(p);
            }

            if (eval.PersonCombos != null)
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    PersonBox.Items.Add(combo);
                }
        }

        
        private void PersonBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				PersonSetting person = (PersonSetting)PersonBox.SelectedItem;
				
				PersonSettingsControl pss = new PersonSettingsControl(person);

				PersonSettingsPanel.Controls.Clear();

				PersonSettingsPanel.Controls.Add(pss);
			}
			catch
			{
			}
		}
    }
}
