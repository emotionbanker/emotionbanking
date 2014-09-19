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
    public partial class OutputControl_Bar : UserControl
    {
        private GroupPersonControl gpc;

		public Bar bar;
		private Evaluation eval;

		public bool single;

		private ChoosePersonControl cpp;
		private Crossing cross;

		public OutputControl_Bar(Evaluation eval)
		{
            Set(eval, true, new Bar(eval));
		}

		public OutputControl_Bar(Evaluation eval, bool single)
		{
            Set(eval, single, new Bar(eval));
		}

		public OutputControl_Bar(Evaluation eval, bool single, Bar bar)
		{
			Set(eval, single, bar);

			
			cpp.SetSelection(bar.PersonList, bar.ComboList);

			sizeControl.SetSize(bar.width, bar.height);

			//question lists

			foreach (Question q in bar.Questions)
				QBox.Items.Add(q);

            SetBaseBox(bar.BaseQ);

			Preview();
		}

		private void Set(Evaluation eval, bool single, Bar bar)
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

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);


            MasterDesignBox.Items.Clear();
            MasterDesignBox.Items.Add("Victor 2006");
            MasterDesignBox.Items.Add("Victor 2007");


            MasterDesignBox.SelectedIndex = bar.Design;

			InvertBox.Checked = bar.invert;
			PcntBox.Checked = bar.Percent;
			HorBox.Checked = bar.Horizontal;
            OppositesBox.Checked = bar.Opposites;
            AbsoluteBox.Checked = bar.Absolutes;

			ShowBox.Checked = bar.ShowText;

			QFontDialog.Font = bar.Txt;

            BColorPanel.BackColor = bar.BackColor;

            SortBox.Items.Add("Keine Sortierung");
            SortBox.Items.Add("Aufsteigend");
            SortBox.Items.Add("Absteigend");

            TypeBox.Items.Add(Bar.BarType.Standard);
            TypeBox.Items.Add(Bar.BarType.Kombiniert);
            TypeBox.Items.Add(Bar.BarType.Durchschnitt);

            TypeBox.SelectedItem = bar.Type;

            if (bar.sort == SortOrder.None) SortBox.SelectedIndex = 0;
            if (bar.sort == SortOrder.Ascending) SortBox.SelectedIndex = 1;
            if (bar.sort == SortOrder.Descending) SortBox.SelectedIndex = 2;

            SetBaseBox(bar.BaseQ);
            BaseBox.Enabled = bar.Base;
            BaseCheck.Checked = bar.Base;

            SortBox.SelectedIndexChanged += new EventHandler(SortBox_SelectedIndexChanged);

            SetHideBox();

            _manualWidth.Checked = bar.UseManualWidth;
            _manualWidthSpinner.Value = bar.ManualWidth;

            

            SetStyleControls();

            SetGroupControl();
		}

        bool hbinit = false;


        public void SetGroupControl()
        {
            gpc = new GroupPersonControl(bar.CombinedPersons, bar.PersonGroups);

            gpc.GroupsChanged += new GroupPersonControlHandler(gpc_GroupsChanged);

            gpc.Dock = DockStyle.Fill;

            GroupPanel.Controls.Clear();
            GroupPanel.Controls.Add(gpc);
        }

        void gpc_GroupsChanged()
        {
            bar.PersonGroups = gpc.groups;
            Preview();
        }

        void SortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortBox.SelectedIndex == 0) bar.sort = SortOrder.None;
            if (SortBox.SelectedIndex == 1) bar.sort = SortOrder.Ascending;
            if (SortBox.SelectedIndex == 2) bar.sort = SortOrder.Descending;

            Preview();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>


        private void previewBox_Load(object sender, EventArgs e)
        {

        }


        private void Preview()
        {
            if (noprev) return;

            Console.WriteLine("\n--begin preview--");
            if (QBox.Items.Count > 0)
            {
                //hidebox
                if (!hbinit)
                {
                    bar.HideAnswers.Clear();
                    foreach (string a in bar.getAnswerList())
                    {
                        bool found = false;
                        foreach (string s in _hideBox.CheckedItems)
                            if (s.Equals(a)) found = true;

                        if (!found && !bar.HideAnswers.Contains(a)) bar.HideAnswers.Add(a);
                    }

                    bar.AnswerOrder.Clear();
                    foreach (String answer in _hideBox.Items)
                    {
                        bar.AnswerOrder.Add(answer);
                    }
                }


                bar.text = false;
                bar.eval = eval;
                bar.Cross = cross.Cross;
                bar.width = previewBox.Width;
                //bar.height = previewBox.Height - 30;
                bar.PersonList = cpp.SelectedPersons;
                bar.ComboList = cpp.SelectedCombos;

                bar.Questions = getList();

                bar.Compute();

                previewBox.SmallPreview = bar.OutputImage;

                bar.text = true;
                bar.width = sizeControl.ChosenWidth;
                bar.height = sizeControl.ChosenHeight;

                bar.Compute();

                previewBox.BigPreview = bar.OutputImage;
            }
            Console.WriteLine("--end preview--\n");
        }

        private void SetStyleControls()
        {
            //disable all

            BColorButton.Visible = BColorPanel.Visible = false;
            DesignButton.Visible = false;
            OppositesBox.Visible = false;

            //enable
            if (bar.Design == Bar.Victor2006)
            {
                BColorButton.Visible = BColorPanel.Visible = true;
                //PrecBox.Visible = true;
            }
            else if (bar.Design == Bar.Victor2007)
            {
                //ShadingBox.Visible = true;
                DesignButton.Visible = true;
                OppositesBox.Visible = true;
            }
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            bar.PersonList = cpp.SelectedPersons;
            bar.ComboList = cpp.SelectedCombos;
            SetGroupControl();
            SetHideBox();
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
            SetHideBox();
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
            SetHideBox();
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

        private void InvertBox_CheckedChanged(object sender, EventArgs e)
        {
            bar.invert = InvertBox.Checked;
            Preview();
        }

        private void PcntBox_CheckedChanged(object sender, EventArgs e)
        {
            bar.Percent = PcntBox.Checked;

            label1.Visible = _hideBox.Visible = _moveUp.Visible = _moveDown.Visible = bar.Percent;

            Preview();
        }

        private void HorBox_CheckedChanged(object sender, EventArgs e)
        {
            bar.Horizontal = HorBox.Checked;
            Preview();
        }

        private void ShowBox_CheckedChanged(object sender, EventArgs e)
        {
            bar.ShowText = ShowBox.Checked;
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

        private void GoButton_Click(object sender, EventArgs e)
        {
            bar.eval = eval;
            bar.Cross = cross.Cross;
            bar.width = sizeControl.ChosenWidth;
            bar.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(bar);
            sd.ShowDialog();
        }

        private void MasterDesignBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.Design = MasterDesignBox.SelectedIndex;
            SetStyleControls();
            Preview();
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(bar.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                bar.dnc = cs.Settings;
                Preview();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OppositesBox_CheckedChanged(object sender, EventArgs e)
        {
            bar.Opposites = OppositesBox.Checked;
            Preview();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        bool noprev = false;

        private void SetHideBox()
        {
            noprev = true;
            label1.Visible = _hideBox.Visible = _moveUp.Visible = _moveDown.Visible = bar.Percent;

            hbinit = true;
            _hideBox.Items.Clear();

            foreach (String a in bar.AnswerOrder)
            {
                Boolean found = false;
                foreach (Question q in bar.Questions)
                {
                    found |= q.ContainsAnswer(a);
                }

                if (found)
                {
                    _hideBox.Items.Add(a, !bar.HideAnswers.Contains(a));
                }
            }

            foreach (Question q in bar.Questions)
            {
                foreach (string a in q.AnswerList)
                {
                    int i = 0;
                    bool nItem = false;
                    if (!_hideBox.Items.Contains(a))
                    {
                        nItem = true;
                        i = _hideBox.Items.Add(a);
                    } 

                    bool check = true;
                    foreach (string hl in bar.HideAnswers)
                    {
                        if (hl.Equals(a)) check = false;
                    }
                    if (nItem)
                    {
                        _hideBox.SetItemChecked(i, check);
                    }
                }
            }
            hbinit = false;
            noprev = false;
        }


        private void HideBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Preview();
        }

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.Type = (Bar.BarType)TypeBox.SelectedItem;
            Preview();
        }

        private void QBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void AbsoluteBox_CheckedChanged(object sender, EventArgs e)
        {
            bar.Absolutes = AbsoluteBox.Checked;
            Preview();
        }

        private void MoveUpClick(object sender, EventArgs e)
        {
            if (_hideBox.SelectedIndex > 0)
            {
                int i = _hideBox.SelectedIndex;
                String item = _hideBox.Items[_hideBox.SelectedIndex] as String;
                Boolean check = _hideBox.CheckedItems.Contains(item);

                _hideBox.Items.RemoveAt(_hideBox.SelectedIndex);
                _hideBox.Items.Insert(i - 1, item);
                _hideBox.SetItemChecked(i -1, check);
                _hideBox.SelectedIndex = i - 1;

            }
        }

        private void MoveDownClick(object sender, EventArgs e)
        {
            if (_hideBox.SelectedIndex < _hideBox.Items.Count && _hideBox.SelectedIndex != -1)
            {
                int i = _hideBox.SelectedIndex;
                String item = _hideBox.Items[_hideBox.SelectedIndex] as String;
                Boolean check = _hideBox.CheckedItems.Contains(item);

                _hideBox.Items.RemoveAt(_hideBox.SelectedIndex);
                _hideBox.Items.Insert(i+ 1, item);
                _hideBox.SetItemChecked(i +1, check);
                _hideBox.SelectedIndex = i + 1;

            }
        }

        private void ManualWidthCheckedChanged(object sender, EventArgs e)
        {
            _manualWidthSpinner.Enabled = _manualWidth.Checked;
            bar.UseManualWidth = _manualWidth.Checked;
            Preview();
        }

        private void ManualWidthSpinnerValueChanged(object sender, EventArgs e)
        {
            bar.ManualWidth = (Int32)_manualWidthSpinner.Value;
            Preview();
        }
    }
}
