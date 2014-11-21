using System;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;
using SortOrder = compucare.Enquire.Legacy.Umfrage2Lib.Output.SortOrder;

namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Bar_Segment:UserControl
    {
        private GroupPersonControl gpc;

		public Bar_Segment bar;
		private Evaluation eval;

		public bool single;

		private ChoosePersonControl cpp;
		private Crossing cross;

		public OutputControl_Bar_Segment(Evaluation eval)
		{
            Set(eval, true, new Bar_Segment(eval));
		}

		public OutputControl_Bar_Segment(Evaluation eval, bool single)
		{
            Set(eval, single, new Bar_Segment(eval));
		}

        public OutputControl_Bar_Segment(Evaluation eval, bool single, Bar_Segment bar)
		{
			Set(eval, single, bar);

			cpp.SetSelection(bar.PersonList, bar.ComboList);

			foreach (Question q in bar.Questions)
				QBox.Items.Add(q);

            SetBaseBox(bar.BaseQ);

			Preview();
		}

        private void Set(Evaluation eval, bool single, Bar_Segment bar)
		{
            Console.WriteLine("bar base= " + bar.Base + "/ baseq= " + bar.BaseQ);

			this.eval = eval;
			this.single = single;

			this.bar = bar;

			InitializeComponent();
            

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			panel3.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(bar.Cross);

            ShowQuestionText.Checked = bar.ShowQuestion;
            ShowPersonText.Checked = bar.ShowPerson;
            ShowValueText.Checked = bar.ShowValue;
            ScrollBarWidth.Value = bar.width;
            ScrollBarWidthValue.Text = bar.width.ToString();
            ScrollBarHeight.Value = bar.height;
            ScrollBarHeightValue.Text = bar.height.ToString();



			QFontDialog.Font = bar.Txt;

            BColorPanel.BackColor = bar.BackColor;
            BColorTextPanel.BackColor = bar.BrushColor;

            //SortBox.Items.Add("Keine Sortierung");
            //SortBox.Items.Add("Aufsteigend");
            //SortBox.Items.Add("Absteigend");

            //if (bar.sort == SortOrder.None) SortBox.SelectedIndex = 0;
            //if (bar.sort == SortOrder.Ascending) SortBox.SelectedIndex = 1;
            //if (bar.sort == SortOrder.Descending) SortBox.SelectedIndex = 2;

            SetBaseBox(bar.BaseQ);
            BaseBox.Enabled = bar.Base;
            BaseCheck.Checked = bar.Base;

            //SortBox.SelectedIndexChanged += new EventHandler(SortBox_SelectedIndexChanged);

            SetStyleControls();
		}

        bool hbinit = false;


        /*void SortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortBox.SelectedIndex == 0) bar.sort = SortOrder.None;
            if (SortBox.SelectedIndex == 1) bar.sort = SortOrder.Ascending;
            if (SortBox.SelectedIndex == 2) bar.sort = SortOrder.Descending;

            Preview();
        }*/


        private void previewBox_Load(object sender, EventArgs e)
        {

        }


        private void Preview()
        {
            if (noprev) return;

            Console.WriteLine("\n--begin preview--");
            if (QBox.Items.Count > 0)
            {
                bar.eval = eval;
                bar.Cross = cross.Cross;

                bar.height = (int)ScrollBarHeight.Value;
                bar.width = (int)ScrollBarWidth.Value;
                //bar.width = previewBox.Width;
                //bar.height = previewBox.Height - 30;
                bar.PersonList = cpp.SelectedPersons;
                bar.ComboList = cpp.SelectedCombos;

                bar.ShowPerson = ShowPersonText.Checked;
                bar.ShowQuestion = ShowQuestionText.Checked;
                bar.ShowValue = ShowValueText.Checked;

                bar.Questions = getList();

                bar.Compute();

                previewBox.SmallPreview = bar.OutputImage;

                bar.Compute();



                previewBox.BigPreview = bar.OutputImage;
            }
            Console.WriteLine("--end preview--\n");
        }

        private void SetStyleControls()
        {
            //disable all

            BColorButton.Visible = BColorPanel.Visible = true;
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            bar.PersonList = cpp.SelectedPersons;
            bar.ComboList = cpp.SelectedCombos;
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
            bar.Cross = cross.cross;
        }

        
        private void QAdd_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox.Items.Add(q);
            }

            bar.Questions = getList();
            SetBaseBox();
            Preview();
        }

        private void QRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox.SelectedItems.Count; i++)
            {
                QBox.Items.Remove(QBox.SelectedItems[i]);
            }

            bar.Questions = getList();
            SetBaseBox();
            Preview();
        }

        private void SetBaseBox()
        {
            SetBaseBox(null);
        }

        private void SetBaseBox(Question sel)
        {
            if (sel == null)
                sel = (Question)BaseBox.SelectedItem;

            BaseBox.Items.Clear();
            foreach (Question q in  eval.Global.Questions)//getList())
            {
                BaseBox.Items.Add(q);
            }

            if (sel != null) BaseBox.SelectedItem = sel;
        }

        private void OverloadButton_Click(object sender, EventArgs e)
        {
            DialogTextOverload dto = new DialogTextOverload(eval, getList());
            dto.ShowDialog();

            Preview();
        }

        private void ShowQuestionText_CheckedChanged(object sender, EventArgs e)
        {
            bar.ShowQuestion = ShowQuestionText.Checked;
            Preview();
        }

        private void ShowPersonText_CheckedChanged(object sender, EventArgs e)
        {
            bar.ShowPerson = ShowPersonText.Checked;
            Preview();
        }

        private void ShowValueText_CheckedChanged(object sender, EventArgs e)
        {
            bar.ShowValue = ShowValueText.Checked;
            Preview();
        }

        private void QFontButton_Click(object sender, EventArgs e)
        {
            if (QFontDialog.ShowDialog() == DialogResult.OK)
                bar.Txt = QFontDialog.Font;

            Preview();
        }

        private void BColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = bar.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                bar.BackColor = colorDialog.Color;
                BColorPanel.BackColor = bar.BackColor;
                Preview();
            }
        }

        private void BColorTextButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = bar.BrushColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                bar.BrushColor = colorDialog.Color;
                BColorTextPanel.BackColor = bar.BrushColor;
                Preview();
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            bar.eval = eval;
            bar.Cross = cross.Cross;

            SaveDialog sd = new SaveDialog(bar);
            sd.ShowDialog();
        }

        bool noprev = false;


        private void HideBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void BaseCheck_CheckedChanged(object sender, EventArgs e)
        {
            bar.Base = BaseCheck.Checked;
            BaseBox.Enabled = bar.Base;
            Preview();
        }

        private void BaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.BaseQ = (Question)BaseBox.SelectedItem;
            Preview();
        }

        private void ScrollBarWidth_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollBarWidthValue.Text = ScrollBarWidth.Value.ToString();
            bar.width = (int)ScrollBarWidth.Value;
            Preview();
        }

        private void ScrollBarHeight_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollBarHeightValue.Text = ScrollBarHeight.Value.ToString();
            bar.height = (int)ScrollBarHeight.Value;
            Preview();
        }

        

        

    }
}
