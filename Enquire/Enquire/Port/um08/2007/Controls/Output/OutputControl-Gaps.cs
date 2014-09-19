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
    public partial class OutputControl_Gaps : UserControl
    {
        
		private System.ComponentModel.IContainer components = null;

		public Gaps gap;
		private Evaluation eval;
		private bool single;

		private ChoosePersonControl cpp;
		

		private Crossing cross;

 

		public OutputControl_Gaps(Evaluation eval)
		{
            Set(eval, true, new Gaps(eval));
		}

		public OutputControl_Gaps(Evaluation eval, bool single)
		{
            Set(eval, single, new Gaps(eval));
		}

		public OutputControl_Gaps(Evaluation eval, bool single, Gaps gap)
		{
			Set(eval, single, gap);
		
			cpp.SetSelection(gap.PersonList, gap.ComboList);

			//question lists

			foreach (Question q in gap.Questions)
				QBox.Items.Add(q);

			Preview();
		}

		private void Set(Evaluation eval, bool single, Gaps gap)
		{
			this.eval = eval;
			this.single = single;
			this.gap = gap;

			InitializeComponent();

            MasterDesignBox.SelectedItem = gap.Design;

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(gap.Cross);

			OutputNameControl onc = new OutputNameControl(gap);
			onc.Location = new Point(380,16);
			//HeaderPanel.Controls.Add(onc);


            MasterDesignBox.Items.Clear();
            MasterDesignBox.Items.Add("Victor 2006");
            MasterDesignBox.Items.Add("Victor 2007");

            MasterDesignBox.SelectedIndex = gap.Design;

            SetStyleControls();

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

        private void Preview()
		{
			if (QBox.Items.Count > 0)
			{
				gap.Questions = getList();
				gap.PersonList = cpp.SelectedPersons;
				gap.ComboList = cpp.SelectedCombos;
				gap.eval = eval;
				gap.Cross = cross.Cross;

				if (!single || !saveImages.Checked)
					gap.Images = false;
				else
					gap.Images = true;

				gap.Compute();

				//previewBox.SmallPreview = previewBox.BigPreview = gap.OutputImage;

				resultBox.Text = gap.ResultTable;


                         
            
            }
		}

        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            Preview();
        }

        private void cross_CrossChanged()
        {
            gap.Cross = cross.cross;
        }

        private Question[] getList()
        {
            Question[] qs = new Question[QBox.Items.Count];

            int i = 0;
            foreach (Question q in QBox.Items)
                qs[i++] = q;

            return qs;
        }

        private void OutputControl_Gaps_Load(object sender, EventArgs e)
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

        private void OverloadButton_Click(object sender, EventArgs e)
        {
            DialogTextOverload dto = new DialogTextOverload(eval, getList());
			dto.ShowDialog();

			Preview();
        }

        private void crossPanel_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            gap.eval = eval;
            gap.Cross = cross.Cross;
           
			SaveDialog sd = new SaveDialog(gap);
			sd.ShowDialog();
    
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetStyleControls()
        {
            //disable all

            //PrecBox.Visible = false;


            //enable
            if (gap.Design == Gaps.Victor2006)
            {
                //PrecBox.Visible = true;
            }
            else if (gap.Design == Gaps.Victor2007)
            {
                //ShadingBox.Visible = true;
            }
        }


        private void MasterDesignBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gap.Design = MasterDesignBox.SelectedIndex;
            SetStyleControls();
            Preview();
        }

        



    
    }

}
