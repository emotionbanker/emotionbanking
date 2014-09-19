using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2
{
    public delegate void GroupPersonControlHandler();

    public partial class GroupPersonControl : UserControl
    {
        private PersonSetting[] persons;
        public Hashtable groups;

        public event GroupPersonControlHandler GroupsChanged;

        public GroupPersonControl(PersonSetting[] persons, Hashtable groups)
        {
            InitializeComponent();

            this.persons = persons;
            this.groups = groups;

            Init();

            GroupsChanged += new GroupPersonControlHandler(GroupPersonControl_GroupsChanged);
        }

        void GroupPersonControl_GroupsChanged()
        {
            //do nothing
        }

        public void Init()
        {
            int y = 0;
            foreach (PersonSetting ps in persons)
            {
                CreatePersonGrouper(ps, 0, y*30);
                y ++;
            }
        }

        public void CreatePersonGrouper(PersonSetting ps, int x, int y)
        {
            NumericUpDown sel = new NumericUpDown();
            sel.Minimum = 0;
            sel.Maximum = 100;
            sel.Increment = 1;
            sel.DecimalPlaces = 0;

            if (!groups.ContainsKey(ps))
                groups[ps] = 0;

            sel.Value = (decimal)(int)groups[ps];

            sel.Location = new Point(x, y);
            sel.Tag = ps;

            sel.ValueChanged+=new EventHandler(sel_ValueChanged);


            Label l = new Label();
            l.Text = ps.ToString();

            l.Location = new Point(x + sel.Width, y);

            Controls.Add(sel);
            Controls.Add(l);
        }

        void sel_ValueChanged(object sender, EventArgs e)
        {
            PersonSetting ps = (PersonSetting)((NumericUpDown)sender).Tag;

            groups[ps] = (int)((NumericUpDown)sender).Value;

            GroupsChanged();
        }
    }
}
