using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Historic : UserControl
    {
        private Evaluation eval;

        public SettingsControl_Historic(Evaluation eval)
        {
            this.eval = eval;    

            InitializeComponent();

            UpdateControls();
        }

        private void UpdateControls()
        {
            HistoryList.Items.Clear();

            foreach (HistoricData hd in eval.History)
            {
                HistoryList.Items.Add(hd);
            }
        }

        private void HistoryList_DoubleClick(object sender, System.EventArgs e)
        {
            if (HistoryList.SelectedItem != null)
            {
                DialogHistoricData dhd = new DialogHistoricData((HistoricData)HistoryList.SelectedItem);
                if (dhd.ShowDialog() == DialogResult.OK)
                {
                    HistoryList.Items.Remove(HistoryList.SelectedItem);
                    eval.RemoveHistoricData((HistoricData)HistoryList.SelectedItem);
                    HistoricData hd = dhd.Historic;
                    eval.AddHistoricData(hd);
                    HistoryList.Items.Add(hd);
                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            DialogHistoricData dhd = new DialogHistoricData();
            if (dhd.ShowDialog() == DialogResult.OK)
            {
                HistoricData hd = dhd.Historic;
                eval.AddHistoricData(hd);
                HistoryList.Items.Add(hd);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (HistoryList.SelectedItem != null)
            {
                HistoryList.Items.Remove(HistoryList.SelectedItem);
                eval.RemoveHistoricData((HistoricData)HistoryList.SelectedItem);
            }

            HistoryList.Items.Clear();

            foreach (HistoricData hd in eval.History)
            {
                HistoryList.Items.Add(hd);
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (HistoryList.SelectedItem != null)
            {
                DialogHistoricData dhd = new DialogHistoricData((HistoricData)HistoryList.SelectedItem);
                dhd.ShowDialog();
            }
        }
    }
}
