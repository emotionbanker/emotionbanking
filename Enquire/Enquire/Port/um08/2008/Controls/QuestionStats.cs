using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2008.Controls
{
    public partial class QuestionStats : UserControl
    {
        public QuestionStats()
        {
            InitializeComponent();
        }

        private QuestionAlternate FindAlternate(Question q, Evaluation eval)
        {
            foreach (QuestionAlternate qa in eval.QuestionAlternates)
            {
                if (qa != null && q != null && qa.Master == q.ID) return qa;
            }

            return null;
        }

        public void ShowStats(Question q, Evaluation eval)
        {
            if (q.ID>=100000)
            HeadLabel.Text = "Frage " + q.NullAnswers;
            else
            HeadLabel.Text = "Frage " + q.SID;

            TextLabel.Text = q.Text;
            foreach (string a in q.AnswerList)
                AnswerBox.Items.Add(a);
            TypeLabel.Text = q.Display;

            QuestionAlternate qa = FindAlternate(q, eval);

            if (qa == null || qa.QuestionList.Length == 0)
                AlertLabel.Text = "keine";
            else
            {
                AlertLabel.Text = "";
                foreach (int id in qa.QuestionList)
                    AlertLabel.Text += id + " ";
            }

            int ypos = 0;
            foreach (TargetData td in eval.Targets)
            {
                Label l1 = new Label();
                l1.Text = td.name;
                l1.Width = 200;
                l1.Location = new Point(0, ypos);
                Question tq = td.GetQuestion(q, eval);
                Label l2 = new Label();
                l2.Text = tq.GetUniqueUserCount().ToString();
                l2.Width = 200;
                l2.Location = new Point(220, ypos);

                DataPanel.Controls.Add(l1);
                DataPanel.Controls.Add(l2);
                ypos += l1.Height;
            }
        }//end method ShowStats()
    }
}
