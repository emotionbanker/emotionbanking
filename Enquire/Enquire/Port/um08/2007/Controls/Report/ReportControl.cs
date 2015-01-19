using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.Polarity2008;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.Star;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2007.Controls
{
    public partial class ReportControl : UserControl
    {
        private Evaluation eval;

        public ReportControl(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            UpdateReportData();
            UpdateOutputData();
            UpdateControls();

            eval.ReportDataChanged += new EvaluationEventHandler(eval_ReportDataChanged);
            eval.OutputDataChanged += new EvaluationEventHandler(eval_OutputDataChanged);

            OutputListView.OrderChanged += new umfrage2._2008.Tools.ChangeOrderEventHandler(OutputListView_OrderChanged);
            ReportList.OrderChanged += new umfrage2._2008.Tools.ChangeOrderEventHandler(ReportList_OrderChanged);
        }

        void ReportList_OrderChanged(umfrage2._2008.Tools.ListViewEx source)
        {
            if (eval != null && ReportList.Items.Count == eval.Reports.Length)
            {
                Report[] nos = new Report[ReportList.Items.Count];

                int i = 0;
                foreach (ListViewItem lwi in ReportList.Items)
                {
                    nos[i++] = (Report)lwi.Tag;
                }

                bool allfound = true;

                foreach (Report no in nos)
                {
                    bool found = false;

                    foreach (Report o in eval.Reports)
                        if (o == no) found = true;

                    if (!found) allfound = false;
                }

                if (allfound)
                {
                    eval.Reports = nos;
                }
            }
        }

        void OutputListView_OrderChanged(umfrage2._2008.Tools.ListViewEx source)
        {
            Report r = (Report)ReportList.SelectedItem;

            if (r != null && OutputListView.Items.Count == r.Outputs.Length)
            {
                Output[] nos = new Output[OutputListView.Items.Count];

                int i = 0;
                foreach (ListViewItem lwi in OutputListView.Items)
                {
                    nos[i++] = (Output)lwi.Tag;
                }

                bool allfound = true;

                foreach (Output no in nos)
                {
                    bool found = false;

                    foreach (Output o in r.Outputs)
                        if (o == no) found = true;

                    if (!found) allfound = false;
                }

                if (allfound)
                {
                    r.Outputs = nos;
                }
            }
        }

        private void ReportControl_SizeChanged(object sender, EventArgs e)
        {

        }

        private void UpdateReportData()
        {
            if (eval.Reports == null)
                eval.Reports = new Report[0];

            ReportList.Items.Clear();
            foreach (Report r in eval.Reports)
                ReportList.AddObject(r);//ReportList.Items.Add(r);


            UpdateOutputData();
        }

        private void UpdateOutputData()
        {
            /*
            int sel = OutputList.SelectedIndex;
            OutputList.Items.Clear();
            if (ReportList.SelectedItem != null)
            {
                foreach (Output o in ((Report)ReportList.SelectedItem).Outputs)
                {
                    OutputList.Items.Add(o);
                }
            }
            OutputList.SelectedIndex = sel;
            */


            int vs = -1;
            if (OutputListView.SelectedIndices.Count > 0)
                vs = OutputListView.SelectedIndices[0];

            OutputListView.Items.Clear();
            OutputListView.SelectedIndices.Clear();

            if (ReportList.SelectedItem != null)
            {
                foreach (Output o in ((Report)ReportList.SelectedItem).Outputs)
                {
                    ListViewItem lwi = new ListViewItem();
                    lwi.Tag = o;
                    lwi.Text = o.Name;
                    if (o.GetType().Equals(typeof(Pie))) lwi.ImageIndex = 0;
                    if (o.GetType().Equals(typeof(CrossAverages))) lwi.ImageIndex = 1;
                    if (o.GetType().Equals(typeof(Ranking))) lwi.ImageIndex = 2;
                    if (o.GetType().Equals(typeof(Averages))) lwi.ImageIndex = 3;
                    if (o.GetType().Equals(typeof(Open))) lwi.ImageIndex = 4;
                    if (o.GetType().Equals(typeof(SingleMatrix))) lwi.ImageIndex = 5;
                    if (o.GetType().Equals(typeof(MultiMatrix))) lwi.ImageIndex = 6;
                    if (o.GetType().Equals(typeof(Bar))) lwi.ImageIndex = 7;
                    if (o.GetType().Equals(typeof(Polarity))) lwi.ImageIndex = 8;
                    if (o.GetType().Equals(typeof(Polarity2008))) lwi.ImageIndex = 8;
                    if (o.GetType().Equals(typeof(Gap))) lwi.ImageIndex = 9;
                    if (o.GetType().Equals(typeof(Barometer))) lwi.ImageIndex = 10;
                    if (o.GetType().Equals(typeof(Radar))) lwi.ImageIndex = 11;
                    if (o.GetType().Equals(typeof(MultiGap))) lwi.ImageIndex = 12;
                    if (o.GetType().Equals(typeof(Potential))) lwi.ImageIndex = 13;
                    if (o.GetType().Equals(typeof(Tacho))) lwi.ImageIndex = 14;
                    if (o.GetType().Equals(typeof(Gauge_h056))) lwi.ImageIndex = 7;
                    if (o.GetType().Equals(typeof(Radar2))) lwi.ImageIndex =11;
                    if (o.GetType().Equals(typeof(Bar_Segment))) lwi.ImageIndex = 7;

                    OutputListView.Items.Add(lwi);
                }
            }
            
            try
            {
                if (vs != -1) OutputListView.SelectedIndices.Add(vs);
            }
            catch { }

        }

        private void UpdateControls()
        {
            UpdateControls(true);
        }

        private void UpdateControls(bool outputdata)
        {
            bool val;
            if (ReportList.SelectedItem == null)
            {
                //disable all
                val = false;
                OutputList.Items.Clear();
            }
            else
            {
                //enable all
                val = true;
                //clear outputlist
                if (outputdata)
                    UpdateOutputData();
            }

            DeleteReportButton.Enabled = val;
            StartReportButton.Enabled = val;
            OutputListView.Enabled = val;

            SetEnabled(val);
           

            Refresh();
        }

        private void SetEnabled(bool val)
        {
            try
            {
                if (GetIndex() == -1)
                {
                    //disable all
                    val = false;
                }
                else
                {
                    //enable all
                    val = true;
                }
            }
            catch
            {
                val = true;
            }

            EditOutputButton.Enabled = val;
            DeleteOutputButton.Enabled = val;


            AddOutputButton.Enabled = OutputListView.Enabled;
        }

        private void eval_ReportDataChanged(object source)
        {
            UpdateReportData();
            UpdateControls();
        }

        private void eval_OutputDataChanged(object source)
        {
            UpdateOutputData();
        }

        private void NewReportButton_Click(object sender, EventArgs e)
        {
            Report n = new Report("Neuer Bericht");
            DialogReport dr = new DialogReport(n);

            if (dr.ShowDialog() == DialogResult.OK)
                eval.AddReport(n);
        }

        private void RenameReport_Click(object sender, EventArgs e)
        {
            ReportList_DoubleClick(sender, e);
        }

        private void CloneReportButton_Click(object sender, EventArgs e)
        {
            if (ReportList.SelectedItem != null)
            {
                Report n = ((Report)ReportList.SelectedItem).Clone;
                DialogReport dr = new DialogReport(n);

                if (dr.ShowDialog() == DialogResult.OK)
                    eval.AddReport(n);
            }
        }

        private void DeleteReportButton_Click(object sender, EventArgs e)
        {
            if (ReportList.SelectedItem != null)
                eval.RemoveReport((Report)ReportList.SelectedItem);
        }

        private void StartReportButton_Click(object sender, EventArgs e)
        {
            if (ReportList.SelectedItem != null)
            {
                Report r = (Report)ReportList.SelectedItem;

                SaveReportDialog srd = new SaveReportDialog(eval, r);
                srd.ShowDialog();
            }
        }

        private void ReportList_DoubleClick(object sender, EventArgs e)
        {
            if (ReportList.SelectedItem != null)
            {
                Report r = (Report)ReportList.SelectedItem;

                DialogReport dr = new DialogReport(r);
                dr.ShowDialog();

                UpdateReportData();

                ReportList.SelectedItem = r;

                UpdateControls();
            }
        }

        private void AddOutputButton_Click(object sender, EventArgs e)
        {
            //AddMenu.Show(panel6, new Point(10, 10));
            AddMenuStrip.Show(panel6, new Point(10, 10));
        }

        private void EditOutputButton_Click(object sender, EventArgs e)
        {
            EditOutput();
        }

        private void DeleteOutputButton_Click(object sender, EventArgs e)
        {
            if (ReportList.SelectedItem != null)
            {
                Report r = (Report)ReportList.SelectedItem;
                
                /*if (OutputList.SelectedIndex != -1)
                    r.RemoveOutput((Output)OutputList.Items[OutputList.SelectedIndex]);
                 * */
                if (GetIndex() != -1) r.RemoveOutput((Output)(OutputListView.Items[GetIndex()]).Tag);
            }

            UpdateOutputData();
        }

        private void OutputList_DoubleClick(object sender, EventArgs e)
        {
//            EditOutput();
        }

        private int GetIndex()
        {
            int vs = -1;
            if (OutputListView.SelectedIndices.Count > 0)
                vs = OutputListView.SelectedIndices[0];

            return vs;
        }

        private void SetIndex(int vs)
        {
            OutputListView.SelectedIndices.Clear();
            if (vs != -1) OutputListView.SelectedIndices.Add(vs);
        }

        private Output GetSelectedOutput()
        {
            if (GetIndex() != -1)
            {
                //Output p = ((Output)OutputList.Items[OutputList.SelectedIndex]);//.SelectedItem);
                return (Output)(OutputListView.Items[GetIndex()]).Tag;//.SelectedItem);
            }

            return null;
        }

        private void EditOutput()
        {
            Output p = GetSelectedOutput();
            if (p != null)
            {
                LoadOutput(p);              
            }
        }

        private void LoadOutput(Output p)
        {
            EditPanel.Controls.Clear();
            Control c = p.EditControl();
            c.Dock = DockStyle.Fill;
            EditPanel.Controls.Add(c);

            TitlePanel.Controls.Clear();

            //select

            OutputNameControl onc = new OutputNameControl(p, OutputListView.Items[GetIndex()]);
            onc.Location = new Point(1, TitlePanel.Height / 2 - onc.Height / 2);
            onc.Dock = DockStyle.Fill;
            TitlePanel.Controls.Add(onc);

            //UpdateOutputData();
        }

        private void ReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
            UpdateOutputData();
        }

        private void ReportList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // change the drag cursor to show valid data ready

            e.Effect = DragDropEffects.Move;
        }

        private void ReportList_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            /*
            Point p = ReportList.PointToClient(new Point(e.X, e.Y));

            int indexOfItem = ReportList.IndexFromPoint(p.X, p.Y);

            ReportList.SelectedIndex = indexOfItem;
             */
        }

        private Report OldDrag = null;
        private Output DragOut = null;

        private void ReportList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            /*
            Console.WriteLine("dragdrop!");
            Point p = ReportList.PointToClient(new Point(e.X, e.Y));

            int indexOfItem = ReportList.IndexFromPoint(p.X, p.Y);

            Output o = DragOut;//(Output)e.Data.GetData(typeof(Output));
            Report r = (Report)ReportList.Items[indexOfItem];

            Console.WriteLine("ioi=" + indexOfItem);
            Console.WriteLine("OldDrag=" + OldDrag);
            Console.WriteLine("r=" + r);
            Console.WriteLine("o=" + o);

            if (indexOfItem != -1 && OldDrag != null && r != null && o != null)
            {
                OldDrag.RemoveOutput(o);
                r.AddOutput(o);
            }
            else
            {
                Console.WriteLine("queries failed");
            }

            this.UpdateControls(true);
            //DragOut = null;
            //OldDrag = null;
             */
        }

        private void AddOutput(Output o)
        {
            Report report;
            try
            {
                report = (Report)ReportList.SelectedItem;
            }
            catch
            {
                return;
            }

            //SingleMatrix sm = new SingleMatrix(eval);
            //sm.Name = "single matrix";

            report.AddOutput(o);

            UpdateOutputData();
        }

        private bool updating = false;

        private void OutputList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                updating = true;
                UpdateControls(false);
                updating = false;
            }

            EditOutput();
            

           
            //UpdateControls(false);

            SetEnabled(false);
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            SingleMatrix o = new SingleMatrix(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            MultiMatrix o = new MultiMatrix(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Pie o = new Pie(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Bar o = new Bar(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            Polarity o = new Polarity(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            Gaps o = new Gaps(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            Averages o = new Averages(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            CrossAverages o = new CrossAverages(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            Ranking o = new Ranking(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            Open o = new Open(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            Barometer o = new Barometer(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void radarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Radar o = new Radar(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void potentialanalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Potential o = new Potential(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void mehrfachgapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiGap o = new MultiGap(eval);
            AddOutput(o);
            //LoadOutput(o);
        }

        private void radarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tacho o = new Tacho(eval);
            AddOutput(o);
        }

        private void CloneOutputButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedOutput().GetType() == typeof(Bar))//1
            {
                //MessageBox.Show("Bar Cloned");
                Bar bar = new Bar(eval);
                Bar tmp = (Bar)GetSelectedOutput();

                bar.ComboList = GetSelectedOutput().ComboList;
                bar.PersonList = GetSelectedOutput().PersonList;
                bar.Name = "Kopie von " + GetSelectedOutput().Name;
                bar.Cross = GetSelectedOutput().Cross;
                bar.height = GetSelectedOutput().height;
                bar.width = GetSelectedOutput().width;
                bar.Questions = tmp.GetQuestionList();

                bar.SetText(tmp.GetText());
                bar.SetShowText(tmp.GetShowText());
                bar.SetMinVal(tmp.GetMinVal());
                bar.SetMaxVal(tmp.GetMaxVal());
                bar.SetSteps(tmp.GetSteps());
                bar.SetGridOffXRight(tmp.GetGridOffXRight());
                bar.SetGridOffYBottom(tmp.GetGridOffYBottom());
                bar.SetGridOffYTop(tmp.GetGridOffYTop());
                bar.SetBarOffSet(tmp.GetBarOffSet());
                bar.SetBarHeight(tmp.GetBarHeight());
                bar.SetInvert(tmp.GetInvert());
                bar.SetQuestionList(tmp.GetQuestionList());
                bar.SetPercent(tmp.GetPercent());
                bar.SetHorizontal(tmp.GetHorizontal());
                bar.SetOpposites(tmp.GetOpposites());
                bar.SetTxt(tmp.GetTxt());
                bar.SetBackColor(tmp.GetBackColor());
                bar.SetDesign(tmp.GetDesign());

                //bar.SetHideAnswers(tmp.GetHideAnswers());
                bar.SetAnswerOrder(tmp.GetAnswerOrder());

                bar.SetSort(tmp.GetSort());
                bar.SetType(tmp.GetType());
                bar.SetPersonGroups(tmp.GetPersonGroups());
                bar.SetBase(tmp.GetBase());
                bar.SetBaseQ(tmp.GetBaseQ());
                bar.SetAbsolutes(tmp.GetAbsolutes());
                bar.SetUseManualWidth(tmp.GetUseManualWidth());
                bar.SetManualWidth(tmp.GetManualWidth());
                bar.SetDNC(tmp.GetDNC());
                AddOutput(bar);
            }
            else
            {
                Output o = GetSelectedOutput().Clone;
                o.Name = "Kopie von " + GetSelectedOutput().Name;
                AddOutput(o);
            }
        }

        private void Clone()
        {
            if (GetSelectedOutput().GetType() == typeof(Star))//2
            {
                //MessageBox.Show("Star Cloned");
                Star star = new Star(eval);
                Star tmp = (Star)GetSelectedOutput();

                star.ComboList = GetSelectedOutput().ComboList;
                star.PersonList = GetSelectedOutput().PersonList;
                star.Name = "Kopie von " + GetSelectedOutput().Name;
                star.Cross = GetSelectedOutput().Cross;
                star.height = GetSelectedOutput().height;
                star.width = GetSelectedOutput().width;
                //fill in

                AddOutput(star);
            }
            else if (GetSelectedOutput().GetType() == typeof(SplitMatrix))//3
            {
                //MessageBox.Show("SplitMatrix Cloned");
                SplitMatrix splitmatix = new SplitMatrix(eval);
                SplitMatrix tmp = (SplitMatrix)GetSelectedOutput();

                splitmatix.ComboList = GetSelectedOutput().ComboList;
                splitmatix.PersonList = GetSelectedOutput().PersonList;
                splitmatix.Name = "Kopie von " + GetSelectedOutput().Name;
                splitmatix.Cross = GetSelectedOutput().Cross;
                splitmatix.height = GetSelectedOutput().height;
                splitmatix.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(SocioMatrix))//4
            {
                //MessageBox.Show("SocioMatrix Cloned");
                SocioMatrix sociomatrix = new SocioMatrix(eval);
                SocioMatrix tmp = (SocioMatrix)GetSelectedOutput();

                sociomatrix.ComboList = GetSelectedOutput().ComboList;
                sociomatrix.PersonList = GetSelectedOutput().PersonList;
                sociomatrix.Name = "Kopie von " + GetSelectedOutput().Name;
                sociomatrix.Cross = GetSelectedOutput().Cross;
                sociomatrix.height = GetSelectedOutput().height;
                sociomatrix.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Polarity2008))//5
            {
                //MessageBox.Show("Polarity2008 Cloned");
                Polarity2008 polarity2008 = new Polarity2008(eval);
                Polarity2008 tmp = (Polarity2008)GetSelectedOutput();

                polarity2008.ComboList = GetSelectedOutput().ComboList;
                polarity2008.PersonList = GetSelectedOutput().PersonList;
                polarity2008.Name = "Kopie von " + GetSelectedOutput().Name;
                polarity2008.Cross = GetSelectedOutput().Cross;
                polarity2008.height = GetSelectedOutput().height;
                polarity2008.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(HistoricChangeDiagram))//6
            {
                //MessageBox.Show("HistoricChangeDiagram Cloned");
                HistoricChangeDiagram historicChangeDiagram = new HistoricChangeDiagram(eval);
                HistoricChangeDiagram tmp = (HistoricChangeDiagram)GetSelectedOutput();

                historicChangeDiagram.ComboList = GetSelectedOutput().ComboList;
                historicChangeDiagram.PersonList = GetSelectedOutput().PersonList;
                historicChangeDiagram.Name = "Kopie von " + GetSelectedOutput().Name;
                historicChangeDiagram.Cross = GetSelectedOutput().Cross;
                historicChangeDiagram.height = GetSelectedOutput().height;
                historicChangeDiagram.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Tacho))//7
            {
                //MessageBox.Show("Tacho Cloned");
                Tacho tacho = new Tacho(eval);
                Tacho tmp = (Tacho)GetSelectedOutput();

                tacho.ComboList = GetSelectedOutput().ComboList;
                tacho.PersonList = GetSelectedOutput().PersonList;
                tacho.Name = "Kopie von " + GetSelectedOutput().Name;
                tacho.Cross = GetSelectedOutput().Cross;
                tacho.height = GetSelectedOutput().height;
                tacho.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(SingleMatrix))//8
            {
                //MessageBox.Show("SingleMatrix Cloned");
                SingleMatrix singleMatrix = new SingleMatrix(eval);
                SingleMatrix tmp = (SingleMatrix)GetSelectedOutput();

                singleMatrix.ComboList = GetSelectedOutput().ComboList;
                singleMatrix.PersonList = GetSelectedOutput().PersonList;
                singleMatrix.Name = "Kopie von " + GetSelectedOutput().Name;
                singleMatrix.Cross = GetSelectedOutput().Cross;
                singleMatrix.height = GetSelectedOutput().height;
                singleMatrix.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(MultiMatrix))//9
            {
                //MessageBox.Show("MultiMatrix Cloned");
                MultiMatrix multiMatrix = new MultiMatrix(eval);
                MultiMatrix tmp = (MultiMatrix)GetSelectedOutput();

                multiMatrix.ComboList = GetSelectedOutput().ComboList;
                multiMatrix.PersonList = GetSelectedOutput().PersonList;
                multiMatrix.Name = "Kopie von " + GetSelectedOutput().Name;
                multiMatrix.Cross = GetSelectedOutput().Cross;
                multiMatrix.height = GetSelectedOutput().height;
                multiMatrix.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Pie))//10
            {
                //MessageBox.Show("Pie Cloned");
                Pie pie = new Pie(eval);
                Pie tmp = (Pie)GetSelectedOutput();

                pie.ComboList = GetSelectedOutput().ComboList;
                pie.PersonList = GetSelectedOutput().PersonList;
                pie.Name = "Kopie von " + GetSelectedOutput().Name;
                pie.Cross = GetSelectedOutput().Cross;
                pie.height = GetSelectedOutput().height;
                pie.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Polarity))//11
            {
                //MessageBox.Show("Polarity Cloned");
                Polarity polarity = new Polarity(eval);
                Polarity tmp = (Polarity)GetSelectedOutput();

                polarity.ComboList = GetSelectedOutput().ComboList;
                polarity.PersonList = GetSelectedOutput().PersonList;
                polarity.Name = "Kopie von " + GetSelectedOutput().Name;
                polarity.Cross = GetSelectedOutput().Cross;
                polarity.height = GetSelectedOutput().height;
                polarity.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Gaps))//12
            {
                //MessageBox.Show("Gaps Cloned");
                Gaps gaps = new Gaps(eval);
                Gaps tmp = (Gaps)GetSelectedOutput();

                gaps.ComboList = GetSelectedOutput().ComboList;
                gaps.PersonList = GetSelectedOutput().PersonList;
                gaps.Name = "Kopie von " + GetSelectedOutput().Name;
                gaps.Cross = GetSelectedOutput().Cross;
                gaps.height = GetSelectedOutput().height;
                gaps.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Averages))//13
            {
                //MessageBox.Show("Averages Cloned");
                Averages averages = new Averages(eval);
                Averages tmp = (Averages)GetSelectedOutput();

                averages.ComboList = GetSelectedOutput().ComboList;
                averages.PersonList = GetSelectedOutput().PersonList;
                averages.Name = "Kopie von " + GetSelectedOutput().Name;
                averages.Cross = GetSelectedOutput().Cross;
                averages.height = GetSelectedOutput().height;
                averages.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(CrossAverages))//14
            {
                //MessageBox.Show("CrossAverages Cloned");
                CrossAverages crossAverages = new CrossAverages(eval);
                CrossAverages tmp = (CrossAverages)GetSelectedOutput();

                crossAverages.ComboList = GetSelectedOutput().ComboList;
                crossAverages.PersonList = GetSelectedOutput().PersonList;
                crossAverages.Name = "Kopie von " + GetSelectedOutput().Name;
                crossAverages.Cross = GetSelectedOutput().Cross;
                crossAverages.height = GetSelectedOutput().height;
                crossAverages.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Ranking))//15
            {
                //MessageBox.Show("Ranking Cloned");
                Ranking ranking = new Ranking(eval);
                Ranking tmp = (Ranking)GetSelectedOutput();

                ranking.ComboList = GetSelectedOutput().ComboList;
                ranking.PersonList = GetSelectedOutput().PersonList;
                ranking.Name = "Kopie von " + GetSelectedOutput().Name;
                ranking.Cross = GetSelectedOutput().Cross;
                ranking.height = GetSelectedOutput().height;
                ranking.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Open))//16
            {
                //MessageBox.Show("Open Cloned");
                Open open = new Open(eval);
                Open tmp = (Open)GetSelectedOutput();

                open.ComboList = GetSelectedOutput().ComboList;
                open.PersonList = GetSelectedOutput().PersonList;
                open.Name = "Kopie von " + GetSelectedOutput().Name;
                open.Cross = GetSelectedOutput().Cross;
                open.height = GetSelectedOutput().height;
                open.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Barometer))//17
            {
                //MessageBox.Show("Barometer Cloned");
                Barometer barometer = new Barometer(eval);
                Barometer tmp = (Barometer)GetSelectedOutput();

                barometer.ComboList = GetSelectedOutput().ComboList;
                barometer.PersonList = GetSelectedOutput().PersonList;
                barometer.Name = "Kopie von " + GetSelectedOutput().Name;
                barometer.Cross = GetSelectedOutput().Cross;
                barometer.height = GetSelectedOutput().height;
                barometer.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Radar))//18
            {
                //MessageBox.Show("Radar Cloned");
                Radar radar = new Radar(eval);
                Radar tmp = (Radar)GetSelectedOutput();

                radar.ComboList = GetSelectedOutput().ComboList;
                radar.PersonList = GetSelectedOutput().PersonList;
                radar.Name = "Kopie von " + GetSelectedOutput().Name;
                radar.Cross = GetSelectedOutput().Cross;
                radar.height = GetSelectedOutput().height;
                radar.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Potential))//19
            {
                //MessageBox.Show("Potential Cloned");
                Potential potential = new Potential(eval);
                Potential tmp = (Potential)GetSelectedOutput();

                potential.ComboList = GetSelectedOutput().ComboList;
                potential.PersonList = GetSelectedOutput().PersonList;
                potential.Name = "Kopie von " + GetSelectedOutput().Name;
                potential.Cross = GetSelectedOutput().Cross;
                potential.height = GetSelectedOutput().height;
                potential.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(MultiGap))//20
            {
                //MessageBox.Show("MultiGap Cloned");
                MultiGap multiGap = new MultiGap(eval);
                MultiGap tmp = (MultiGap)GetSelectedOutput();

                multiGap.ComboList = GetSelectedOutput().ComboList;
                multiGap.PersonList = GetSelectedOutput().PersonList;
                multiGap.Name = "Kopie von " + GetSelectedOutput().Name;
                multiGap.Cross = GetSelectedOutput().Cross;
                multiGap.height = GetSelectedOutput().height;
                multiGap.width = GetSelectedOutput().width;
            }
            else if (GetSelectedOutput().GetType() == typeof(Radar2))//21
            {
                //MessageBox.Show("Radar Cloned");
                Radar2 radar = new Radar2(eval);
                Radar2 tmp = (Radar2)GetSelectedOutput();

                radar.ComboList = GetSelectedOutput().ComboList;
                radar.PersonList = GetSelectedOutput().PersonList;
                radar.Name = "Kopie von " + GetSelectedOutput().Name;
                radar.Cross = GetSelectedOutput().Cross;
                radar.height = GetSelectedOutput().height;
                radar.width = GetSelectedOutput().width;
            } 
            else if (GetSelectedOutput().GetType() == typeof(Gauge_h056))//1
            {
                /*Gauge_h056 gauge_h056 = new Gauge_h056(eval);
                Gauge_h056 tmp = (Gauge_h056)GetSelectedOutput();

                gauge_h056.ComboList = GetSelectedOutput().ComboList;
                gauge_h056.PersonList = GetSelectedOutput().PersonList;
                gauge_h056.Name = "Kopie von " + GetSelectedOutput().Name;
                gauge_h056.Cross = GetSelectedOutput().Cross;
                gauge_h056.height = GetSelectedOutput().height;
                gauge_h056.width = GetSelectedOutput().width;
                gauge_h056.Questions = tmp.GetQuestionList();

                AddOutput(gauge_h056);*/
                MessageBox.Show("klont");
            }
            else if (GetSelectedOutput().GetType() == typeof(Bar_Segment))//1
            {
                Bar_Segment barSegment = new Bar_Segment(eval);
                Bar_Segment tmp = (Bar_Segment)GetSelectedOutput();

                barSegment.Name = "Kopie von " + GetSelectedOutput().Name;
                barSegment.SetShowPerson(tmp.GetShowText());
                barSegment.SetShowValue(tmp.GetShowValue());
                barSegment.SetShowText(tmp.GetShowText());

                barSegment.SetTxt(tmp.GetTxt());

                barSegment.SetBackColor(tmp.GetBackColor());
                barSegment.SetBrushColor(tmp.GetBrushColor());

                barSegment.ComboList = GetSelectedOutput().ComboList;
                barSegment.PersonList = GetSelectedOutput().PersonList;
                barSegment.Cross = GetSelectedOutput().Cross;
                barSegment.height = GetSelectedOutput().height;
                barSegment.width = GetSelectedOutput().width;
                barSegment.Questions = tmp.GetQuestionList();


                barSegment.SetQuestionList(tmp.GetQuestionList());


                barSegment.SetAnswerOrder(tmp.GetAnswerOrder());

                barSegment.SetSort(tmp.GetSort());
                barSegment.SetPersonGroups(tmp.GetPersonGroups());


                AddOutput(barSegment);
            }
        }

        private void polarity08menu_Click(object sender, EventArgs e)
        {
            Polarity2008 o = new Polarity2008(eval);
            AddOutput(o);
        }

        private void sternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Star o = new Star(eval);
            AddOutput(o);
        }

        private void filialmatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SplitMatrix s = new SplitMatrix(eval);
            AddOutput(s);
        }

        private void socioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocioMatrix s = new SocioMatrix(eval);
            AddOutput(s);
        }

        private void historicChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoricChangeDiagram s = new HistoricChangeDiagram(eval);
            AddOutput(s);
        }

        private void gaugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gauge_h056 s = new Gauge_h056(eval);
            AddOutput(s);
        }

        private void Radar2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Radar2 o = new Radar2(eval);
            AddOutput(o);
        }

        private void balkenSegmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bar_Segment o = new Bar_Segment(eval);
            AddOutput(o);
        }
    }
}
