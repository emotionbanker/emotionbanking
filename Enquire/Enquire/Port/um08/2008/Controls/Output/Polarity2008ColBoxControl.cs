using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.Polarity2008;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2
{
    public delegate void SelfDestructDelegate();
    public delegate void ControlChangeDelegate();

    public partial class Polarity2008ColBoxControl : UserControl
    {
        public PolarityUGSplit ug;
        public Polarity2008 pol;
        public Evaluation eval;

        public event SelfDestructDelegate SelfDestruct;
        public event ControlChangeDelegate Changed;

        public Polarity2008ColBoxControl(Polarity2008 pol, PolarityUGSplit ug, Evaluation eval)
        {
            InitializeComponent();

            this.ug = ug;
            this.pol = pol;
            this.eval = eval;

            SelfDestruct += new SelfDestructDelegate(Polarity2008ColBoxControl_SelfDestruct);
            Changed += new ControlChangeDelegate(Polarity2008ColBoxControl_Changed);

            ReSet();
        }

        void Polarity2008ColBoxControl_Changed()
        {
            //do nothing
        }

        void Polarity2008ColBoxControl_SelfDestruct()
        {
            //do nothing
        }

        public void ReSet()
        {
            if (!ug.Name.Equals(string.Empty)) SetButton.Text = ug.Name;
            Changed();
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            UGSplitDialog sd = new UGSplitDialog(ug, eval);
            sd.ShowDialog();

            ReSet();
        }

        private void XButton_Click(object sender, EventArgs e)
        {
            pol.Cols.Remove(ug);
            SelfDestruct();
        }
    }
}
