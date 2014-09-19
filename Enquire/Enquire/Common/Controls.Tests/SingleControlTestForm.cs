using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.Controls.Utils;

namespace Compucare.Enquire.Common.Controls.Tests
{
    public partial class SingleControlTestForm : Form
    {
        public SingleControlTestForm()
        {
            InitializeComponent();

            List<DropDownTextBoxItem> items = new List<DropDownTextBoxItem>();
            List<DropDownTextBoxItem> items2 = new List<DropDownTextBoxItem>();

            for (int i = 0; i < 2000; i++)
            {
                items.Add(new DropDownTextBoxItem(i.ToString(), i));
            }

            for (int i = 100000; i < 100010; i++)
            {
                items2.Add(new DropDownTextBoxItem(i.ToString(), i));
            }

            SingleQuestionSelector controller = new SingleQuestionSelector(singleQuestionSelectorControl1);

            controller.LoadItems(items, items2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
