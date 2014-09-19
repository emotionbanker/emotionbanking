using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using umfrage2;

namespace UMXAddin3
{
    public partial class OutputSelect : Form
    {
        private Evaluation eval;

        public Output output;
        public Report report;

        public OutputSelect(Evaluation eval)
        {
            InitializeComponent();

            this.eval = eval;

            UpdateReportData();
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

                    OutputListView.Items.Add(lwi);
                }
            }

            try
            {
                if (vs != -1) OutputListView.SelectedIndices.Add(vs);
            }
            catch { }

        }

        private void ReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
            UpdateOutputData();
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

        private void UpdateControls()
        {
            UpdateControls(true);
        }

        private void UpdateControls(bool outputdata)
        {
            //bool val;
            if (ReportList.SelectedItem == null)
            {
                //disable all
                //val = false;
            }
            else
            {
                //enable all
                //val = true;
                //clear outputlist
                if (outputdata)
                    UpdateOutputData();
            }

            Refresh();
        }

        private void OSel_Click(object sender, EventArgs e)
        {
            report = (Report)ReportList.SelectedItem;
            output = GetSelectedOutput();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}