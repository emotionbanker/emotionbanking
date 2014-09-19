using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Frontends.Common.Controls.Common
{
    public class GradientPanel : Panel
    {
        private Color _startColor;
        private Color _endColor;

        public Color StartColor
        {
            get { return _startColor; }
            set 
            { 
                _startColor = value;
                Refresh();
            }
        }

        public Color EndColor
        {
            get { return _endColor; }
            set
            {
                _endColor = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs args)
        {
            Repaint(args.Graphics);
            base.OnPaint(args);
        }

        private void Repaint(Graphics g)
        {
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, this.Height), new Point(this.Width, 0), StartColor, EndColor);

            g.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));
        }
    }
}
