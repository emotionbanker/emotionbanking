using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring
{
    public class ScoringCockpit06 : ScoringCockpit
    {
        public Bitmap CreateCockpit(Hashtable ht, Hashtable averages)
        {

            Bitmap bmp = new Bitmap(SystemTools.GetAppPath() + "cockpit06.png");

            Brush white = new SolidBrush(Color.White);

            Color needleColor = Color.FromArgb(51, 51, 51);
            Color cpColor = Color.FromArgb(244, 185, 39);

            float needleLen = 180;
            float needleWid = 10;
            float bottomLen = 45;
            float centerWid = 13;

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font ptsFont = new Font("Verdana", 35, FontStyle.Regular, GraphicsUnit.Pixel);

            Font bptsFont = new Font("Verdana", 90, FontStyle.Bold, GraphicsUnit.Pixel);
            float spacing = 30;

            //points
            if (ht["Strategie"] == null) ht["Strategie"] = 0f;
            if (ht["Führung"] == null) ht["Führung"] = 0f;
            if (ht["Mitarbeiter"] == null) ht["Mitarbeiter"] = 0f;
            if (ht["Kunde"] == null) ht["Kunde"] = 0f;
            if (ht["Kultur"] == null) ht["Kultur"] = 0f;

            float p1 = (float)Math.Round((float)ht["Strategie"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("strategie"), 0);
            float p2 = (float)Math.Round((float)ht["Führung"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("führung"), 0);
            float p3 = (float)Math.Round((float)ht["Mitarbeiter"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("mitarbeiter"), 0);
            float p4 = (float)Math.Round((float)ht["Kunde"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("kunde"), 0);
            float p5 = (float)Math.Round((float)ht["Kultur"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("kultur"), 0);

            float total = p1 + p2 + p3 + p4 + p5;

            LeftalignDrawString(ref g, p1.ToString(), ptsFont, white, 281, 1069, spacing);
            LeftalignDrawString(ref g, p2.ToString(), ptsFont, white, 577, 1498, spacing);
            LeftalignDrawString(ref g, p3.ToString(), ptsFont, white, 1708, 1498, spacing);
            LeftalignDrawString(ref g, p4.ToString(), ptsFont, white, 1149, 1684, spacing);
            LeftalignDrawString(ref g, p5.ToString(), ptsFont, white, 1947, 1067, spacing);

            float x = 132;
            float y = 87;

            float hyp = (float)Math.Sqrt((x * x) + (y * y));

            double angleBest = Rad2Deg(Math.Asin(y / hyp));

            x = 163;
            y = 84;
            hyp = (float)Math.Sqrt((x * x) + (y * y));

            double angleWorst = (float)(180 - Rad2Deg(Math.Asin(y / hyp)));

            double scaleAngle = (angleWorst - angleBest) / 500;


            this.DrawNeedle(g, 383, 1086, needleLen, needleWid, (float)(angleWorst - (p1 * scaleAngle)), needleColor, bottomLen, cpColor, centerWid);
            this.DrawNeedle(g, 677, 1523, needleLen, needleWid, (float)(angleWorst - (p2 * scaleAngle)), needleColor, bottomLen, cpColor, centerWid);
            this.DrawNeedle(g, 1798, 1522, needleLen, needleWid, (float)(angleWorst - (p3 * scaleAngle)), needleColor, bottomLen, cpColor, centerWid);
            this.DrawNeedle(g, 1246, 1721, needleLen, needleWid, (float)(angleWorst - (p4 * scaleAngle)), needleColor, bottomLen, cpColor, centerWid);
            this.DrawNeedle(g, 2057, 1086, needleLen, needleWid, (float)(angleWorst - (p5 * scaleAngle)), needleColor, bottomLen, cpColor, centerWid);

            //LeftalignDrawString(ref g, total.ToString(), large, black, 1974, 1075, 83);


            //avg needles
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


            p1 = (float)Math.Round((float)averages["Strategie"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("strategie"), 0);
            p2 = (float)Math.Round((float)averages["Führung"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("führung"), 0);
            p3 = (float)Math.Round((float)averages["Mitarbeiter"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("mitarbeiter"), 0);
            p4 = (float)Math.Round((float)averages["Kunde"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("kunde"), 0);
            p5 = (float)Math.Round((float)averages["Kultur"], 0);//(float)Math.Round(teval.getColumnEvaluationPointsByName("kultur"), 0);


            this.DrawNeedle(g, 518, 1113, smallLen, smallWid, (float)(angleWorst - (p1 * scaleAngle)), needleColor, smallBlen, cpColor, smallCWid);
            this.DrawNeedle(g, 808, 1545, smallLen, smallWid, (float)(angleWorst - (p2 * scaleAngle)), needleColor, smallBlen, cpColor, smallCWid);
            this.DrawNeedle(g, 1921, 1547, smallLen, smallWid, (float)(angleWorst - (p3 * scaleAngle)), needleColor, smallBlen, cpColor, smallCWid);
            this.DrawNeedle(g, 1376, 1730, smallLen, smallWid, (float)(angleWorst - (p4 * scaleAngle)), needleColor, smallBlen, cpColor, smallCWid);
            this.DrawNeedle(g, 2182, 1113, smallLen, smallWid, (float)(angleWorst - (p5 * scaleAngle)), needleColor, smallBlen, cpColor, smallCWid);


            //pts total


            string ts = total.ToString();

            SizeF s = g.MeasureString(ts, bptsFont);
            //g.DrawString(ts, bptsFont, new SolidBrush(Color.Black), 1258-s.Width/2, 580-s.Height/2);

            g.DrawString(ts, bptsFont, new SolidBrush(Color.White), 1258 - s.Width / 2, 315 - s.Height / 2);

            //big needle

            x = 770;
            y = 395;


            hyp = (float)Math.Sqrt((x * x) + (y * y));

            angleBest = Rad2Deg((float)Math.Asin(y / hyp));

            x = 830;
            y = 375;

            hyp = (float)Math.Sqrt((x * x) + (y * y));

            angleWorst = 180 - Rad2Deg((float)Math.Asin(y / hyp));

            scaleAngle = (angleWorst - angleBest) / 2500;

            double angle = angleWorst - (total * scaleAngle);
            float len = 760;

            this.DrawNeedle(g, 1257, 927, len, 75, (float)angle, needleColor, 135, cpColor, 37);

            return bmp;
        }
    }
}
