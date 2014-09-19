using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

using dotnetCHARTING.WinForms;

namespace umfrage2._2007
{
    [Serializable]
    public class DNCSettings : ISerializable
    {
        public ShadingEffectMode ShadingEffect;
        public int Transparency;
        public string XLabel;
        public string YLabel;
        public Font ElementFont;
        public Color ElementFontColor;

        public Background Back;
        public Background ChartBack;
        
        public Background LegendBack;
        public Font LegendFont;

        public Color LegendFontColor;

        public Color ChartBorder;
        public Color LegendBorder;

        public bool ShowLegend;
        public bool OnlyLegend;

        public bool ShowN;

        public DNCSettings()
        {
            ShadingEffect = ShadingEffectMode.One;
            Transparency = 20;
            XLabel = string.Empty;
            YLabel = string.Empty;
            ElementFont = new Font("Tahoma", 8);
            ElementFontColor = Color.Black;

            Back = new Background();
            ChartBack = new Background();

            LegendBack = new Background();
            LegendFont = new Font("Tahoma", 8);

            LegendFontColor = Color.Black;

            ShowLegend = true;
            OnlyLegend = false;

            ShowN = false;

            LegendBorder = ChartBorder = Color.Black;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
            info.AddValue("ShadingEffect", ShadingEffect);
            info.AddValue("Transparency", Transparency);
            info.AddValue("XLabel", XLabel);
            info.AddValue("YLabel", YLabel);
            info.AddValue("ElementFont", ElementFont);
            info.AddValue("ElementFontColor", ElementFontColor);

            info.AddValue("Back1", Back.Color);
            info.AddValue("Back2", Back.SecondaryColor);
            info.AddValue("Back3", Back.Bevel);
            info.AddValue("Back4", Back.GlassEffect);

            info.AddValue("ChartBack1", ChartBack.Color);
            info.AddValue("ChartBack2", ChartBack.SecondaryColor);
            info.AddValue("ChartBack3", ChartBack.Bevel); 
            info.AddValue("ChartBack4", ChartBack.GlassEffect);

            info.AddValue("LegendBack1", LegendBack.Color);
            info.AddValue("LegendBack2", LegendBack.SecondaryColor);
            info.AddValue("LegendBack3", LegendBack.Bevel);
            info.AddValue("LegendBack4", LegendBack.GlassEffect);

            info.AddValue("LegendFont", LegendFont);

            info.AddValue("LegendFontColor", LegendFontColor);

            info.AddValue("LegendBorder", LegendBorder);
            info.AddValue("ChartBorder", ChartBorder);

            info.AddValue("ShowLegend", ShowLegend);

            info.AddValue("ShowN", ShowN);

            info.AddValue("OnlyLegend", OnlyLegend);
		}

		public DNCSettings(SerializationInfo info, StreamingContext ctxt)
		{
            ShadingEffect = (ShadingEffectMode)info.GetValue("ShadingEffect", typeof(ShadingEffectMode));
            Transparency = info.GetInt32("Transparency");
            XLabel = info.GetString("XLabel");
            YLabel = info.GetString("YLabel");
            ElementFont = (Font)info.GetValue("ElementFont", typeof(Font));
            ElementFontColor = (Color)info.GetValue("ElementFontColor", typeof(Color));

            try 
            {
                Back = new Background();
                Back.Color = (Color)info.GetValue("Back1", typeof(Color));
                Back.SecondaryColor = (Color)info.GetValue("Back2", typeof(Color));
                Back.Bevel = info.GetBoolean("Back3");
                Back.GlassEffect = info.GetBoolean("Back4");
            }
            catch { Back = new Background(); }

            try
            {
                ChartBack = new Background();
                ChartBack.Color = (Color)info.GetValue("ChartBack1", typeof(Color));
                ChartBack.SecondaryColor = (Color)info.GetValue("ChartBack2", typeof(Color));
                ChartBack.Bevel = info.GetBoolean("ChartBack3");
                ChartBack.GlassEffect = info.GetBoolean("ChartBack4");
            }
            catch { ChartBack = new Background(); }

            try
            {
                LegendBack = new Background();
                LegendBack.Color = (Color)info.GetValue("LegendBack1", typeof(Color));
                LegendBack.SecondaryColor = (Color)info.GetValue("LegendBack2", typeof(Color));
                LegendBack.Bevel = info.GetBoolean("LegendBack3");
                LegendBack.GlassEffect = info.GetBoolean("LegendBack4");
            }
            catch { ChartBack = new Background(); }

            try { LegendFont = (Font)info.GetValue("LegendFont", typeof(Font)); }
            catch { LegendFont = new Font("Tahoma", 8); }

            try { LegendFontColor = (Color)info.GetValue("LegendFontColor", typeof(Color)); }
            catch { LegendFontColor = Color.Black; }

            try { LegendBorder = (Color)info.GetValue("LegendBorder", typeof(Color)); }
            catch { LegendBorder = Color.Black; }

            try { ChartBorder = (Color)info.GetValue("ChartBorder", typeof(Color)); }
            catch { ChartBorder = Color.Black; }

            try { ShowLegend = info.GetBoolean("ShowLegend"); }
            catch { ShowLegend =true; }

            try { OnlyLegend = info.GetBoolean("OnlyLegend"); }
            catch { OnlyLegend = false; }

            try { ShowN = info.GetBoolean("ShowN"); }
            catch { ShowN = false; }
        }

