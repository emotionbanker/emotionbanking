using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Alternates : UserControl
    {
        private Evaluation eval;

        public SettingsControl_Alternates(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            foreach (Question q in eval.Global.Questions)
                    QuestionList.Items.Add(q);
        }

        private void Search(string s)
        {
            QuestionList.Items.Clear();

            foreach (Question q in eval.Global.Questions)
            {
                if (q.ToString().ToLower().IndexOf(s.ToLower()) != -1)
                        QuestionList.Items.Add(q);
            }
        }

        private void searchBox_TextChanged(object sender, System.EventArgs e)
        {
            Search(searchBox.Text);
        }

        private void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAlternates((Question)QuestionList.SelectedItem);
        }

        private QuestionAlternate FindAlternate(Question q)
        {
            foreach (QuestionAlternate qa in eval.QuestionAlternates)
            {
                if (qa != null && q != null && qa.Master == q.ID) return qa;
            }

            return null;
        }

        private void LoadAlternates(Question q)
        {
            AlternatesBox.Text = "";

            QuestionAlternate qa = FindAlternate(q);

            if (qa == null)
            {
                qa = new QuestionAlternate(eval);
                qa.Master = q.ID;
                qa.Text = q.Text;
                eval.AddQuestionAlternate(qa);
            }

            qa.Debug("load");
            
            if (qa.QuestionList.Length > 0)
            {
                string all = string.Empty;
                all += qa.QuestionList[0];

                for (int i = 1; i < qa.QuestionList.Length; i++)
                {
                    all += "," + qa.QuestionList[i].ToString();
                }
                AlternatesBox.Text = all;
            }
            
        }

        private void AlternatesBox_TextChanged(object sender, EventArgs e)
        {
            if (CheckFormat())
            {
                Console.WriteLine("[TXTCHNG]\tfind and add");
                QuestionAlternate qa = FindAlternate((Question)QuestionList.SelectedItem);
                qa.QuestionList = new int[0];
                foreach (int id in GetList())
                {
                    qa.AddID(id);
                }
                qa.Debug("save");
            }
        }

        private ArrayList GetList()
        {
            ArrayList als = new ArrayList();

            foreach (string q in AlternatesBox.Text.Split(new Char[] { ',' }))
            {
                if (Int32.Parse(q) > 0) als.Add(Int32.Parse(q));
            }

            Console.WriteLine("[GETLIST()]\tlength=" + als.Count);
            return als;

        }

        private bool CheckFormat()
        {
            AlertLabel.Text = "";
            
            if (AlternatesBox.Text.Trim().Equals(string.Empty))
            {
                return false;
            }

            try
            {
                foreach (string q in AlternatesBox.Text.Split(new Char[] { ',' }))
                {
                    AlertLabel.Text += Int32.Parse(q) + " ";
                }

                AlertLabel.ForeColor = Color.Black;


                return true;
            }
            catch 
            {
                AlertLabel.ForeColor = Color.Red;
                AlertLabel.Text = "ACHTUNG: Die aktuellen Einstellungen sind nicht gültig! (Beistriche beachten)";
                return false;
            }
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            umfrage2._2008.Dialogs.QuestionDetails.ShowStats((Question)QuestionList.SelectedItem, eval);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestionAlternate qa = FindAlternate((Question)QuestionList.SelectedItem);

            qa.QuestionList = new int[0];

            LoadAlternates((Question)QuestionList.SelectedItem);

        }

    }
}
