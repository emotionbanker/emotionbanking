using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Questions : UserControl
    {
        Evaluation eval;

        public SettingsControl_Questions(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();


            this.UpdateQCombo();
        }

        private void UpdateQCombo()
        {
            QuestionComboList.Items.Clear();

            foreach (QuestionCombo qc in eval.QuestionCombos)
            {
                QuestionComboList.Items.Add(qc);
            }

            QuestionComboList.Refresh();
        }

        private void AddQuestionButton_Click(object sender, System.EventArgs e)
        {
            if (QuestionComboList.SelectedItem != null)
            {
                QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

                QuestionSelect qs = new QuestionSelect(eval);
                if (qs.ShowDialog() == DialogResult.OK && qs.SelectedQuestions != null)
                {
                    foreach (Question q in qs.SelectedQuestions)
                    {
                        qc.AddID(q.ID);
                    }
                    UpdateQComboList();
                }
            }
        }

        private void RemoveQuestionButton_Click(object sender, System.EventArgs e)
        {
            if (QuestionComboList.SelectedItem != null)
            {
                QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

                if (ComboView.SelectedItem != null)
                {
                    qc.RemoveID(((Question)ComboView.SelectedItem).ID);
                    UpdateQComboList();
                }
            }
        }

        private void NewComboButton_Click(object sender, System.EventArgs e)
        {
            QuestionCombo qc = new QuestionCombo(eval);
            eval.AddQuestionCombo(qc);

            UpdateQCombo();

            QuestionComboList.SelectedItem = qc;
        }

        private void DeleteComboButton_Click(object sender, System.EventArgs e)
        {
            if (QuestionComboList.SelectedItem != null)
            {
                eval.RemoveQuestionCombo((QuestionCombo)QuestionComboList.SelectedItem);
                UpdateQCombo();
            }
        }

        private void QuestionComboList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ReCombo();
        }

        private void ReCombo()
        {
            bool enable = false;

            if (QuestionComboList.SelectedItem != null)
            {
                UpdateQComboList();
                enable = true;

                QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

                label5.Visible = IVal.Visible = true;

                if (qc.Type == QuestionCombo.TYPE_COMBO)
                {
                    ComboButton.Checked = true;
                    label5.Visible = IVal.Visible = false;
                }
                else if (qc.Type == QuestionCombo.TYPE_SPLIT)
                {
                    IValButton.Checked = true;
                }
            }

            ComboView.Enabled = enable;
            DeleteComboButton.Enabled = enable;
            AddQuestionButton.Enabled = enable;
            RemoveQuestionButton.Enabled = enable;
            ComboTextBox.Enabled = enable;
        }

        private void ComboTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (QuestionComboList.SelectedItem != null)
            {
                QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;
                qc.Text = ComboTextBox.Text;
                UpdateComboListText(qc);
            }
        }

        private void IVal_ValueChanged(object sender, System.EventArgs e)
        {
            if (QuestionComboList.SelectedItem != null)
            {
                QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

                qc.SplitInterval = (int)IVal.Value;
            }
        }

        private void ComboButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ComboButton.Checked)
            {
                IValButton.Checked = false;

                if (QuestionComboList.SelectedItem != null)
                {
                    QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

                    qc.Type = QuestionCombo.TYPE_COMBO;
                }
                ReCombo();
            }
        }

        private void IValButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (IValButton.Checked)
            {
                ComboButton.Checked = false;

                if (QuestionComboList.SelectedItem != null)
                {
                    QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

                    qc.Type = QuestionCombo.TYPE_SPLIT;
                }
                ReCombo();
            }
        }

        private void UpdateQComboList()
        {
            ComboView.Items.Clear();
            if (QuestionComboList.SelectedItem != null)
            {
                QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

                foreach (int id in qc.QuestionList)
                {
                    Question q = eval.Global.GetQuestion(id, eval);

                    if (q != null)
                        ComboView.Items.Add(q);
                }

                ComboTextBox.Text = qc.Text;
                IVal.Value = qc.SplitInterval;
            }
        }

        private void UpdateComboListText(QuestionCombo qc)
        {
            UpdateQCombo();
            QuestionComboList.SelectedItem = qc;
        }

        private void SettingsControl_Questions_Load(object sender, EventArgs e)
        {

        }
    }
}
