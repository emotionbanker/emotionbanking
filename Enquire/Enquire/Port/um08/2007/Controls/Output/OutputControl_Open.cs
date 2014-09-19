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
    public partial class OutputControl_Open : UserControl
    {
        
		private System.ComponentModel.IContainer components = null;

		public Open open;
		private Evaluation eval;
		private bool single;

		private ChoosePersonControl cpp;
		
		private Crossing cross;

		public OutputControl_Open(Evaluation eval)
		{
            Set(eval, true, new Open(eval));
		}

		public OutputControl_Open(Evaluation eval, bool single)
		{
            Set(eval, single, new Open(eval));
		}

		public OutputControl_Open(Evaluation eval, bool single, Open avg)
		{
			Set(eval, single, avg);
		
			//question lists

			foreach (Question q in avg.Questions)
				QBox.Items.Add(q);

			cpp.SetSelection(avg.PersonList, avg.ComboList);

			Preview();
		}

		private void Set(Evaluation eval, bool single, Open avg)
		{
			this.eval = eval;
			this.single = single;
			
			avg.eval = eval;

			this.open = avg;

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

			//this.GroupAnswersBox.Checked = avg.Group;

            styleBox.Items.Add(OutputStyle.Group);
            styleBox.Items.Add(OutputStyle.Standard);
            styleBox.Items.Add(OutputStyle.User);

            styleBox.SelectedItem = avg.Style;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

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
            open.ComboList = cpp.SelectedCombos;
            open.PersonList = cpp.SelectedPersons;
            open.Questions = getList();
            open.eval = eval;
            open.Cross = cross.Cross;
            //open.Group = this.GroupAnswersBox.Checked;
        }

        private void cross_CrossChanged()
        {
            open.Cross = cross.cross;
        }



        private void cpp_SelectionChanged()
        {
            Preview();
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }


        private void OutputControl_Open_Load(object sender, EventArgs e)
        {

        }

        private void QAdd_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval, "text");
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

        private void GoButton_Click(object sender, EventArgs e)
        {
            open.eval = eval;
            open.Cross = cross.Cross;
         
            SaveDialog sd = new SaveDialog(open);
            sd.ShowDialog();
}

        private void styleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            open.Style = (OutputStyle)styleBox.SelectedItem;
        }
       
    }



}
