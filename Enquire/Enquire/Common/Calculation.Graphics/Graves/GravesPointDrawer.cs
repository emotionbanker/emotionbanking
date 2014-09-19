using System.Drawing;

namespace Compucare.Enquire.Common.Calculation.Graphics.Graves
{
    public static class GravesPointDrawer
    {
        public static readonly Color Gray = Color.FromArgb(156,158,159);        
        public static readonly Color Orange = Color.FromArgb(240, 137, 37);


        public static void DrawCircleFilled(System.Drawing.Graphics g, Color color, Point center, float radius)
        {
            g.FillEllipse(new SolidBrush(color), center.X -radius, center.Y-radius, radius*2, radius*2);
        }

        public static void DrawCircleOutline(System.Drawing.Graphics g, Color color, Point center, float radius, float width)
        {
            g.DrawEllipse(new Pen(new SolidBrush(color), width), center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        public static void DrawRectangleFilled(System.Drawing.Graphics g, Color color, Point center, float radius)
        {
            g.FillRectangle(new SolidBrush(color), center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        public static void DrawRectangleOutline(System.Drawing.Graphics g, Color color, Point center, float radius, float width)
        {
            g.DrawRectangle(new Pen(new SolidBrush(color), width), center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

    }
}
