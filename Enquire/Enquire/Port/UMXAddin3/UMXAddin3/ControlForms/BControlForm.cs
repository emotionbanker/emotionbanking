using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMXAddin3
{
    public partial class BControlForm : Form
    {
        public float x1 = 1;
        public float x2 = -1;
        public int rad = 8;

        public int type = 0;

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


        public BControlForm()
        {
            InitializeComponent();

           
            this.Text = "Banksteuerungsbericht - Ampelgraphik";

            C1Select.BackColor = Color.Red;
            C2Select.BackColor = Color.Yellow;
            C3Select.BackColor = Color.Green;

            rad = 8;
            x1 = 1f;
            x2 = -1f;

        }

        public void setPercent()
        {
            type = 1;

            x1Box.Text = "20";
            x2Box.Text = "-20";
            label2.Text = "von 100 bis";
        }

        private void C1Select_Click(object sender, EventArgs e)
        {
            cDialog.Color = C1Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C1Select.BackColor = cDialog.Color;
            }
        }

        private void C2Select_Click(object sender, EventArgs e)
        {
            cDialog.Color = C2Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C2Select.BackColor = cDialog.Color;
            }
        }

        private void C3Select_Click(object sender, EventArgs e)
        {
            cDialog.Color = C3Select.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                C3Select.BackColor = cDialog .Color;
            }
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
                x1Box.Text = "1";
            }
        }

        private void x2Box_TextChanged(object sender, EventArgs e)
        {
            try
            {

                x2 = float.Parse(x2Box.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                if (type == 0) c3Label.Text = "von " + x2 + " bis -4";
                else c3Label.Text = "von " + x2 + " bis -100";
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                x2Box.Text = "-1";
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
    }
}