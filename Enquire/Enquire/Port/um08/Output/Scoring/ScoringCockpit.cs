using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring
{
    public abstract class ScoringCockpit
    {
        public static double Deg2Rad(double grad)
        {
            return grad * (Math.PI / 180);
        }

        public static double Rad2Deg(double rad)
        {
            return rad / (Math.PI/180);
        }


        public static void LeftalignDrawString(ref Graphics g, string text, Font f, Brush b, float x, float y, float letterSpacing)
        {
            x -= letterSpacing;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                g.DrawString(text[i].ToString(), f, b, x, y);
                x -= letterSpacing;
            }
        }

        public static void PutString(Graphics g, string s, Font f, Color c, int x, int y)
        {
            SizeF ss = g.MeasureString(s, f);

            g.DrawString(s, f, new SolidBrush(c), new PointF(x - ss.Width / 2, y - ss.Height / 2));
        }

        public static void PutImage(Graphics g, Bitmap bmp, int x, int y)
        {
            g.DrawImage(bmp, x - bmp.Width / 2, y - bmp.Height / 2);
        }

        public void DrawNeedle(Graphics g, float x, float y, float len, float wid, float angle, Color c, float bottomHeight, Color cpColor, float centerWid)
        {
            float vArrowLarge = angle;
            angle = 360 - angle;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush b = new SolidBrush(c);

            PointF[] pol = new PointF[] {new PointF(0,0),
											 new PointF(0,wid), 
											 new PointF(len,wid/2)};

            Matrix m = new Matrix();

            m.Rotate(angle, MatrixOrder.Append);

            float xpos = x - wid / 2;
            float ypos = y - wid / 2;

            if (angle < 270) ypos = y;


            m.Translate(xpos, ypos, MatrixOrder.Append);
            g.Transform = m;
            g.FillPolygon(b, pol);
            g.ResetTransform();


            vArrowLarge = 270 + vArrowLarge;

            float bx = (float)Math.Sin(Deg2Rad(vArrowLarge)) * bottomHeight;
            float by = (float)Math.Cos(Deg2Rad(vArrowLarge)) * bottomHeight;

            g.DrawLine(new Pen(c, wid), x, y, x + bx, y + by);

            float lwid = wid * 1.5f;

            g.FillEllipse(new SolidBrush(c), x + bx - lwid / 2, y + by - lwid / 2, lwid, lwid);

            g.FillEllipse(new SolidBrush(cpColor), x - centerWid / 2, y - centerWid / 2, centerWid, centerWid);
        }





        public void DrawNeedle(Graphics g, double x, double y, double len, float angle)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Console.WriteLine("angle=" + angle + "\tx/y/len\t" + x + "/" + y +"/" + len);
            //needle length: 133
            Pen pen = new Pen(Color.Black, 20);
            Brush br = new SolidBrush(Color.Black);

            double lenS = len / 3;

            //double aangle = Math.Abs(angle);

            double p1x = (Math.Sin(Deg2Rad(angle)) * lenS);
            double p1y = (Math.Cos(Deg2Rad(angle)) * lenS);

            p1x = x + p1x;
            p1y = y - p1y;

            g.DrawLine(pen, (float)x, (float)y, (float)p1x, (float)p1y);

            int width = 12;

            double p2x = x + (Math.Sin(Deg2Rad(angle - width)) * lenS);
            double p2y = y - (Math.Cos(Deg2Rad(angle - width)) * lenS);
            double p3x = x + (Math.Sin(Deg2Rad(angle + width)) * lenS);
            double p3y = y - (Math.Cos(Deg2Rad(angle + width)) * lenS);
            double p4x = x + (Math.Sin(Deg2Rad(angle)) * len);
            double p4y = y - (Math.Cos(Deg2Rad(angle)) * len);

            g.FillPolygon(br, new PointF[] {   new PointF((float)p2x,(float)p2y),
											   new PointF((float)p3x,(float)p3y), 
											   new PointF((float)p4x,(float)p4y)});


        }

    }
}
