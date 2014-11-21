using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Collections;

namespace umfrage2._2007.Controls
{
    public partial class LoadDataControl : UserControl
    {
        private Evaluation eval;
        private List<object> fix;
        internal bool datumAktiv = false;
        internal DateTime datumVon;
        internal DateTime datumBis;
        internal bool percentAktiv = false;
        internal int percentValue;

        public LoadDataControl(Evaluation eval)
        {
            this.eval = eval;
            this.fix = new List<object>();
            
            InitializeComponent();

            eval.Load2007_Init(this);
        }

        public void Loadfix()
        {
            for (int i = 0; i < ChooseTarget.Items.Count; i++)
            {
                fix.Add(ChooseTarget.Items[i]);
            }
        }

        public void Status(string text)
        {
                StatusLabel.Text = text;
            //StatusLabel.Refresh();
        }

        public void Begin()
        {
            eval.Load2007_Process(this);
            //eval.UpdateData(this);
           
        }

        private void ControlButton_Click(object sender, System.EventArgs e)
        {
            bool begin = true;
            if (datumAktiv == true)
            {
                if ((datumVon.Day == 1 && datumVon.Month == 1 && datumVon.Year == 1) || (datumBis.Day == 1 && datumBis.Month == 1 && datumBis.Year == 1)) 
                    begin = false;
                else
                    begin = true;

            }

            if (begin == true)
            {
                ChooseTarget.Enabled = ControlButton.Enabled = false;
                Begin();
            }else{
                MessageBox.Show("Datum ausählen");
            }
        }

        private void DoneButton_Click(object sender, System.EventArgs e)
        {
            eval.lastResultUpdate = DateTime.Now;
            eval.resultDataChanged(this);
            eval.personDataChanged(this);
            eval.reportDataChanged(this);
//            Close();
        }

        private void _selectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChooseTarget.Items.Count; i++ )
            {
                ChooseTarget.SetItemChecked(i, true);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                String temp = textBox1.Text;
            
                ChooseTarget.Items.Clear();
                

                for (int i = 0; i < fix.Count; i++)
                {
                    if (fix[i].ToString().ToLower().Contains(temp.ToLower()))
                    {
                        ChooseTarget.Items.Add(fix[i]);
                    }
                }

                ChooseTarget.Sorted = true;
                

        }

        private void _selectABButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChooseTarget.Items.Count; i++)
            {
                ChooseTarget.SetItemChecked(i, false);
            }
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxDate.Checked==true){
                groupBoxDate.Visible = true;
                datumAktiv = true;
                label4.Visible = label5.Visible = label6.Visible = label7.Visible = label8.Visible = true;
                if (datumVon.Day == 1 && datumVon.Month == 1 && datumVon.Year == 1)
                    label5.Text = "-";
                else
                    label5.Text = datumVon.Day + ". " + datumVon.Month + ". " + datumVon.Year;
                    label7.Text = datumBis.Day + ". " + datumBis.Month + ". " + datumBis.Year;
                

                if (datumBis.Day == 1 && datumBis.Month == 1 && datumBis.Year == 1)
                    label7.Text = "-";
                else
                    label7.Text = datumBis.Day + ". " + datumBis.Month + ". " + datumBis.Year;
                

            }else{
                groupBoxDate.Visible = false;
                datumAktiv = false;
                label4.Visible = label5.Visible = label6.Visible = label7.Visible = label8.Visible = false;
            }
        }

        private void checkBoxPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPercent.Checked == true)
            {
                percentAktiv = true;
                labelValue.Visible = true;
                hScrollBarValue.Visible = true;
                hScrollBarValue.Value = 49;
                labelValue.Text = hScrollBarValue.Value.ToString();
                percentValue = Convert.ToInt32(hScrollBarValue.Value);

            }
            else
            {
                percentAktiv = false;
                labelValue.Visible = false;
                hScrollBarValue.Visible = false;

            }
        }

        private void monthCalendarVon_DateChanged(object sender, DateRangeEventArgs e)
        {
            datumVon = new DateTime(monthCalendarVon.SelectionStart.Year, monthCalendarVon.SelectionStart.Month, monthCalendarVon.SelectionStart.Day);
            label5.Text = datumVon.Day + ". " + datumVon.Month + ". " + datumVon.Year;     
        }

        private void monthCalendarBis_DateChanged(object sender, DateRangeEventArgs e)
        {
            datumBis = new DateTime(monthCalendarBis.SelectionStart.Year, monthCalendarBis.SelectionStart.Month, monthCalendarBis.SelectionStart.Day);
            label7.Text = datumBis.Day + ". " + datumBis.Month + ". " + datumBis.Year; 
        }

        private void hScrollBarValue_Scroll(object sender, ScrollEventArgs e)
        {
            labelValue.Text = hScrollBarValue.Value.ToString();
            percentValue = Convert.ToInt32(hScrollBarValue.Value);
        }

       //end checkboxDate
    }
}
