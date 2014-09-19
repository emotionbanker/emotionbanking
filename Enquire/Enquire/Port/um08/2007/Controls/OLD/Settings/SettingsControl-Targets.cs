using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Targets : UserControl
    {
        private ChooseTargetControl ctc;
        private Evaluation eval;

        public SettingsControl_Targets(Evaluation eval)
        {
            this.eval = eval;
            InitializeComponent();

            ctc = new ChooseTargetControl(eval, false, false);
            ctc.Dock = DockStyle.Fill;
            ctc.SelectionChanged += new CtcEventHandler(ctc_SelectionChanged);
            ChooseTargetPanel.Controls.Add(ctc);

            UpdateControls();
        }

        private void UpdateControls()
        {
            TargetList.Items.Clear();

            if (eval.TargetCombos != null)
                foreach (TargetCombo combo in eval.TargetCombos)
                {
                    TargetList.Items.Add(combo);
                }
        }

        private void RemoveTarget_Click(object sender, System.EventArgs e)
        {
            TargetCombo todel;

            try
            {
                todel = (TargetCombo)TargetList.SelectedItem;
            }
            catch
            {
                return;
            }

            eval.RemoveTargetCombo(todel);

            UpdateControls();
        }

        private void AddTarget_Click(object sender, System.EventArgs e)
        {
            if (ctc.SelectedTargets.Length > 1)
            {
                TargetCombo combo = new TargetCombo(ComboName.Text);
                combo.SetTargets(ctc.SelectedTargets);

                eval.AddTargetCombo(combo);

                UpdateControls();
            }
        }

        private void ctc_SelectionChanged()
        {
            TargetCombo combo = new TargetCombo(ComboName.Text);
            combo.SetTargets(ctc.SelectedTargets);

            ComboName.Text = combo.LongName;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            try
            {
                ctc.SelectedItem.Test = !ctc.SelectedItem.Test;
                eval.ResetGlobal();
                eval.targetCombosChanged(this);
            }
            catch
            {

            }
        }

        private void ComboName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
