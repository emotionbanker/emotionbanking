using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class PercentBaseForm : Form
    {
        public Question q;
        public Question tcq;
        public ArrayList crosses;

        private Evaluation eval;

        public bool Set = false;

        public string IString
        {
            get
            {
                if (Set) return q.ID + ":" + CrossList;
                else return "";
            }
        }

        public string CrossList
        {
            get
            {
                string l = string.Empty;

                int i = 0;
                foreach (Cross c in crosses)
                {
                    l += c.q.ID.ToString() + "." + c.a;
                    if (i++ < crosses.Count - 1) l += "#";
                }

                return l;
            }
        }

        public PercentBaseForm(Evaluation eval)
        {
            InitializeComponent();
            crosses = new ArrayList();
            this.CancelButton = CButton;
            this.eval = eval;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Set = true;
            Close();
        }

        private void qBox_TextChanged(object sender, EventArgs e)
        {
            Question f = null;
            try
            {
                int id = Int32.Parse(qBox.Text);

                foreach (Question gq in eval.Global.Questions)
                {
                    if (gq.ID == id) f = gq;
                }
            }
            catch
            {
                f = null;
            }

            if (f != null)
            {
                q = f;
                SelectQButton.Text = q.ID.ToString();

            }
        }

        private void SelectQButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                q = qs.SelectedQuestion;
                SelectQButton.Text = q.ID.ToString();
            }
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            Set = false;
        }

        private void cBox_TextChanged(object sender, EventArgs e)
        {
            Question f = null;
            try
            {
                int id = Int32.Parse(cBox.Text);

                foreach (Question gq in eval.Global.Questions)
                {
                    if (gq.ID == id) f = gq;
                }
            }
            catch
            {
                f = null;
            }

            if (f != null)
            {
                tcq = f;
                SelCrossButton.Text = f.SID.ToString();
            }
        }

        private void SelCrossButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                tcq = qs.SelectedQuestion;
                cBox.Text = tcq.ID.ToString();
            }
        }

        private void AddCross_Click(object sender, EventArgs e)
        {
            try
            {
                ContextMenu asel = new ContextMenu();

                if (tcq != null)
                {
                    foreach (string a in tcq.AnswerList)
                    {
                        MenuItem mi = new MenuItem();
                        mi.Text = a;
                        mi.Click += new EventHandler(mi_ClickCross);

                        asel.MenuItems.Add(mi);
                    }
                }

                asel.Show(AddCross, new Point(AddCross.Width, AddCross.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "addcross");
            }
        }

        void mi_ClickCross(object sender, EventArgs e)
        {
            Cross c = new Cross();
            MenuItem mi = (MenuItem)sender;

            c.q = tcq;
            c.a = tcq.GetAnswerId(mi.Text);

            crosses.Add(c);
            CrossView.Items.Add(c);
        }

        private void RemoveCross_Click(object sender, EventArgs e)
        {
            Cross c = (Cross)CrossView.SelectedItem;

            if (c != null)
            {
                crosses.Remove(c);
                CrossView.Items.Remove(c);
            }
        }
    }
}