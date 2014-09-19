using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotnetCHARTING.WinForms;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Compucare.Enquire.Legacy.Umfrage2Lib._2007.Dialogs
{
    [Serializable]
    public class Marker : ISerializable
    {
        public Color MarkerColor;
        public string Text;
        public Boolean Legende;
        public string MarkerValueText;
        public int MarkerValue;
        public int Linestrength;
        public DashStyle DashstyleMarker;

        public Marker()
        {
            Text = "";
            Legende = false;
            MarkerColor = new Color();
            MarkerValue = 1;
            MarkerValueText = "1";
            Linestrength = 1;
            DashstyleMarker = DashStyle.Solid;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Text",Text);
            info.AddValue("MarkerColor", MarkerColor);
            info.AddValue("Legende", Legende);
            info.AddValue("MarkerValue", MarkerValue);
            info.AddValue("MarkerValueText", MarkerValueText);
            info.AddValue("Linestrength", Linestrength);
            info.AddValue("DashstyleMarker", DashstyleMarker);
        }

        public Marker(SerializationInfo info, StreamingContext ctxt)
		{
            try { Text = info.GetString("Text"); }
            catch{ Text = ""; }

            try { Legende = info.GetBoolean("Legende"); }
            catch { Legende = false; }

            try { MarkerValue = info.GetInt32("MarkerValue"); }
            catch { MarkerValue = 1; }

            try { Linestrength = info.GetInt32("Linestrength"); }
            catch { Linestrength = 1; }

            try { MarkerValueText = info.GetString("MarkerValueText"); }
            catch { MarkerValueText = "1"; }

            try
            {
                
                MarkerColor = (Color)info.GetValue("MarkerColor", typeof(Color));
            }
            catch { MarkerColor = new Color(); }

            try { DashstyleMarker = (DashStyle)info.GetValue("DashstyleMarker", typeof(DashStyle)); }
            catch { DashstyleMarker = DashStyle.Solid; }
        }//end Marker IO

        public Marker Clone()
        {
            Marker m = new Marker();

            m.Text = Text;
            m.Legende = Legende;
            m.MarkerValue = MarkerValue;
            m.MarkerValueText = MarkerValueText;
            m.Linestrength = Linestrength;
            m.MarkerColor = MarkerColor;
            m.DashstyleMarker = DashstyleMarker;

            return m;
        }//end Clone();
    }
}
