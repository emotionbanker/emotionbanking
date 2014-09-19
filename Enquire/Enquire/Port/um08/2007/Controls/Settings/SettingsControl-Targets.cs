using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

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
            if (ctc.SelectedTargets.Length > 0)
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

        private void _btn_allesAuswaehlen_Click(object sender, EventArgs e)
        {
            TargetData[] t = eval.CombinedTargets;

            for (int i = 0; i < eval.CombinedTargets.Length; i++)
            {
                t[i].Included = true;
            }
            eval.targetCombosChanged(this);
            UpdateControls();
        }

        private void _btn_allesAbwaehlen_Click(object sender, EventArgs e)
        {
            TargetData[] t = eval.CombinedTargets;

            for (int i = 0; i < eval.CombinedTargets.Length; i++)
            {
                t[i].Included = false;
            }
            eval.targetCombosChanged(this);
            UpdateControls();
        }

        private void TargetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TargetCombo targetCombo = null; 
       
            if (eval.TargetCombos != null)
            {
                foreach (TargetCombo combo in eval.TargetCombos)
                {
                    if (combo.Name.Equals(TargetList.SelectedItem.ToString()))
                    {
                        targetCombo = combo;
                        break;
                    }
                }//end foreach
            }//end if
            

            TargetkombiList.Items.Clear();
            if (targetCombo != null)
            {
                string[] TargetNamen = targetCombo.LongName.Split(',');
                foreach (string n in TargetNamen)
                {
                    string m = n.Trim();
                    TargetkombiList.Items.Add(m);
                }
            }
            

        }//end TargetList_SelectedIndexChanged 

        
    }
}
