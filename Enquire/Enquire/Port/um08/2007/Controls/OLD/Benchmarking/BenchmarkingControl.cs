using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using umfrage2;

namespace umfrage2._2007.Controls
{
    public partial class BenchmarkingControl : UserControl
    {
        private Evaluation eval;

        private Benchmarking bench;

        private ChooseTargetControl TargetSelector;
        private ChoosePersonControl cpp;


        public BenchmarkingControl(Evaluation eval)
        {
            InitializeComponent();

            this.eval = eval;

            bench = new Benchmarking(eval);

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);

            TargetSelector = new ChooseTargetControl(eval);
            TargetSelector.Dock = DockStyle.Fill;

            targetBox.Controls.Add(TargetSelector);

            cpp = new ChoosePersonControl(eval);
            cpp.Dock = DockStyle.Fill;

            personBox.Controls.Add(cpp);
        }

        private void AllQuestionsBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (AllQuestionsBox.Checked)
            {
                QBox.Enabled = QAdd.Enabled = QRemove.Enabled = false;
            }
            else
            {
                QBox.Enabled = QAdd.Enabled = QRemove.Enabled = true;
            }
        }
    }
}
