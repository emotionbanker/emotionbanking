using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Placeholders : UserControl
    {
        private Evaluation eval;

        public SettingsControl_Placeholders(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            foreach (QuestionPlaceholder q in eval.QuestionPlaceholders)
                    QuestionList.Items.Add(q);

            button2.Enabled = PHTextBox.Enabled = StatsButton.Enabled = (QuestionList.SelectedItem != null);
        }

  

        private void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = PHTextBox.Enabled = StatsButton.Enabled = (QuestionList.SelectedItem != null);

            if (QuestionList.SelectedItem != null)
            {
                QuestionPlaceholder ph = (QuestionPlaceholder)QuestionList.SelectedItem;
                label1.Text = "Platzhalter " + ph.PID + ": Bezeichnung:";
                if (ph.QuestionID != -1)
                    QView.Text = "" + ph.QuestionID;
                else
                    QView.Text = "?";
                PHTextBox.Text = ph.Text;
            }
            else
            {
                label1.Text = "kein Platzhalter ausgewählt.";
                QView.Text = "";
                PHTextBox.Text = "";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            QuestionPlaceholder ph = new QuestionPlaceholder();
            int index = 0;

            if (eval.QuestionPlaceholders.Count > 0)
                index = eval.QuestionPlaceholders[eval.QuestionPlaceholders.Count-1].PID + 1;

            ph.PID = index;
            
            ph.Text = "Neuer Platzhalter";

            eval.QuestionPlaceholders.Add(ph);
            QuestionList.Items.Add(ph);
        }

        private void label2_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eval.QuestionPlaceholders.Remove((QuestionPlaceholder)QuestionList.SelectedItem);
        }

        private void PHTextBox_TextChanged(object sender, EventArgs e)
        {
            QuestionPlaceholder ph = (QuestionPlaceholder)QuestionList.SelectedItem;
            ph.Text = PHTextBox.Text;

            QuestionList.Items.Clear();

            foreach (QuestionPlaceholder q in eval.QuestionPlaceholders)
                QuestionList.Items.Add(q);

            QuestionList.SelectedItem = ph;
            QuestionList.Refresh();
            
        }

        private void QView_Click(object sender, EventArgs e)
        {

        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            QuestionPlaceholder ph = (QuestionPlaceholder)QuestionList.SelectedItem;
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                
                ph.QuestionID = qs.SelectedQuestion.ID;
                QView.Text = "" + ph.QuestionID;
            }
            else
            {
                ph.QuestionID = -1;
                QView.Text = "?";
            }
        }

    }
}
