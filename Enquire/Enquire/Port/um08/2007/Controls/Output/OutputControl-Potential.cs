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
using SortOrder = compucare.Enquire.Legacy.Umfrage2Lib.Output.SortOrder;

namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Potential : UserControl
    {

		public Potential rad;
		private Evaluation eval;

		public bool single;

		private ChoosePersonControl cpp;
		private Crossing cross;

		public OutputControl_Potential(Evaluation eval)
		{
            Set(eval, true, new Potential(eval));
		}

		public OutputControl_Potential(Evaluation eval, bool single)
		{
            Set(eval, single, new Potential(eval));
		}

        public OutputControl_Potential(Evaluation eval, bool single, Potential rad)
		{
			Set(eval, single, rad);

            cpp.SetSelection(rad.PersonList, rad.ComboList);

            sizeControl.SetSize(rad.width, rad.height);

			//question lists

            if (rad.Master != null) ChooseMaster.Text = "Teilungsfrage: " + rad.Master.SID;
            else ChooseMaster.Text = "Teilungsfrage: Keine";

            if (rad.Quest != null) ChooseSub.Text = "Wertungsfrage: " + rad.Quest.SID;
            else ChooseSub.Text = "Wertungsfrage: Keine";

			Preview();
		}

        private void Set(Evaluation eval, bool single, Potential rad)
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

            SortBox.Items.Add("Keine Sortierung");
            SortBox.Items.Add("Aufsteigend");
            SortBox.Items.Add("Absteigend");

            if (rad.sort == SortOrder.None) SortBox.SelectedIndex = 0;
            if (rad.sort == SortOrder.Ascending) SortBox.SelectedIndex = 1;
            if (rad.sort == SortOrder.Descending) SortBox.SelectedIndex = 2;

            InvertBox.Checked = rad.Inverted;

            EnableMin.Checked = rad.EnableMin;
            MinSlider.Value = rad.Min;
            MinSlider.Enabled = EnableMin.Checked;

            ReferenceBox.Checked = rad.EnableRef;
            SetRefBox();

            previewBox.picBox.SizeMode = PictureBoxSizeMode.Zoom;

            cpp.SetSelection(rad.PersonList, rad.ComboList);

            CheckPercent.Checked = rad.Percent;

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
            rad.eval = eval;

            rad.Compute();

            previewBox.SmallPreview = rad.OutputImage;
            previewBox.BigPreview = rad.OutputImage;
        }

        private void SetStyleControls()
        {
            DesignButton.Visible = true;
        }

        private void sizeControl_ChosenSizeChanged()
        {
            rad.width = sizeControl.ChosenWidth;
            rad.height = sizeControl.ChosenHeight;
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            rad.PersonList = cpp.SelectedPersons;
            rad.ComboList = cpp.SelectedCombos;
            Preview();
        }

        private void cross_CrossChanged()
        {
            rad.Cross = cross.cross;
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

        private void ChooseMaster_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                rad.Master = qs.SelectedQuestion;
            }
            else rad.Master = null;

            if (rad.Master != null) ChooseMaster.Text = "Teilungsfrage: " + rad.Master.SID;
            else ChooseMaster.Text = "Teilungsfrage: Keine";

            SetRefBox();

            Preview();
        }

        private void ChooseSub_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                rad.Quest = qs.SelectedQuestion;
            }
            else rad.Quest = null;

            if (rad.Quest != null) ChooseSub.Text = "Wertungsfrage: " + rad.Quest.SID;
            else ChooseSub.Text = "Wertungsfrage: Keine";

            Preview();
        }

        private void SortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortBox.SelectedIndex == 0) rad.sort = SortOrder.None;
            if (SortBox.SelectedIndex == 1) rad.sort = SortOrder.Ascending;
            if (SortBox.SelectedIndex == 2) rad.sort = SortOrder.Descending;

            Preview();
        }

        private void InvertBox_CheckedChanged(object sender, EventArgs e)
        {
            rad.Inverted = InvertBox.Checked;
            Preview();
        }

        private void CheckPercent_CheckedChanged(object sender, EventArgs e)
        {
            rad.Percent = CheckPercent.Checked;
            Preview();
        }

        private void EnableMin_CheckedChanged(object sender, EventArgs e)
        {
            rad.EnableMin = EnableMin.Checked;
            MinSlider.Enabled = rad.EnableMin;
            Preview();
        }

        private void MinSlider_ValueChanged(object sender, EventArgs e)
        {
            rad.Min = (int)MinSlider.Value;
            Preview();
        }

        private void ReferenceBox_CheckedChanged(object sender, EventArgs e)
        {
            rad.EnableRef = ReferenceBox.Checked;
            Preview();
        }


        private void SetRefBox()
        {
            RefBox.Items.Clear();
            if (rad.Master != null)
            {
                foreach (string a in rad.Master.AnswerList)
                    RefBox.Items.Add(a);
            }
        }

        private void RefBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rad.RefID = RefBox.SelectedIndex;
            Preview();
        }

        private void MinSlider_KeyUp(object sender, KeyEventArgs e)
        {
            rad.Min = (int)MinSlider.Value;
            Preview();
        }

    }
}
