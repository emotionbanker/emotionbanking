using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange
{
    class HistoricChangeDiagramProperties
    {

        private String DashText;
        private DashStyle DashStyle;
        private int DashWidth;
        private Color DashColour;

        public HistoricChangeDiagramProperties()
        {

        }

        public HistoricChangeDiagramProperties(String DashText, DashStyle DashStyle, int DashWidth, Color DashColour)
        {
            this.DashColour = DashColour;
            this.DashStyle = DashStyle;
            this.DashText = DashText;
            this.DashWidth = DashWidth;
        }

        public void setDashText(String DashText)
        {
            this.DashText = DashText;
        }

        public String getDashText()
        {
            return this.DashText;
        }

        public void setDashStyle(DashStyle DashStyle)
        {
            this.DashStyle = DashStyle;
        }

        public DashStyle getDashStyle()
        {
            return this.DashStyle;
        }

        public void setDashWidth(int DashWidth)
        {
            this.DashWidth = DashWidth;
        }

        public int getDashWidth()
        {
            return this.DashWidth;
        }

        public void setDashColour(Color DashColour)
        {
            this.DashColour = DashColour;
        }

        public Color getDashColour()
        {
            return this.DashColour;
        }


    }
}
