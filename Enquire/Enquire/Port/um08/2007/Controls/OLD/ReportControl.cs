using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

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
                ReportList.Items.Add(r);

            UpdateOutputData();
        }

        private void UpdateOutputData()
        {
            OutputList.Items.Clear();
            if (ReportList.SelectedItem != null)
            {
                foreach (Output o in ((Report)ReportList.SelectedItem).Outputs)
                {
                    OutputList.Items.Add(o);
                }
            }
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
            OutputList.Enabled = val;

            try
            {
                if (OutputList.SelectedItem == null)
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


            AddOutputButton.Enabled = OutputList.Enabled;

            Refresh();
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
            AddMenu.Show(panel6, new Point(10, 10));
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
                Console.WriteLine(r);
                Console.WriteLine("si=" + OutputList.SelectedIndex);
                if (OutputList.SelectedIndex != -1)
                    r.RemoveOutput((Output)OutputList.Items[OutputList.SelectedIndex]);
            }

            UpdateOutputData();
        }

        private void OutputList_DoubleClick(object sender, EventArgs e)
        {
            EditOutput();
        }

        private void EditOutput()
        {
            if (OutputList.SelectedIndex != -1)
            {
                Output p = ((Output)OutputList.Items[OutputList.SelectedIndex]);//.SelectedItem);

                //TODO: Control anzeigen!
                //TODO: EditOutput() auch bei einfacher Auswahl i. d. Liste

                p.EditDialog();

                UpdateOutputData();
                
            }
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
            Point p = ReportList.PointToClient(new Point(e.X, e.Y));

            int indexOfItem = ReportList.IndexFromPoint(p.X, p.Y);

            ReportList.SelectedIndex = indexOfItem;
        }

        private Report OldDrag = null;
        private Output DragOut = null;

        private void ReportList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
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
        }

        private void OutputList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls(false);
        }
    }
}
