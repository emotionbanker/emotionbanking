using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;


namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Rank : UserControl
    {
        

		public Ranking rank;
		private Evaluation eval;
		private bool single;

		private ChoosePersonControl cpp;
		private Crossing cross;

		public OutputControl_Rank(Evaluation eval)
		{
            Set(eval, true, new Ranking(eval));
		}

		public OutputControl_Rank(Evaluation eval, bool single)
		{
            Set(eval, single, new Ranking(eval));
		}

		public OutputControl_Rank(Evaluation eval, bool single, Ranking avg)
		{
			Set(eval, single, avg);

			
			cpp.SetSelection(avg.PersonList, avg.ComboList);

			//question lists

			foreach (Question q in avg.Questions)
			{
				if (q != null)
				QBox.Items.Add(q);
			}

			FlopsBox.Checked = avg.Flops;

			Preview();
		}

		private void Set(Evaluation eval, bool single, Ranking avg)
		{
			this.eval = eval;
			this.single = single;
			this.rank = avg;

			InitializeComponent();


			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(avg.Cross);

			OutputNameControl onc = new OutputNameControl(avg);
			onc.Location = new Point(380,16);
			//HeaderPanel.Controls.Add(onc);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>

        private Question[] getList()
        {
            Question[] qs = new Question[QBox.Items.Count];

            int i = 0;
            foreach (Question q in QBox.Items)
                qs[i++] = q;

            return qs;
        }

        private void Preview()
        {
            if (QBox.Items.Count > 0)
            {
                rank.Questions = getList();
                rank.PersonList = cpp.SelectedPersons;
                rank.ComboList = cpp.SelectedCombos;
                rank.eval = eval;
                rank.Flops = FlopsBox.Checked;
                rank.Cross = cross.Cross;

                rank.Compute();

                resultBox.Text = rank.ResultTable;
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            rank.eval = eval;
            rank.Cross = cross.Cross;
           

            SaveDialog sd = new SaveDialog(rank);
            sd.ShowDialog();
        }

        private void QAdd_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox.Items.Add(q);
            }
            Preview();
        }

        private void QRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox.SelectedItems.Count; i++)
            {
                QBox.Items.Remove(QBox.SelectedItems[i]);
            }
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            Preview();
        }

        private void sizeControl_SizeChanged()
        {
            Preview();
        }

        private void cross_CrossChanged()
        {
            rank.Cross = cross.cross;
        }
        private void FlopsBox_CheckedChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutputControl_Rank_Load(object sender, EventArgs e)
        {

        }
    }
}
