using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMXAddin3
{
    public partial class BControlTrendForm : Form
    {
        public float x1 = 2;
        public float x2 = 0.5f;
        public float x3 = -0.5f;
        public float x4 = -2;

        public IndivTLForm tlbForm;

        // 0.. mw
        // 1.. percent
        public int type = 0;


        public String IString
        {
            get
            {
                String i = "" + C1Select.BackColor.R + "-" + C1Select.BackColor.G + "-" + C1Select.BackColor.B + ":";
                i += "" + C2Select.BackColor.R + "-" + C2Select.BackColor.G + "-" + C2Select.BackColor.B + ":";
                i += "" + C3Select.BackColor.R + "-" + C3Select.BackColor.G + "-" + C3Select.BackColor.B + ":";
                i += "" + C4Select.BackColor.R + "-" + C4Select.BackColor.G + "-" + C4Select.BackColor.B + ":";
                i += "" + C5Select.BackColor.R + "-" + C5Select.BackColor.G + "-" + C5Select.BackColor.B + ":";

                i += x1 + ":" + x2 + ":" + x3 + ":" + x4 + ":";

                if (floatBox.Checked) i += "1";
                else i += "0";

                i += ":";

                i += "" + angle1.Value + ":" + angle2.Value + ":" + angle3.Value + ":" + angle4.Value + ":" + angle5.Value;

                i += ":" + trendStyleBox.SelectedIndex + ":" + sizeBox.Text;

                i += ":" + tlbForm.IString;



                return i;
            }
        }

        public BControlTrendForm(int type)
        {
            this.type = type;

            InitializeComponent();

            tlbForm = new IndivTLForm();
            tlbForm.SubControl(true);
           
            this.Text = "Banksteuerungsbericht - Trendpfeil";

            //C1Select.BackColor = Color.DarkRed;
            //C2Select.BackColor = Color.Red;
            //C3Select.BackColor = Color.Black;
            //C4Select.BackColor = Color.LightGreen;
            //C5Select.BackColor = Color.Green;

            x1 = 1;
            x2 = 0.5f;
            x3 = -0.5f;
            x4 = -1;

            trendStyleBox.Items.Add("Blockpfeil");
            trendStyleBox.Items.Add("Kreis");
            trendStyleBox.Items.Add("Ampelkombination");

            trendStyleBox.SelectedIndex = 1;

            prev6.Visible = tlbButton.Visible = false;

            if (type == 1)
            {
                this.Text = "Banksteuerungsbericht - Prozent nach Antwort";

                x1Box.Text = "40";
                x2Box.Text = "10";
                x3Box.Text = "-10";
                x4Box.Text = "-40";

                label2.Text = "von 100 bis ";
            }

            Preview();

        }

        private void Preview()
        {
            if (floatBox.Checked)
            {
                prev6.BackgroundImage = Tools.CreateTrendArrow(C3Select.BackColor, 0, 100, trendStyleBox.SelectedIndex, Color.LimeGreen);
            }
            else
            {
                prev1.BackgroundImage = Tools.CreateTrendArrow(C1Select.BackColor, (float)angle1.Value, 20, trendStyleBox.SelectedIndex, tlbForm.C1Select.BackColor);
                prev2.BackgroundImage = Tools.CreateTrendArrow(C2Select.BackColor, (float)angle2.Value, 20, trendStyleBox.SelectedIndex, tlbForm.C1Select.BackColor);
                prev3.BackgroundImage = Tools.CreateTrendArrow(C3Select.BackColor, (float)angle3.Value, 20, trendStyleBox.SelectedIndex, tlbForm.C2Select.BackColor);
                prev4.BackgroundImage = Tools.CreateTrendArrow(C4Select.BackColor, (float)angle4.Value, 20, trendStyleBox.SelectedIndex, tlbForm.C3Select.BackColor);
                prev5.BackgroundImage = Tools.CreateTrendArrow(C5Select.BackColor, (float)angle5.Value, 20, trendStyleBox.SelectedIndex, tlbForm.C3Select.BackColor);
            }
        }



        private void C1Select_Click(object sender, EventArgs e)
        {
            cDialog.Color = C1Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C1Select.BackColor = cDialog.Color;
            }
            Preview();
        }

        private void C2Select_Click(object sender, EventArgs e)
        {
            cDialog.Color = C2Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C2Select.BackColor = cDialog.Color;
            }
            Preview();
        }

        private void C3Select_Click(object sender, EventArgs e)
        {
            cDialog.Color = C5Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C5Select.BackColor = cDialog .Color;
            }
            Preview();
        }

        private void x1Box_TextChanged(object sender, EventArgs e)
        {
            try
            {
                x1 = float.Parse(x1Box.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                c2Label.Text = "von " + x1 + " bis";
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                x1Box.Text = "2";
            }
        }

        private void x2Box_TextChanged(object sender, EventArgs e)
        {
            try
            {

                x2 = float.Parse(x2Box.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                c3Label.Text = "von " + x2 + " bis";
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                x2Box.Text = "0.5";
            }
        }

        
        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void BControlForm_Load(object sender, EventArgs e)
        {

        }

        private void x3Box_TextChanged(object sender, EventArgs e)
        {
            try
            {

                x3 = float.Parse(x3Box.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                c4Label.Text = "von " + x3 + " bis";
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                x3Box.Text = "-0.5";
            }
        }

        private void x4Box_TextChanged(object sender, EventArgs e)
        {
            try
            {

                x4 = float.Parse(x4Box.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                if (type == 0) c5Label.Text = "von " + x4 + " bis -4";
                else c5Label.Text = "von " + x4 + " bis -100";
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                x4Box.Text = "-2";
            }
        }

        private void C3Select_Click_1(object sender, EventArgs e)
        {
            cDialog.Color = C3Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C3Select.BackColor = cDialog.Color;
            }
            Preview();
        }

        private void C4Select_Click(object sender, EventArgs e)
        {
            cDialog.Color = C4Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C4Select.BackColor = cDialog.Color;
            }
            Preview();
        }

        private void floatBox_CheckedChanged(object sender, EventArgs e)
        {
            anglepanel.Visible = !floatBox.Checked;
            prev6.Visible = floatBox.Checked;
            Preview();
        }

        private void angle1_ValueChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void sizeBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(sizeBox.Text);
            }
            catch
            {
                MessageBox.Show("Nur ganze Zahlen über 0 erlaubt.", "Falsches Zahlenformat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sizeBox.Text = "20";
            }
        }

        private void trendStyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlbButton.Visible = (trendStyleBox.SelectedIndex == 2);
            Preview();
        }

        private void tlbButton_Click(object sender, EventArgs e)
        {
            if (type == 1) tlbForm.setPercent();
            tlbForm.ShowDialog();
            Preview();
        }
    }
}