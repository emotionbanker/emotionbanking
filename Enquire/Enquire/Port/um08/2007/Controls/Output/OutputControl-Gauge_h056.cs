using System;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;
using SortOrder = compucare.Enquire.Legacy.Umfrage2Lib.Output.SortOrder;
using dotnetCHARTING.WinForms;
using Compucare.Enquire.Legacy.Umfrage2Lib._2007.Dialogs;
using System.Collections;

namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Gauge_h056: UserControl
    {
        private Evaluation eval;
        public Gauge_h056 gauge_h056;
        private GroupPersonControl gpc;
        private Hashtable answerList;

        public bool single;

        private ChoosePersonControl cpp;
        private Crossing cross;

        private Chart c;
       
        public OutputControl_Gauge_h056(Evaluation eval)
        {
            Set(eval, true, new Gauge_h056(eval));
        }

        public OutputControl_Gauge_h056(Evaluation eval,bool single)
        {
            Set(eval, single, new Gauge_h056(eval));
        }

        public OutputControl_Gauge_h056(Evaluation eval, bool single, Gauge_h056 gauge)
        {
            Set(eval, true, gauge);
            cpp.SetSelection(gauge_h056.PersonList, gauge_h056.ComboList);

            sizeControl.SetSize(gauge_h056.width, gauge_h056.height);

            //question lists

            foreach (Question q in gauge_h056.Questions)
                QBox.Items.Add(q);

            SetBaseBox(gauge_h056.BaseQ);

            Preview();
        }

        /*private void Set(Evaluation eval, bool single, Gauge_h056 gauge_h056)
        {
            InitializeComponent();
           
        }*/

        private void Set(Evaluation eval, bool single, Gauge_h056 gauge_h056)
        {

            this.eval = eval;
            this.single = single;
            this.answerList = gauge_h056.answerList;
            this.gauge_h056 = gauge_h056;

            InitializeComponent();


            cpp = new ChoosePersonControl(eval);
            cpp.SelectionChanged += new CppEventHandler(cpp_SelectionChanged);
            cpp.Dock = DockStyle.Fill;

            panel3.Controls.Add(cpp);

            cross = new Crossing(eval);
            cross.Dock = DockStyle.Fill;
            cross.CrossChanged += new CrossEventHandler(cross_CrossChanged);
            crossPanel.Controls.Add(cross);

            cross.UpdateCross(gauge_h056.Cross);

            sizeControl.ChosenSizeChanged += new SizeEventHandler(sizeControl_ChosenSizeChanged);



            InvertBox.Checked = gauge_h056.invert;
            PcntBox.Checked = gauge_h056.Percent;
            checkBoxMarker.Checked = gauge_h056.Marker;


            OppositesBox.Checked = gauge_h056.Opposites;
            AbsoluteBox.Checked = gauge_h056.Absolutes;

            ShowBox.Checked = gauge_h056.ShowText;

            QFontDialog.Font = gauge_h056.Txt;


            SortBox.Items.Add("Keine Sortierung");
            SortBox.Items.Add("Aufsteigend");
            SortBox.Items.Add("Absteigend");

            SeriesBox.Items.Add(Gauge_h056.GaugeEffekt.Style1);
            SeriesBox.Items.Add(Gauge_h056.GaugeEffekt.Style2);
            SeriesBox.SelectedItem = gauge_h056.GEffekt;

            TypeBox.Items.Add(Gauge_h056.GaugeTypeh056.Standard);
            //TypeBox.Items.Add(Gauge_h056.GaugeTypeh056.Kombiniert);
            //TypeBox.Items.Add(Gauge_h056.GaugeTypeh056.Durchschnitt);

            TypeBox.SelectedItem = gauge_h056.Type;

            if (gauge_h056.sort == SortOrder.None) SortBox.SelectedIndex = 0;
            if (gauge_h056.sort == SortOrder.Ascending) SortBox.SelectedIndex = 1;
            if (gauge_h056.sort == SortOrder.Descending) SortBox.SelectedIndex = 2;

            SetBaseBox(gauge_h056.BaseQ);
            BaseBox.Enabled = gauge_h056.Base;
            BaseCheck.Checked = gauge_h056.Base;

            SortBox.SelectedIndexChanged += new EventHandler(SortBox_SelectedIndexChanged);
            SetHideBox();

            _manualWidth.Checked = gauge_h056.UseManualWidth;
            _manualWidthSpinner.Value = gauge_h056.ManualWidth;

            checkBoxHeight.Checked = gauge_h056.manuelHeight;
            try
            {
                _manualHeightSpinner.Value = gauge_h056.manuelHeightValue;
            }
            catch
            {
                _manualHeightSpinner.Value = 100;
            }

            SetStyleControls();

            SetGroupControl();
        }

        bool hbinit = false;


        public void SetGroupControl()
        {
            gpc = new GroupPersonControl(gauge_h056.CombinedPersons, gauge_h056.PersonGroups);

            gpc.GroupsChanged += new GroupPersonControlHandler(gpc_GroupsChanged);

            gpc.Dock = DockStyle.Fill;

            GroupPanel.Controls.Clear();
            GroupPanel.Controls.Add(gpc);
        }

        void gpc_GroupsChanged()
        {
            gauge_h056.PersonGroups = gpc.groups;
            Preview();
        }

        void SortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortBox.SelectedIndex == 0) gauge_h056.sort = SortOrder.None;
            if (SortBox.SelectedIndex == 1) gauge_h056.sort = SortOrder.Ascending;
            if (SortBox.SelectedIndex == 2) gauge_h056.sort = SortOrder.Descending;

            Preview();
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
                    gauge_h056.HideAnswers.Clear();
                    foreach (string a in gauge_h056.getAnswerList())
                    {
                        bool found = false;
                        foreach (string s in _hideBox.CheckedItems)
                            if (s.Equals(a)) found = true;

                        if (!found && !gauge_h056.HideAnswers.Contains(a)) gauge_h056.HideAnswers.Add(a);
                    }

                    gauge_h056.AnswerOrder.Clear();
                    foreach (String answer in _hideBox.Items)
                    {
                        gauge_h056.AnswerOrder.Add(answer);
                    }
                }


                gauge_h056.text = false;
                gauge_h056.eval = eval;
                gauge_h056.Cross = cross.Cross;
                gauge_h056.width = previewBox.Width;
                
                gauge_h056.PersonList = cpp.SelectedPersons;
                gauge_h056.ComboList = cpp.SelectedCombos;

                gauge_h056.Questions = getList();

                gauge_h056.Compute();

                previewBox.SmallPreview = gauge_h056.OutputImage;

                gauge_h056.text = true;
                gauge_h056.width = sizeControl.ChosenWidth;
                gauge_h056.height = sizeControl.ChosenHeight;

                gauge_h056.Compute();

                previewBox.BigPreview = gauge_h056.OutputImage;
            }
            Console.WriteLine("--end preview--\n");
        }
        private void previewBox_Load(object sender, EventArgs e)
        {
        }

        private void SetStyleControls()
        {
            //disable all

            DesignButton.Visible = false;
            OppositesBox.Visible = false;

            //enable
        
                //ShadingBox.Visible = true;
                DesignButton.Visible = true;
                OppositesBox.Visible = true;
            
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            gauge_h056.PersonList = cpp.SelectedPersons;
            gauge_h056.ComboList = cpp.SelectedCombos;
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
            gauge_h056.Cross = cross.cross;
        }


        private void QAdd_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox.Items.Add(q);
            }

            gauge_h056.Questions = getList();
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

            gauge_h056.Questions = getList();
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
            foreach (Question q in eval.Global.Questions)//getList())
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
            gauge_h056.invert = InvertBox.Checked;
            Preview();
        }

        private void PcntBox_CheckedChanged(object sender, EventArgs e)
        {
            gauge_h056.Percent = PcntBox.Checked;
            try
            {
                if (PcntBox.Checked)
                    _manualHeightSpinner.Value = gauge_h056.getPercentValue();
                else
                    _manualHeightSpinner.Value = Convert.ToInt32(gauge_h056.getMaxYValue() + 1);
            }
            catch
            {
               if (gauge_h056.Percent == true)
                    _manualHeightSpinner.Value = 100;
                else
                    _manualHeightSpinner.Value = 1;
            
            }

         
            
            label1.Visible = _hideBox.Visible = _moveUp.Visible = _moveDown.Visible = gauge_h056.Percent;

            Preview();
        }

        private void ShowBox_CheckedChanged(object sender, EventArgs e)
        {
            gauge_h056.ShowText = ShowBox.Checked;
            Preview();
        }

        private void QFontButton_Click(object sender, EventArgs e)
        {
            if (QFontDialog.ShowDialog() == DialogResult.OK)
                gauge_h056.Txt = QFontDialog.Font;

            Preview();
        }

        private void BColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = gauge_h056.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                gauge_h056.BackColor = colorDialog.Color;
                Preview();
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            gauge_h056.eval = eval;
            gauge_h056.Cross = cross.Cross;
            gauge_h056.width = sizeControl.ChosenWidth;
            gauge_h056.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(gauge_h056);
            sd.ShowDialog();
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(gauge_h056.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                gauge_h056.dnc = cs.Settings;
                Preview();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OppositesBox_CheckedChanged(object sender, EventArgs e)
        {
            gauge_h056.Opposites = OppositesBox.Checked;
            Preview();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        bool noprev = false;

        private void SetHideBox()
        {
            noprev = true;
            label1.Visible = _hideBox.Visible = _moveUp.Visible = _moveDown.Visible = gauge_h056.Percent;

            hbinit = true;
            _hideBox.Items.Clear();

            foreach (String a in gauge_h056.AnswerOrder)
            {
                Boolean found = false;
                foreach (Question q in gauge_h056.Questions)
                {
                    found |= q.ContainsAnswer(a);
                }

                if (found)
                {
                    _hideBox.Items.Add(a, !gauge_h056.HideAnswers.Contains(a));
                }
            }

            foreach (Question q in gauge_h056.Questions)
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
                    foreach (string hl in gauge_h056.HideAnswers)
                    {
                        if (hl.Equals(a)) check = false;
                    }
                    if (nItem)
                    {
                        _hideBox.SetItemChecked(i, check);
                    }
                }
            }

            foreach(string a in _hideBox.Items){
                if(!answerList.ContainsKey(a))
                answerList.Add(a,a);
                gauge_h056.answerList = answerList;
            }

            //_hideBox.Items.Clear();
            /*foreach(string a in answerList.Values){
                _hideBox.Items.Add(a,true);
            }*/
            /*foreach (string a in _hideBox.Items)
            {
                int i = 0;
                _hideBox.SetItemChecked(i, true);
                i++;
            }*/



            /*if(_hideBox.Items.Count<answerList.Count){
                foreach (string a in answerList.Keys)
                {
                    if(!_hideBox.Items.Contains(a))
                    {
                        gauge_h056.answerList.Remove(a);
                    }
                }
            }*/
            hbinit = false;
            noprev = false;
        }


        private void HideBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Preview();
        }

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gauge_h056.Type = (Gauge_h056.GaugeTypeh056)TypeBox.SelectedItem;
            Preview();
        }

        private void QBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BaseCheck_CheckedChanged(object sender, EventArgs e)
        {
            gauge_h056.Base = BaseCheck.Checked;
            BaseBox.Enabled = gauge_h056.Base;
            Preview();
        }

        private void BaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gauge_h056.BaseQ = (Question)BaseBox.SelectedItem;
            Preview();
        }

        private void AbsoluteBox_CheckedChanged(object sender, EventArgs e)
        {
            gauge_h056.Absolutes = AbsoluteBox.Checked;
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
                _hideBox.SetItemChecked(i - 1, check);
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
                _hideBox.Items.Insert(i + 1, item);
                _hideBox.SetItemChecked(i + 1, check);
                _hideBox.SelectedIndex = i + 1;

            }
        }

        private void ManualWidthCheckedChanged(object sender, EventArgs e)
        {
            _manualWidthSpinner.Enabled = _manualWidth.Checked;
            gauge_h056.UseManualWidth = _manualWidth.Checked;
            Preview();
        }

        private void ManualWidthSpinnerValueChanged(object sender, EventArgs e)
        {
            gauge_h056.ManualWidth = (Int32)_manualWidthSpinner.Value;
            Preview();
        }
        
        private SeriesCollection getRandomData()
        {
            Random myR = new Random(1);
            SeriesCollection SC = new SeriesCollection();
            for (int a = 1; a < 5; a++)
            {
                Series s = new Series("Series " + a.ToString());
                for (int b = 1; b < 2; b++)
                {
                    Element e = new Element("Element " + b.ToString(),b,new DateTime());
                    e.YValue = myR.Next(50);
                    s.Elements.Add(e);
                }
                SC.Add(s);
            }
            return SC;
        }
       
        private SeriesCollection getLiveData()
        {
            DataEngine de = new DataEngine("ConnectionString goes here");
            de.SqlStatement = "SELECT XAxisColumn, YAxisColumn FROM ....";
            return de.GetSeries();
        }

        private void SeriesBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            gauge_h056.GEffekt = (Gauge_h056.GaugeEffekt)SeriesBox.SelectedItem;
            Preview();
        }

        private void checkBoxMarker_CheckedChanged(object sender, EventArgs e)
        {
            gauge_h056.Marker = checkBoxMarker.Checked;
            Preview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MarkerSettings cs = new MarkerSettings(gauge_h056.marker, gauge_h056);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                gauge_h056.marker = cs.Settings;
                Preview();
            }
        }

        private void checkBoxHeight_CheckedChanged(object sender, EventArgs e)
        {
            _manualHeightSpinner.Enabled = checkBoxHeight.Checked; //Spinner wird steuerbar

            try
            {
                if (PcntBox.Checked)
                    _manualHeightSpinner.Value = gauge_h056.PercentValue;
                else
                    _manualHeightSpinner.Value = Convert.ToInt32(gauge_h056.MaxYValue + 1);
            }
            catch
            {
                if (PcntBox.Checked)
                    _manualHeightSpinner.Value = 100;
                else
                    _manualHeightSpinner.Value = 1;

            }
            

            gauge_h056.manuelHeight = checkBoxHeight.Checked;      //s
            
            gauge_h056.manuelHeightValue = Convert.ToInt32(_manualHeightSpinner.Value);
            Preview();
        }

        private void _manualHeightSpinner_ValueChanged(object sender, EventArgs e)
        {
            gauge_h056.manuelHeightValue = Convert.ToInt32(_manualHeightSpinner.Value);
            Preview();
        }

        private void OverLoadAnswers_Click(object sender, EventArgs e)
        {
            DialogTextOverload dto = new DialogTextOverload(eval, getList(), gauge_h056);
            dto.ShowDialog();
            SetHideBox();
            Preview();
        }


        private void Antworttexte_CheckedChanged(object sender, EventArgs e)
        {
            gauge_h056.Antwortexte = Antworttexte.Checked;
            Preview();
        }
    }
}
