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

namespace umfrage2._2007.Controls
{
    public partial class ScoringControl : UserControl
    {
        private Evaluation eval;
        private ChooseTargetControl TargetSelector;

        public ScoringControl(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            TargetSelector = new ChooseTargetControl(eval);
            TargetSelector.Dock = DockStyle.Fill;

            targetBox.Controls.Add(TargetSelector);

            foreach (Column c in eval.Columns)
                ColumnBox.Items.Add(c);
        }

        private void ColumnBox_DoubleClick(object sender, System.EventArgs e)
        {
            if (ColumnBox.SelectedItem != null)
            {
                DialogColumn dc = new DialogColumn(eval, (Column)ColumnBox.SelectedItem);
                dc.ShowDialog();
                UpdateData();
            }
        }

        private void UpdateData()
        {
            ColumnBox.Items.Clear();

            foreach (Column c in eval.Columns)
                ColumnBox.Items.Add(c);
        }

        private void NewColumnButton_Click(object sender, System.EventArgs e)
        {
            Column nc = new Column();
            eval.AddColumn(nc);
            ColumnBox.Items.Add(nc);

            DialogColumn dc = new DialogColumn(eval, nc);
            dc.ShowDialog();
            UpdateData();
        }

        private void DeleteColumnButton_Click(object sender, System.EventArgs e)
        {
            if (ColumnBox.SelectedItem != null)
            {
                eval.RemoveColumn((Column)ColumnBox.SelectedItem);
                ColumnBox.Items.Remove(ColumnBox.SelectedItem);
            }
        }

        private void EditColumnButton_Click(object sender, System.EventArgs e)
        {
            if (ColumnBox.SelectedItem != null)
            {
                DialogColumn dc = new DialogColumn(eval, (Column)ColumnBox.SelectedItem);
                dc.ShowDialog();
                UpdateData();
            }
        }

        private void ScoreButton_Click(object sender, System.EventArgs e)
        {
            Scoring sc = new Scoring(eval, Cockpits.Checked, Cockpits06.Checked, Cockpits07.Checked);
            SaveDialog sd = new SaveDialog(sc);
            sd.ShowDialog();
        }

        private void Cockpits06_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Cockpits_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
