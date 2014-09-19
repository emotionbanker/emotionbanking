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
using umfrage2._2007.Dialogs;

namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Radar : UserControl
    {

		public Radar rad;
		private Evaluation eval;

		public bool single;

		private ChoosePersonControl cpp;
		private Crossing cross;

		public OutputControl_Radar(Evaluation eval)
		{
            Set(eval, true, new Radar(eval));
		}

		public OutputControl_Radar(Evaluation eval, bool single)
		{
            Set(eval, single, new Radar(eval));
		}

        public OutputControl_Radar(Evaluation eval, bool single, Radar rad)
		{
			Set(eval, single, rad);


            cpp.SetSelection(rad.PersonList, rad.ComboList);

            sizeControl.SetSize(rad.width, rad.height);

			//question lists

            foreach (Question q in rad.Questions)
				QBox.Items.Add(q);	

			Preview();
		}

        private void Set(Evaluation eval, bool single, Radar rad)
		{
			this.eval = eval;
			this.single = single;

            this.rad = rad;

			InitializeComponent();
            

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			panel3.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(rad.Cross);	

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);

            SetStyleControls();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>


        private void previewBox_Load(object sender, EventArgs e)
        {

        }


        private void Preview()
        {
            if (QBox.Items.Count > 0)
            {
                rad.eval = eval;
                rad.Cross = cross.Cross;
                rad.width = previewBox.Width;
                rad.height = previewBox.Height;
                rad.PersonList = cpp.SelectedPersons;
                rad.ComboList = cpp.SelectedCombos;

                rad.Questions = getList();

                rad.Compute();

                previewBox.SmallPreview = rad.OutputImage;

                rad.width = sizeControl.ChosenWidth;

                rad.Compute();

                previewBox.BigPreview = rad.OutputImage;
            }
        }

        private void SetStyleControls()
        {
            DesignButton.Visible = true;
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            Preview();
        }

        private Question[] getList()
        {
            Question[] qs = new Question[QBox.Items.Count];

            int i = 0;
            foreach (Question q in QBox.Items)
                qs[i++] = q;

            return qs;
        }

        private void cross_CrossChanged()
        {
            rad.Cross = cross.cross;
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


        private void GoButton_Click(object sender, EventArgs e)
        {
            rad.eval = eval;
            rad.Cross = cross.Cross;
            rad.width = sizeControl.ChosenWidth;
            rad.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(rad);
            sd.ShowDialog();
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(rad.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                rad.dnc = cs.Settings;
                Preview();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
