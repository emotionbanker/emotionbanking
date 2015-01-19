using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.Polarity2008;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2
{
    public partial class UGSplitDialog : Form
    {
        public PolarityUGSplit split;
        public Evaluation eval;

        private ChoosePersonControl cpc;

        public UGSplitDialog(PolarityUGSplit split, Evaluation eval)
        {
            InitializeComponent();

            this.split = split;
            this.eval = eval;

            cpc = new ChoosePersonControl(eval, true);
            cpc.SelectionChanged += new CppEventHandler(cpc_SelectionChanged);
            cpc.Selected = split.person;
            cpc.Dock = DockStyle.Fill;
            UGBox.Controls.Add(cpc);

            SplitName.Text = split.Name;

            GroupSelector.Value = split.GroupID;

            if (split.split != null) SelectQButton.Text = split.split.SID;
            else SelectQButton.Text = "Frage auswählen...";

            SetAnswerBox();

            Col1Button.BackColor = split.Col1;
            Col2Button.BackColor = split.Col2;
        }

        void cpc_SelectionChanged()
        {
            if (cpc.Selected != null)
            {
                if (SplitName.Text.Equals(string.Empty)) SplitName.Text = cpc.Selected.Short;

                split.person = cpc.Selected;

                if (split.person != null)
                {
                    split.Col1 = Col1Button.BackColor = split.person.Color1;
                    split.Col2 = Col2Button.BackColor = split.person.Color2;
                }
            }
        }

        private void MultipartSaveDialog_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Brush b = new LinearGradientBrush(r, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

            g.FillRectangle(b, r);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SplitName_TextChanged(object sender, EventArgs e)
        {
            split.Name = SplitName.Text;
        }

        private void GroupSelector_ValueChanged(object sender, EventArgs e)
        {
            split.GroupID = (int)GroupSelector.Value;
        }

        private void SelectQButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                split.split = qs.SelectedQuestion;
                SelectQButton.Text = qs.SelectedQuestion.SID;
                SetAnswerBox();
            }
            else split.split = null;
        }

        private void SetAnswerBox()
        {
            if (split.split == null) AnswerBox.Enabled = false;
            else
            {
                AnswerBox.Enabled = true;

                foreach (string a in split.split.AnswerList)
                    AnswerBox.Items.Add(a);

                AnswerBox.SelectedIndex = split.splitID;
            }
        }

        private void AnswerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            split.splitID = AnswerBox.SelectedIndex;
        }

        private void Col1Button_Click(object sender, EventArgs e)
        {
            cd.Color = split.Col1;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Col1Button.BackColor = split.Col1 = cd.Color;
            }
        }

        private void Col2Button_Click(object sender, EventArgs e)
        {
            cd.Color = split.Col2;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Col2Button.BackColor = split.Col2 = cd.Color;
            }
        }

    }
}