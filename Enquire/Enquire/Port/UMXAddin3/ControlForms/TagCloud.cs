using System;
using System.Drawing;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class TagCloud : Form
    {
        public float x1;
        public float x2;

        public float f1;
        public float f2;

        public string IString
        {
            get 
            {
                String i = "" + C1Select.BackColor.R + ":" + C1Select.BackColor.G + ":" + C1Select.BackColor.B + ":";
                i += "" + C2Select.BackColor.R + ":" + C2Select.BackColor.G + ":" + C2Select.BackColor.B + ":";
                i += "" + C3Select.BackColor.R + ":" + C3Select.BackColor.G + ":" + C3Select.BackColor.B + ":";

                i += x1 + ":" + x2 + ":" + f1 + ":" + f2;

                if (linButton.Checked) { i += ":lin"; }
                else i += ":log";

                if (autoColRadio.Checked) { i += ":auto"; }
                else i += ":none";

                return i;
            }
        }

        public TagCloud()
        {
            InitializeComponent();

            C1Select.BackColor = Color.Green;
            C2Select.BackColor = Color.Black;
            C3Select.BackColor = Color.Red;

            this.CancelButton = CButton;

            x1 = 30;
            x2 = 10;

            f1 = 5;
            f2 = 16;
        }

        private void OKButton_Click(object sender, EventArgs e)
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
                x1Box.Text = "30";
            }
        }

        private void x2Box_TextChanged(object sender, EventArgs e)
        {
            try
            {
                x2 = float.Parse(x2Box.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                c3Label.Text = "von " + x2 + " bis 0";
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                x2Box.Text = "10";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                f1 = float.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                textBox1.Text = "5";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                f2 = float.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            }
            catch
            {
                MessageBox.Show("Falsches Zahlenformat");
                textBox2.Text = "16";
            }
        }

        private void logButton_CheckedChanged(object sender, EventArgs e)
        {
            if (logButton.Checked)
                linButton.Checked = false;
            else if (!linButton.Checked) linButton.Checked = true;
        }

        private void linButton_CheckedChanged(object sender, EventArgs e)
        {
            if (linButton.Checked)
                logButton.Checked = false;
            else if (!logButton.Checked) logButton.Checked = true;
        }

        private void autoColRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (autoColRadio.Checked) { noColRadio.Checked = false; groupBox3.Enabled = true; }
            else if (!noColRadio.Checked) noColRadio.Checked = true;
        }

        private void noColRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (noColRadio.Checked) { autoColRadio.Checked = false; groupBox3.Enabled = false; }
            else if (!autoColRadio.Checked) autoColRadio.Checked = true;
        }
    }
}