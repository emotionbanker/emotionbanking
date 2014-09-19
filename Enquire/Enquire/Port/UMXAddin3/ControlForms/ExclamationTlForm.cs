using System;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class ExclamationTlForm : Form
    {
        private Evaluation _eval;
        private Question _q;
        public IndivTLForm _itl;

        

        public String IString
        {
            get
            {
                return _q.ID + ":" + _itl.IString;
            }
        }


        public ExclamationTlForm(Evaluation eval)
        {
            _eval = eval;

            InitializeComponent();

            _itl = new IndivTLForm();
            _itl.setCompare();
        }

        private void qBox_TextChanged(object sender, EventArgs e)
        {
            Question f = null;
            try
            {
                int id = Int32.Parse(qBox.Text);

                foreach (Question gq in _eval.Global.Questions)
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
                _q = f;
                SelectQButton.Text = _q.SID;

            }
        }

        private void SelectQButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(_eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                _q = qs.SelectedQuestion;
                SelectQButton.Text = _q.SID;
            }
        }

        private void mw_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _itl.ShowDialog();
        }
    }
}