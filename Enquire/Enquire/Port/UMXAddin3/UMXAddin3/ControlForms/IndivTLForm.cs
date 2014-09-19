using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMXAddin3
{

    public partial class IndivTLForm : Form
    {
        private float x1;
        private float x2;

        private int rad;

        /// <summary>
        /// 0 .. mw
        /// 1 .. percent
        /// 2 .. answer count
        /// </summary>
        int type = 0;

        public String IString
        {
            get
            {
                String i = "" + C1Select.BackColor.R + "-" + C1Select.BackColor.G + "-" + C1Select.BackColor.B + ":";
                i += "" + C2Select.BackColor.R + "-" + C2Select.BackColor.G + "-" + C2Select.BackColor.B + ":";
                i += "" + C3Select.BackColor.R + "-" + C3Select.BackColor.G + "-" + C3Select.BackColor.B + ":";
                                
                i += x1 + ":" + x2 + ":" + rad;               

                return i;
            }
        }


        public IndivTLForm()
        {
            InitializeComponent();

            C1Select.BackColor = Color.Red;
            C2Select.BackColor = Color.Yellow;
            C3Select.BackColor = Color.Green;

            rad = 8;
            x1 = 3.5f;
            x2 = 2f;
        }

        public void setPercent()
        {
            type = 1;

            x1Box.Text = "30";
            x2Box.Text = "10";
            label2.Text = "von 100 bis";
            this.Text = "Individuelle Ampelgraphik - Prozentwerte";
        }

        public void setNum()
        {
            type = 2;

            x1Box.Text = "8";
            x2Box.Text = "4";
            label2.Text = "über";
            this.Text = "Individuelle Ampelgraphik - Anzahl Antworten";
        }

        public void setCompare()
        {
            type = 3;

            x1Box.Text = "1";
            x2Box.Text = "-1";
            label2.Text = "von 5 bis";
            this.Text = "Individuelle Ampelgraphik - Vergleich";
        }

        public void setPercentDiff(string textadd)
        {
            //for nps and percent

            type = 4;

            x1Box.Text = "20";
            x2Box.Text = "-20";
            label2.Text = "von 100 bis";
            this.Text = "Individuelle Ampelgraphik - " + textadd;
        }


        public void SubControl(bool val)
        {
            cancel.Visible = radBox.Visible = label8.Visible = !val;


            if (val) button1.Text = "OK";
            else button1.Text = "Einfügen";
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
                x1Box.Text = "3.5";
            }
        }

        private void C1Select_Click(object sender, EventArgs e)
        {
            cdialog.Color = C1Select.BackColor;
            if (cdialog.ShowDialog() == DialogResult.OK)
            {
                C1Select.BackColor = cdialog.Color;
            }
        }

        private void x2Box_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                x2 = float.Parse(x2Box.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                if (type == 0) c3Label.Text = "von " + x2 + " bis 1";
                else if (type == 3) c3Label.Text = "von " + x2 + " bis -5";
                else if (type == 4) c3Label.Text = "von " + x2 + " bis -100";
                else c3Label.Text = "von " + x2 + " bis 0";
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                x2Box.Text = "2";
            }
        }

        private void C2Select_Click(object sender, EventArgs e)
        {
            cdialog.Color = C2Select.BackColor;
            if (cdialog.ShowDialog() == DialogResult.OK)
            {
                C2Select.BackColor = cdialog.Color;
            }
        }

        private void C3Select_Click(object sender, EventArgs e)
        {
            cdialog.Color = C3Select.BackColor;
            if (cdialog.ShowDialog() == DialogResult.OK)
            {
                C3Select.BackColor = cdialog.Color;
            }
        }

        private void radBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                rad = Int32.Parse(radBox.Text);
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat (Beim Radius sind keine Nachkommastellen erlaubt)");
                radBox.Text = "8";
            }
        }

        private void c3Label_Click(object sender, EventArgs e)
        {

        }
    }
}