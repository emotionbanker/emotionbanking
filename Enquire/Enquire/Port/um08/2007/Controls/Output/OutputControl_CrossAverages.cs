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

namespace umfrage2._2007.Controls
{
    public partial class OutputControl_CrossAverages : UserControl
    {
        

		public CrossAverages avg;
		private Evaluation eval;
		private bool single;

		private ChoosePersonControl cpp;
		

		private Crossing cross;

		public OutputControl_CrossAverages(Evaluation eval)
		{
            Set(eval, true, new CrossAverages(eval));
		}

		public OutputControl_CrossAverages(Evaluation eval, bool single)
		{
            Set(eval, single, new CrossAverages(eval));
		}

		public OutputControl_CrossAverages(Evaluation eval, bool single, CrossAverages avg)
		{
			Set(eval, single, avg);

			
			cpp.SetSelection(avg.PersonList, avg.ComboList);

			//question lists

			foreach (Question q in avg.Questions)
				QBox.Items.Add(q);

			precControl.Value = avg.Precision;

			Preview();
		}

		private void Set(Evaluation eval, bool single, CrossAverages avg)
		{
			this.eval = eval;
			this.single = single;
			this.avg = avg;

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
				avg.Questions = getList();
				avg.PersonList = cpp.SelectedPersons;
				avg.ComboList = cpp.SelectedCombos;
				avg.eval = eval;
				avg.Precision = (int)precControl.Value;
				avg.Cross = cross.Cross;

				avg.Compute();

				//previewBox.SmallPreview = previewBox.BigPreview = gap.OutputImage;

				resultBox.Text = avg.ResultTable;
			}
		}


       

        private void cpp_SelectionChanged()
        {
            Preview();
        }

        private void cross_CrossChanged()
        {
            avg.Cross = cross.cross;
            Preview();
        }

        private void OutputControl_CrossAverages_Load(object sender, EventArgs e)
        {

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

        private void precControl_ValueChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            avg.eval = eval;
            avg.Cross = cross.Cross;
        

			SaveDialog sd = new SaveDialog(avg);
			sd.ShowDialog();
        }


        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }



}
