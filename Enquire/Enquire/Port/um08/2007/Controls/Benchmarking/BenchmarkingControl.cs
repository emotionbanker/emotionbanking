using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace umfrage2._2007.Controls
{
    public partial class BenchmarkingControl : UserControl
    {
        private Evaluation eval;

        private Benchmarking bench;

        private ChooseTargetControl TargetSelector;
        private ChoosePersonControl cpp;


        public BenchmarkingControl(Evaluation eval)
        {
            InitializeComponent();

            this.eval = eval;

            bench = new Benchmarking(eval);

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);

            TargetSelector = new ChooseTargetControl(eval);
            TargetSelector.Dock = DockStyle.Fill;

            targetBox.Controls.Add(TargetSelector);

            cpp = new ChoosePersonControl(eval);
            cpp.Dock = DockStyle.Fill;

            personBox.Controls.Add(cpp);
        }

        private void AllQuestionsBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (AllQuestionsBox.Checked)
            {
                QBox.Enabled = QAdd.Enabled = QRemove.Enabled = false;
            }
            else
            {
                QBox.Enabled = QAdd.Enabled = QRemove.Enabled = true;
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            DialogBenchmarkColors dbc = new DialogBenchmarkColors(eval);
            dbc.ShowDialog();
        }

        private void wordBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private Question[] getList()
        {
            if (AllQuestionsBox.Checked)
            {
                return eval.Global.Questions;
            }
            else
            {
                Question[] qs = new Question[QBox.Items.Count];

                int i = 0;
                foreach (Question q in QBox.Items)
                    qs[i++] = q;

                return qs;
            }
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            bench.Name = "Benchmarking";
            bench.Word = wordBox.Checked;
            bench.ShowNulls = countNull.Checked;
            bench.Questions = getList();
            bench.PersonList = cpp.SelectedPersons;
            bench.ComboList = cpp.SelectedCombos;
            SaveDialog sd = new SaveDialog(bench);
            sd.ShowDialog();
        }

        private void QAdd_Click(object sender, System.EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox.Items.Add(q);
            }
        }

        private void QRemove_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < QBox.SelectedItems.Count; i++)
            {
                QBox.Items.Remove(QBox.SelectedItems[i]);
            }
        }
    }
}
