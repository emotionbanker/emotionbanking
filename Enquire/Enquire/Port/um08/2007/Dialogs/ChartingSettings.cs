using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using dotnetCHARTING.WinForms;

namespace umfrage2._2007.Dialogs
{
    public partial class ChartingSettings : Form
    {
        private DNCSettings settings;

        public DNCSettings Settings
        {
            get { return settings; }
        }

        public ChartingSettings()
        {
            Init(new DNCSettings());
        }
        
        public ChartingSettings(DNCSettings s)
        {
            Init(s.Clone());
        }

        public void Init(DNCSettings s)
        {
            InitializeComponent();

            this.settings = s;

            ShadingBox.Items.Clear();
            int sels = 0;
            int i = 0;
            foreach (ShadingEffectMode m in Enum.GetValues(typeof(ShadingEffectMode)))
            {
                string text = string.Empty;
                switch (i)
                {
                    case 0: text = "Keine Schattierung"; break;
                    default: text = "Modus " + i; break;
                }
                ShadingBox.Items.Add(text);

                if (m == settings.ShadingEffect) sels = i;
                i++;
            }
            ShadingBox.SelectedIndex = sels;


            TransparencyControl.Value = s.Transparency;

            XAxis.Text = s.XLabel;
            YAxis.Text = s.YLabel;

            BackColorButton1.BackColor = settings.Back.Color;
            BackColorButton2.BackColor = settings.Back.SecondaryColor;

            BevelBox.Checked = settings.Back.Bevel;
            GlassBox.Checked = settings.Back.GlassEffect;

            ChartBack1.BackColor = settings.ChartBack.Color;
            ChartBack2.BackColor = settings.ChartBack.SecondaryColor;

            ChartBevel.Checked = settings.ChartBack.Bevel;
            ChartGlass.Checked = settings.ChartBack.GlassEffect;

            Legend1.BackColor = settings.LegendBack.Color;
            Legend2.BackColor = settings.LegendBack.SecondaryColor;

            LegendB.Checked = settings.LegendBack.Bevel;
            LegendG.Checked = settings.LegendBack.GlassEffect;

            LBorder.BackColor = settings.LegendBorder;

            CBorder.BackColor = settings.ChartBorder;

            ShowLegendBox.Checked = settings.ShowLegend;

            ShowNBox.Checked = settings.ShowN;

            OnlyLegendBox.Checked = settings.OnlyLegend;

            FontPreview();
        }

        private void FontPreview()
        {
            EFPreview.Text = settings.ElementFont.Name;
            EFPreview.Font = settings.ElementFont;
            EFPreview.ForeColor = settings.ElementFontColor;

            LFPreview.Text = settings.LegendFont.Name;
            LFPreview.Font = settings.LegendFont;
            LFPreview.ForeColor = settings.LegendFontColor;

            if (EFPreview.ForeColor.Equals(Color.White)) EFPreview.BackColor = Color.Gray;
            else EFPreview.BackColor = Color.White;
            if (LFPreview.ForeColor.Equals(Color.White)) LFPreview.BackColor = Color.Gray;
            else LFPreview.BackColor = Color.White;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle sizeNow = new Rectangle(0, 0, this.Width, this.Height);

            if (Enabled)
            {
                Graphics g = e.Graphics;

                Brush b = new LinearGradientBrush(sizeNow, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

                g.FillRectangle(b, 0, 0, this.Width, this.Height);
            }

        }

        private void ShadingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.ShadingEffect = (ShadingEffectMode)Enum.GetValues(typeof(ShadingEffectMode)).GetValue(ShadingBox.SelectedIndex);
        }

        private void KButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TransparencyControl_ValueChanged(object sender, EventArgs e)
        {
            settings.Transparency = (int)TransparencyControl.Value;
        }

        private void XAxis_TextChanged(object sender, EventArgs e)
        {
            settings.XLabel = XAxis.Text;
        }

        private void YAxis_TextChanged(object sender, EventArgs e)
        {
            settings.YLabel = YAxis.Text;
        }

