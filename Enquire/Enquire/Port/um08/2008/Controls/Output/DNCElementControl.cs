using System.Data;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.DNCGeneric;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2008
{
    public partial class DNCElementControl : UserControl
    {
        public delegate void SelfDestructDelegate();
        public delegate void ControlChangeDelegate();

        private DNCGeneric star;
        private Evaluation eval;
        private DNCElement el;

        public event SelfDestructDelegate SelfDestruct;
        public event ControlChangeDelegate Changed;

        public DNCElementControl(DNCGeneric star, Evaluation eval, DNCElement el)
        {
            this.star = star;
            this.eval = eval;
            this.el = el;

            InitializeComponent();

            SelfDestruct += new SelfDestructDelegate(StarAxisControl_SelfDestruct);
            Changed += new ControlChangeDelegate(StarAxisControl_Changed);

            if (el.q != null) SetButton.Text = el.q.SID;
            ColButton.BackColor = el.ElementColor;

            foreach (DNCElement.DNCElementType t in Enum.GetValues(typeof(DNCElement.DNCElementType)))
                UGSelectBox.Items.Add(t);

            UGSelectBox.SelectedItem = el.Type;
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

        private void UGSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            el.Type = (DNCElement.DNCElementType)UGSelectBox.SelectedItem;
            Changed();
        }
    }
}