        public void ApplyLegendBox(Chart c, LegendBox lb)
        {
            lb.Background = LegendBack;
            lb.DefaultEntry.LabelStyle.Font = LegendFont;
            lb.Shadow.Depth = 0;
            lb.Line.Color = LegendBorder;

            lb.Line.StartCap = LineCap.Flat;
            lb.Line.EndCap = LineCap.Round;
        }

        public void Apply(Chart c)
        {
            
            c.ShadingEffectMode = ShadingEffect;
            c.DefaultSeries.DefaultElement.Transparency = Transparency;
            c.XAxis.Label.Text = XLabel;
            c.YAxis.Label.Text = YLabel;

            c.DefaultSeries.DefaultElement.SmartLabel.Font = ElementFont;
            c.DefaultSeries.DefaultElement.SmartLabel.Color = ElementFontColor;

            c.YAxis.Label.Font = c.XAxis.Label.Font = ElementFont;
            c.YAxis.Label.Color = c.XAxis.Label.Color = ElementFontColor;

            c.XAxis.DefaultTick.Label.Font = c.YAxis.DefaultTick.Label.Font = ElementFont;
            c.XAxis.DefaultTick.Label.Color = c.YAxis.DefaultTick.Label.Color = ElementFontColor;


            c.Background = Back;
            c.ChartArea.Background = ChartBack;

            ApplyLegendBox(c, c.LegendBox);

            c.LegendBox.Visible = ShowLegend;

            c.XAxis.Line.Color = c.YAxis.Line.Color = ChartBorder;
            c.ChartArea.Line.Color = ChartBorder;


            c.Margin = "0";
            c.Padding = new System.Windows.Forms.Padding(0);
            
            c.ChartArea.Shadow.Depth = 0;
            
            if (OnlyLegend)
            {
                c.LegendBox.Visible = true;
                //c.ChartArea.Visible = false;
                //c.Visible = false;
            }
        }


        public DNCSettings Clone()
        {
            DNCSettings n = new DNCSettings();

            n.ShadingEffect = ShadingEffect;
            n.Transparency = Transparency;

            n.XLabel = XLabel;
            n.YLabel = YLabel;

            n.ElementFont = (Font)ElementFont.Clone();
            n.ElementFontColor = ElementFontColor;

            n.Back = (Background)Back.Clone();
            n.ChartBack = (Background)ChartBack.Clone();

            n.LegendBack = (Background)LegendBack.Clone();
            n.LegendFont = (Font)LegendFont.Clone();

            n.LegendFontColor = LegendFontColor;

            n.ChartBorder = ChartBorder;
            n.LegendBorder = LegendBorder;

            n.ShowLegend = ShowLegend;

            n.OnlyLegend = OnlyLegend;

            n.ShowN = ShowN;

            return n;
        }
    }
}
