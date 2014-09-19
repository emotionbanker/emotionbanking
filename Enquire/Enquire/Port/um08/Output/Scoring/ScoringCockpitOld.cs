using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring
{
    public class ScoringCockpitOld : ScoringCockpit
    {
        public Bitmap CreateCockpit(Hashtable ht, Hashtable top, Hashtable flop)
        {
            Bitmap bmp = new Bitmap(SystemTools.GetAppPath() + "cockpit.png");

            Brush black = new SolidBrush(Color.Black);

            Graphics g = Graphics.FromImage(bmp);

            Font f = new Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel);
            Font small = new Font("Arial", 35, FontStyle.Bold, GraphicsUnit.Pixel);
            Font large = new Font("Arial", 60, FontStyle.Bold, GraphicsUnit.Pixel);

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

            LeftalignDrawString(ref g, p1.ToString(), f, black, 111, 834, 30);
            LeftalignDrawString(ref g, p2.ToString(), f, black, 420, 834, 30);
            LeftalignDrawString(ref g, p3.ToString(), f, black, 732, 834, 30);
            LeftalignDrawString(ref g, p4.ToString(), f, black, 1042, 834, 30);
            LeftalignDrawString(ref g, p5.ToString(), f, black, 1353, 834, 30);

            LeftalignDrawString(ref g, total.ToString(), large, black, 945, 294, 83);


            //needles
            //
            //300x135

            float angle = 500f / 180f;

            p1 = (p1 - 250f) / angle;
            p2 = (p2 - 250f) / angle;
            p3 = (p3 - 250f) / angle;
            p4 = (p4 - 250f) / angle;
            p5 = (p5 - 250f) / angle;

            DrawNeedle(g, 148, 819, 130, p1);
            DrawNeedle(g, 458, 819, 130, p2);
            DrawNeedle(g, 770, 819, 130, p3);
            DrawNeedle(g, 1080, 819, 130, p4);
            DrawNeedle(g, 1393, 819, 130, p5);

            DrawNeedle(g, 765, 264, 130, (total - 1250) / (2500 / 180));

            ///best/worst
            ///


            string s1;
            string s2;
            string s3;
            string s4;
            string s5;

            if (top.ContainsKey("Strategie")) s1 = Math.Round((float)top["Strategie"], 0).ToString();
            else s1 = "";

            if (top.ContainsKey("Führung")) s2 = Math.Round((float)top["Führung"], 0).ToString();
            else s2 = "";

            if (top.ContainsKey("Mitarbeiter")) s3 = Math.Round((float)top["Mitarbeiter"], 0).ToString();
            else s3 = "";

            if (top.ContainsKey("Kunde")) s4 = Math.Round((float)top["Kunde"], 0).ToString();
            else s4 = "";

            if (top.ContainsKey("Kultur")) s5 = Math.Round((float)top["Kultur"], 0).ToString();
            else s5 = "";

            SizeF s = g.MeasureString(s1, small);
            g.DrawString(s1, small, black, 223 - s.Width / 2, 918);
            s = g.MeasureString(s2, small);
            g.DrawString(s2, small, black, 533 - s.Width / 2, 918);
            s = g.MeasureString(s3, small);
            g.DrawString(s3, small, black, 846 - s.Width / 2, 918);
            s = g.MeasureString(s4, small);
            g.DrawString(s4, small, black, 1159 - s.Width / 2, 918);
            s = g.MeasureString(s5, small);
            g.DrawString(s5, small, black, 1469 - s.Width / 2, 918);


            if (flop.ContainsKey("Strategie")) s1 = Math.Round((float)flop["Strategie"], 0).ToString();
            else s1 = "";

            if (flop.ContainsKey("Führung")) s2 = Math.Round((float)flop["Führung"], 0).ToString();
            else s2 = "";

            if (flop.ContainsKey("Mitarbeiter")) s3 = Math.Round((float)flop["Mitarbeiter"], 0).ToString();
            else s3 = "";

            if (flop.ContainsKey("Kunde")) s4 = Math.Round((float)flop["Kunde"], 0).ToString();
            else s4 = "";

            if (flop.ContainsKey("Kultur")) s5 = Math.Round((float)flop["Kultur"], 0).ToString();
            else s5 = "";

            s = g.MeasureString(s1, small);
            g.DrawString(s1, small, black, 76 - s.Width / 2, 918);
            s = g.MeasureString(s2, small);
            g.DrawString(s2, small, black, 382 - s.Width / 2, 918);
            s = g.MeasureString(s3, small);
            g.DrawString(s3, small, black, 693 - s.Width / 2, 918);
            s = g.MeasureString(s4, small);
            g.DrawString(s4, small, black, 1003 - s.Width / 2, 918);
            s = g.MeasureString(s5, small);
            g.DrawString(s5, small, black, 1317 - s.Width / 2, 918);

            return bmp;
        }
    }
}
