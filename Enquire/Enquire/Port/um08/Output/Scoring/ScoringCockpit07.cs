using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring
{
    public class ScoringCockpit07 : ScoringCockpit
    {
        public Bitmap CreateCockpit(ArrayList items)
        {
            Bitmap bmp = new Bitmap(SystemTools.GetAppPath() + "cockpit07-big.png");

            Graphics g = Graphics.FromImage(bmp);

            int bigarr = 0;

            if (items.Count % 2 == 1 || items.Count > 5) //odd
            {
                if (items.Count >= 1) PutImage(g, CreateCol((CockpitElement)items[0]), 1247, 1690);
                if (items.Count >= 2) PutImage(g, CreateCol((CockpitElement)items[1]), 730, 1482);
                if (items.Count >= 3) PutImage(g, CreateCol((CockpitElement)items[2]), 1775, 1482);
                if (items.Count >= 4) PutImage(g, CreateCol((CockpitElement)items[3]), 385, 1050);
                if (items.Count >= 5) PutImage(g, CreateCol((CockpitElement)items[4]), 2065, 1050);
            }
            else //even
            {
                if (items.Count >= 1) PutImage(g, CreateCol((CockpitElement)items[0]), 950, 1600);
                if (items.Count >= 2) PutImage(g, CreateCol((CockpitElement)items[1]), 1550, 1600);
                if (items.Count >= 3) PutImage(g, CreateCol((CockpitElement)items[2]), 550, 1200);
                if (items.Count >= 3) PutImage(g, CreateCol((CockpitElement)items[3]), 1950, 1200);

            }

            for (int i = 0; i < items.Count; i++)
            {
                CockpitElement ce = (CockpitElement)items[i];
                bigarr += ce.pts;
            }
            //CreateCol();

            Font bptsFont = new Font("Verdana", 90, FontStyle.Bold, GraphicsUnit.Pixel);
            string ts = bigarr.ToString();

            SizeF s = g.MeasureString(ts, bptsFont);
            //g.DrawString(ts, bptsFont, new SolidBrush(Color.Black), 1258-s.Width/2, 580-s.Height/2);

            g.DrawString(ts, bptsFont, new SolidBrush(Color.White), 1258 - s.Width / 2, 315 - s.Height / 2);


            //big needle

            float x = 770;

            float y = 395;
            Color needleColor = Color.FromArgb(51, 51, 51);
            Color cpColor = Color.FromArgb(244, 185, 39);

            float hyp = (float)Math.Sqrt((x * x) + (y * y));

            double angleBest = Rad2Deg(Math.Asin(y / hyp));

            x = 830;
            y = 375;

            hyp = (float)Math.Sqrt((x * x) + (y * y));

            double angleWorst = 180 - Rad2Deg(Math.Asin(y / hyp));

            double scaleAngle = (angleWorst - angleBest) / 2500;

            double angle = angleWorst - (bigarr * scaleAngle);
            float len = 760;

            DrawNeedle(g, 1257, 927, len, 75, (float)angle, needleColor, 135, cpColor, 37);

            return bmp;
        }


        public Bitmap CreateCol(CockpitElement ce)
        {
            string top = ce.top;
            string b1 = ce.b1;
            string b2 = ce.b2;
            string b3 = ce.b3;
            int pts = ce.pts;
            int avg = ce.avg;

            Bitmap bmp = new Bitmap(SystemTools.GetAppPath() + "cockpit07.png");

            Graphics g = Graphics.FromImage(bmp);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font bf = new Font("Verdana", 28, FontStyle.Bold, GraphicsUnit.Pixel);
            Font sf = new Font("Arial Narrow", 19, FontStyle.Bold, GraphicsUnit.Pixel);

            Font ptsFont = new Font("Verdana", 35, FontStyle.Regular, GraphicsUnit.Pixel);

            Color needleColor = Color.FromArgb(51, 51, 51);
            Color cpColor = Color.FromArgb(244, 185, 39);

            float needleLen = 180;
            float needleWid = 10;
            float bottomLen = 45;
            float centerWid = 13;

            PutString(g, top, bf, Color.Black, 245, 24);

            PutString(g, b1, sf, Color.Black, 245, 335);
            PutString(g, b2, sf, Color.Black, 245, 363);
            PutString(g, b3, sf, Color.Black, 245, 391);


            //pts

            LeftalignDrawString(ref g, pts.ToString(), ptsFont, new SolidBrush(Color.White), 140, 224, 30f);

            //arrow

            float x = 148;//132;
            float y = 77;//87;

            float hyp = (float)Math.Sqrt((x * x) + (y * y));

            double angleBest = Rad2Deg((float)Math.Asin(y / hyp));

            x = 148;// 163;
            y = 77;// 84;
            hyp = (float)Math.Sqrt((x * x) + (y * y));

            double angleWorst = 180 - Rad2Deg((float)Math.Asin(y / hyp));

            double scaleAngle = (angleWorst - angleBest) / 500;

            DrawNeedle(g, 245, 243, needleLen, needleWid, (float)(angleWorst - (pts * scaleAngle)), needleColor, bottomLen, cpColor, centerWid);

            //avg arrow

            x = 47;
            y = 16;

            hyp = (float)Math.Sqrt((x * x) + (y * y));

            angleBest = Rad2Deg((float)Math.Asin(y / hyp));

            x = 48;
            y = 15;

            hyp = (float)Math.Sqrt((x * x) + (y * y));

            angleWorst = 180 - Rad2Deg((float)Math.Asin(y / hyp));

            scaleAngle = (angleWorst - angleBest) / 500;

            float smallLen = 60;
            float smallWid = 9;
            float smallCWid = 7;
            float smallBlen = 17;

            DrawNeedle(g, 379, 270, smallLen, smallWid, (float) (angleWorst - (avg * scaleAngle)), needleColor, smallBlen, cpColor, smallCWid);

            return bmp;
        }

    }
}
