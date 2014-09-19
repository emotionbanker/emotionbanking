using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;

namespace Compucare.Enquire.Legacy.Umfrage2Lib._2007.Dialogs
{
    public partial class MarkerSettings : Form
    {

        private Marker settings;
        private Gauge_h056 gauge_settings;

        public Marker Settings
        {
            get { return settings; }
        }

        public MarkerSettings()
        {
            Init(new Marker());
        }

        public MarkerSettings(Marker s, Gauge_h056 g)
        {
            InitializeComponent();
            gauge_settings = g;
            if (g.Percent)
            {
                trackBarMarker.Maximum = 100;
                trackBarMarker.Minimum = 0;
                trackBarMarker.Value = 0;
                trackBarMarker.SmallChange = 1;
            }
            else
            {
                trackBarMarker.Maximum = 1000;
                trackBarMarker.Minimum = 0;
                trackBarMarker.Value = 0;
                trackBarMarker.SmallChange = 1;
            }
            Init(s.Clone());

        }

        public void Init(Marker s)
        {
           
            this.settings = s;
            ChartBack1.BackColor = settings.MarkerColor;
            textboxMarkerText.Text = settings.Text;
            
            trackBar1.Value = settings.Linestrength;
            ShowLegendBox.Checked = settings.Legende;

            try
            {
                if (gauge_settings.Percent)
                {
                    trackBarMarker.Value = settings.MarkerValue;
                    labeltrackBarValue.Text = trackBarMarker.Value.ToString();
                }
                else
                {
                    trackBarMarker.Value = settings.MarkerValue;
                    labeltrackBarValue.Text = ((double)trackBarMarker.Value / 100).ToString();
                }
            }
            catch
            {
                trackBarMarker.Value = 0;
                labeltrackBarValue.Text = trackBarMarker.Value.ToString();
            }

            
           
            if (settings.DashstyleMarker.ToString().Trim().Equals("Solid"))
            {
                comboBox1.SelectedIndex = 0;
            }
            else if (settings.DashstyleMarker.ToString().Trim().Equals("Dash"))
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (settings.DashstyleMarker.ToString().Trim().Equals("DashDot"))
                comboBox1.SelectedIndex = 2;
            else if (settings.DashstyleMarker.ToString().Trim().Equals("DashDotDot"))
                comboBox1.SelectedIndex = 3;
            else if (settings.DashstyleMarker.ToString().Trim().Equals("Dot"))
                comboBox1.SelectedIndex = 4;

        }

        private void ChartBack1_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.MarkerColor;
            if (ColDialog.ShowDialog() == DialogResult.OK)
                settings.MarkerColor = ColDialog.Color;
            else settings.MarkerColor = Color.Transparent;
            ChartBack1.BackColor = settings.MarkerColor;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
                settings.DashstyleMarker = System.Drawing.Drawing2D.DashStyle.Solid;
            else if (comboBox1.SelectedIndex == 1)
                settings.DashstyleMarker = System.Drawing.Drawing2D.DashStyle.Dash;
            else if (comboBox1.SelectedIndex == 2)
                settings.DashstyleMarker = System.Drawing.Drawing2D.DashStyle.DashDot;
            else if (comboBox1.SelectedIndex == 3)
                settings.DashstyleMarker = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            else if (comboBox1.SelectedIndex == 4)
                settings.DashstyleMarker = System.Drawing.Drawing2D.DashStyle.Dot;
            else 
                settings.DashstyleMarker = System.Drawing.Drawing2D.DashStyle.Solid;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            settings.Linestrength = Int32.Parse(trackBar1.Value.ToString());
        }

        private void trackBarMarker_Scroll(object sender, EventArgs e)
        {
            if (gauge_settings.Percent == true)
            {
                labeltrackBarValue.Text = trackBarMarker.Value.ToString();
            }
            else
            {
                labeltrackBarValue.Text = ((double) trackBarMarker.Value/100).ToString();
            }
            settings.MarkerValueText = trackBarMarker.Value.ToString();
            settings.MarkerValue = Int32.Parse(trackBarMarker.Value.ToString());
           
        }

        private void ShowLegendBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.Legende = ShowLegendBox.Checked;
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void KButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void textboxMarkerText_TextChanged(object sender, EventArgs e)
        {
            settings.Text = textboxMarkerText.Text;
        }
    }
}