        private void EChooseFont_Click(object sender, EventArgs e)
        {
            ElementFont.Font = settings.ElementFont;

            if (ElementFont.ShowDialog() == DialogResult.OK)
            {
                settings.ElementFont = ElementFont.Font;
                FontPreview();
            }
        }

        private void EChooseColor_Click(object sender, EventArgs e)
        {
            ElementColor.Color = settings.ElementFontColor;

            if (ElementColor.ShowDialog() == DialogResult.OK)
            {
                settings.ElementFontColor = ElementColor.Color;
                FontPreview();
            }
        }

        private void BackColorButton1_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.Back.Color;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.Back.Color = ColDialog.Color;
            else settings.Back.Color = Color.Transparent;
            BackColorButton1.BackColor = settings.Back.Color;
        }

        private void BackColorButton2_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.Back.SecondaryColor;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.Back.SecondaryColor = ColDialog.Color;
            else settings.Back.SecondaryColor = Color.Transparent;
            BackColorButton2.BackColor = settings.Back.SecondaryColor;
        }

        private void BevelBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.Back.Bevel = BevelBox.Checked;
        }

        private void GlassBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.Back.GlassEffect = GlassBox.Checked;
        }

        private void ChartBack1_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.ChartBack.Color;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.ChartBack.Color = ColDialog.Color;
            else settings.ChartBack.Color = Color.Transparent;
            ChartBack1.BackColor = settings.ChartBack.Color;
        }

        private void ChartBack2_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.ChartBack.SecondaryColor;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.ChartBack.SecondaryColor = ColDialog.Color;
            else settings.ChartBack.SecondaryColor = Color.Transparent;
            ChartBack2.BackColor = settings.ChartBack.SecondaryColor;
        }

        private void ChartBevel_CheckedChanged(object sender, EventArgs e)
        {
            settings.ChartBack.Bevel = ChartBevel.Checked;
        }

        private void ChartGlass_CheckedChanged(object sender, EventArgs e)
        {
            settings.ChartBack.GlassEffect = ChartGlass.Checked;
        }

        private void Legend1_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.LegendBack.Color;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.LegendBack.Color = ColDialog.Color;
            else settings.LegendBack.Color = Color.Transparent;
            Legend1.BackColor = settings.LegendBack.Color;
        }

        private void Legend2_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.LegendBack.SecondaryColor;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.LegendBack.SecondaryColor = ColDialog.Color;
            else settings.LegendBack.SecondaryColor = Color.Transparent;
            Legend2.BackColor = settings.LegendBack.SecondaryColor;

        }

        private void LegendB_CheckedChanged(object sender, EventArgs e)
        {
            settings.LegendBack.Bevel = LegendB.Checked;
        }

        private void LegendG_CheckedChanged(object sender, EventArgs e)
        {
            settings.LegendBack.GlassEffect = LegendG.Checked;
        }

        private void LChooseFont_Click(object sender, EventArgs e)
        {
            ElementFont.Font = settings.LegendFont;

            if (ElementFont.ShowDialog() == DialogResult.OK)
            {
                settings.LegendFont = ElementFont.Font;
                FontPreview();
            }
        }

        private void LChooseColor_Click(object sender, EventArgs e)
        {
            ElementColor.Color = settings.LegendFontColor;

            if (ElementColor.ShowDialog() == DialogResult.OK)
            {
                settings.LegendFontColor = ElementColor.Color;
                FontPreview();
            }
        }

        private void CBorder_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.ChartBorder;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.ChartBorder = ColDialog.Color;
            else settings.ChartBorder = Color.Transparent;
            CBorder.BackColor = settings.ChartBorder;
        }

        private void LBorder_Click(object sender, EventArgs e)
        {
            ColDialog.Color = settings.LegendBorder;
            if (ColDialog.ShowDialog() == DialogResult.OK) settings.LegendBorder = ColDialog.Color;
            else settings.LegendBorder = Color.Transparent;
            LBorder.BackColor = settings.LegendBorder;
        }

        private void ShowLegendBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowLegend = ShowLegendBox.Checked;
        }

        private void ShowNBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowN = ShowNBox.Checked;
        }

        private void OnlyLegendBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.OnlyLegend = OnlyLegendBox.Checked;
        }
    }
}