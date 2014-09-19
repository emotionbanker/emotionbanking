using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Persons : UserControl
    {
        private ChoosePersonControl cpc;
        private Evaluation eval;

        public SettingsControl_Persons(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            eval.PersonDataChanged += new EvaluationEventHandler(eval_PersonDataChanged);

            cpc = new ChoosePersonControl(eval, false);
            cpc.Dock = DockStyle.Fill;
            ChoosePersonPanel.Controls.Add(cpc);

            UpdateControls();
        }

        private void eval_PersonDataChanged(object source)
        {
            UpdateControls();
            cpc = new ChoosePersonControl(eval, false);
            cpc.Dock = DockStyle.Fill;
            ChoosePersonPanel.Controls.Clear();
            ChoosePersonPanel.Controls.Add(cpc);
        }

        private void UpdateControls()
        {
            PersonList.Items.Clear();

            if (eval.PersonCombos != null)
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    PersonList.Items.Add(combo);
                }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            if (cpc.SelectedPersons.Length > 1)
            {
                PersonCombo combo = new PersonCombo();
                combo.Persons = cpc.SelectedPersons;

                eval.AddPersonCombo(combo);

                UpdateControls();
            }
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            PersonCombo todel;

            try
            {
                todel = (PersonCombo)PersonList.SelectedItem;
            }
            catch
            {
                return;
            }

            eval.RemovePersonCombo(todel);

            UpdateControls();
        }
    }
}
