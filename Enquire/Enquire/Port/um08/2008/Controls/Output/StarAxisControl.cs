using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.Star;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2008
{
    public partial class StarAxisControl : UserControl
    {
        public delegate void SelfDestructDelegate();
        public delegate void ControlChangeDelegate();

        private Star star;
        private Evaluation eval;
        private StarElement el;

        public event SelfDestructDelegate SelfDestruct;
        public event ControlChangeDelegate Changed;

        public StarAxisControl(Star star, Evaluation eval, StarElement el)
        {
            this.star = star;
            this.eval = eval;
            this.el = el;

            InitializeComponent();

            SelfDestruct += new SelfDestructDelegate(StarAxisControl_SelfDestruct);
            Changed += new ControlChangeDelegate(StarAxisControl_Changed);

            if (el.q != null) SetButton.Text = el.q.SID;
            ColButton.BackColor = el.ElementColor;

            AxisSelector.Value = el.Axis;

            foreach (PersonSetting ps in eval.CombinedPersons)
                UGSelectBox.Items.Add(ps);

            UGSelectBox.SelectedItem = el.p;
        }


        void StarAxisControl_Changed()
        {

        }

        void StarAxisControl_SelfDestruct()
        {

        }

        private void XButton_Click(object sender, EventArgs e)
        {
            star.Elements.Remove(el);
            SelfDestruct();
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                el.q = qs.SelectedQuestion;
                SetButton.Text = el.q.SID;
                Changed();
            }
        }

        private void ColButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = el.ElementColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                el.ElementColor = cd.Color;
                ColButton.BackColor = cd.Color;
                Changed();
            }
        }

        private void AxisSelector_ValueChanged(object sender, EventArgs e)
        {
            el.Axis = (int)AxisSelector.Value;
            Changed();
        }

        private void UGSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            el.p = (PersonSetting)UGSelectBox.SelectedItem;
            Changed();
        }

        private void AxisSelector_ValueChanged_1(object sender, EventArgs e)
        {
            el.Axis = (int)AxisSelector.Value;
            Changed();
        }
    }
}
