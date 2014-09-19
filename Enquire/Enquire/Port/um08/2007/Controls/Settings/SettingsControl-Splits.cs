using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2008.Tools;
using Compucare.Enquire.Legacy.Umfrage2Lib.SystemExtensions;
using System.Collections;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Splits : UserControl
    {
        private Evaluation eval;
        private ChooseTargetControl ctc;

        private Question splitQuestion;

        public SettingsControl_Splits(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            ctc = new ChooseTargetControl(eval);
            ctc.Checkboxes = false;

            ChooseTargetPanel.Controls.Add(ctc);

            splitQuestion = null;
        }


        private void ChooseQuestion_Click(object sender, EventArgs e)
        {
            QuestionSelect dql = new QuestionSelect(eval);

            if (dql.ShowDialog() == DialogResult.OK)
            {
                splitQuestion = dql.SelectedQuestion;
                ChooseQuestion.Text = splitQuestion.SID;
            }
        }

        private void Split_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Ziel '"+ctc.SelectedItem+"' ist selektiert und wird mit der Frage '"+splitQuestion.Text+"' geteilt.");

          
            ctc.SelectedItem.Splits.Add(new TargetSplit(ctc.SelectedItem, splitQuestion));

            /*if (ctc.SelectedItem.WasCombo){
                ctc.SelectedItem.OriginalCombo.Splits.Add(new TargetSplit(ctc.SelectedItem, splitQuestion));
            }*/

            /*
            Console.WriteLine("[splits]\tadded " + splitQuestion.ID + " to " + ctc.SelectedItem.Name);

            Console.WriteLine("[splits]\tsplits for " + ctc.SelectedItem.Name);
            
            foreach (TargetSplit ts in ctc.SelectedItem.Splits)
                Console.WriteLine("\t\t" + ts.master.Name + "/" + ts.splitter.ID);
            */

            eval.ComputeTargetSplits2(eval, ctc.SelectedItem.Name.ToString());

            ChooseTargetPanel.Controls.Clear();

            bool checkboxes = ctc.Checkboxes;
            ctc = new ChooseTargetControl(eval);
            ctc.Checkboxes = checkboxes;

            ChooseTargetPanel.Controls.Add(ctc);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Alle Zielteilungen nach dem ausgewählten Schema werden gelöscht (alle nach der ausgewählten Frage geteilten Ziele in der aktuellen Hierarchieebene). Fortfahren?", "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                TargetSplit master = ctc.SelectedItem.masterSplit;

                master.master.Splits.Remove(master);
                
                eval.ComputeTargetSplits(eval);

                ChooseTargetPanel.Controls.Clear();

                ctc = new ChooseTargetControl(eval);

                ChooseTargetPanel.Controls.Add(ctc);
            }
            //////////////////////////////////////////////////////////
            /*TargetAndSplitQuestion tasq = null;
            string x = ctc.SelectedItem.masterSplit.master.ToString()+"/"+ctc.SelectedItem.masterSplit.splitter.ID;
            MessageBox.Show(x);
            foreach (TargetAndSplitQuestion tdParent in eval.TargetChildsParent)
            {
                if (tdParent.getTargetData().Name.Equals(x))
                {
                    tasq = tdParent;
                    break;
                }
            }
            if (tasq != null) eval.TargetChildsParent.Remove(tasq);*/
            /////////////////////////////////////////////////////////
            EvaluationSaver save = new EvaluationSaver(eval);
            save.SaveThreadBefore();
        }//end zielteilungenlöschen

        private void _btn_rename_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zielteilung unbenennen?", "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ctc.SelectedItem.name = _txt_rename.Text;
                ChooseTargetPanel.Controls.Clear();
                ctc = new ChooseTargetControl(eval);
                ChooseTargetPanel.Controls.Add(ctc);
            }              
        }//end zielteilungunbenennen
    }
}
