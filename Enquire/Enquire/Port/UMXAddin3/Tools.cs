using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Enquire.Common.Tools.Logging;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using log4net;
using umfrage2._2008.Dialogs;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Drawing.Drawing2D;
using Point = System.Drawing.Point;

namespace Compucare.Enquire.Legacy.UMXAddin3
{
    class FieldStyle
    {
        public Microsoft.Office.Interop.Word.Font font;
        
    }

    class Tools
    {
        public static Evaluation LoadEval(string FileName)
        {
            if (FileName.Equals("")) return null;
            if (!File.Exists(FileName))
            {
                MessageBox.Show("Datei konnte nicht gefunden werden, die Verlinkung wurde aufgehoben.\r\nDie Verlinkung kann über \"Daten\" jederzeit wieder hergestellt werden.", "Fehler beim laden der Datei");
                return null;
            }
            try
            {
                
                MultipartLoadDialog mpl = new MultipartLoadDialog();
                mpl.AutoComplete = true;
                mpl.LoadFile(FileName);
                return mpl.eval;
            }
            catch
            {
                MessageBox.Show("Datei konnte nicht gefunden werden, die Verlinkung wurde aufgehoben.\r\nDie Verlinkung kann über \"Daten\" jederzeit wieder hergestellt werden.", "Fehler beim laden der Datei" );
                return null;
            }

        }

        public static Image CreatePotBar(Evaluation eval, float val, bool pcnt, float max, int width, int height)
        {

            if (val > max) val = max;
            if (val < (max * -1)) val = max * -1;

            Bitmap bmp = new Bitmap(width, height);

            float range = max * 2;

            float fact = width / range;

            Graphics g = Graphics.FromImage(bmp);

            if (val > 0)
            {
                g.FillRectangle(new SolidBrush(Color.Green), (fact * max), 0, (fact * val), height);
            }
            else if (val < 0)
            {
                g.FillRectangle(new SolidBrush(Color.Red), (fact * max) + (fact * val), 0, Math.Abs(fact * val), height);
            }

            g.DrawLine(new Pen(Color.Black, 2), (fact * max), 0, (fact * max), height);

            return bmp;
        }

        public static Image CreateBarImage(Evaluation eval, Question q, PersonSetting ps, int width, int height)
        {
            float pcnt1 = (float)q.GetAnswerPercentByPerson(0, eval, ps);
            float pcnt2 = (float)q.GetAnswerPercentByPerson(1, eval, ps);
            float pcnt3 = (float)q.GetAnswerPercentByPerson(2, eval, ps);
            float pcnt4 = (float)q.GetAnswerPercentByPerson(3, eval, ps);
            float pcnt5 = (float)q.GetAnswerPercentByPerson(4, eval, ps);
            float pcnt6 = (float)q.GetAnswerPercentByPerson(5, eval, ps);

            Bitmap bmp = new Bitmap(width, height);


            float fact = ((float)width) / 100f;

            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(new SolidBrush(Color.Green), 0, 0, (pcnt1 * fact), height);
            g.FillRectangle(new SolidBrush(Color.LightGreen), (pcnt1 * fact), 0, (pcnt2 * fact), height);
            //g.FillRectangle(new SolidBrush(Color.Orange), (pcnt1 * fact) + (pcnt2 * fact), 0, (pcnt3 * fact), height);
            g.FillRectangle(new SolidBrush(Color.Red), (pcnt1 * fact) + (pcnt2 * fact) + (pcnt3 * fact), 0, (pcnt4 * fact), height);
            g.FillRectangle(new SolidBrush(Color.DarkRed), (pcnt1 * fact) + (pcnt2 * fact) + (pcnt3 * fact) + (pcnt4 * fact), 0, (pcnt5 * fact), height);
            //g.FillRectangle(new SolidBrush(Color.DarkGray), (pcnt1 * fact) + (pcnt2 * fact) + (pcnt3 * fact) + (pcnt4 * fact) + (pcnt5 * fact), 0, (pcnt6 * fact), height);

            return bmp;

        }

        public static Image CreateTLImage(Evaluation eval, double val, int rad)
        {
            Color c;
            if (val == -1) c = Color.LightGray;
            else if (val < 2) c = eval.TlbColor3;
            else if (val < 3) c = eval.TlbColor2;
            else c = eval.TlbColor1;

            Bitmap bmp = new Bitmap(rad * 2, rad * 2);

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillEllipse(new SolidBrush(c), 0, 0, rad * 2, rad * 2);

            return bmp;
        }

        public static Image CreateTLImage2(Evaluation eval, double val, int rad, float x1, float x2, Color c1, Color c2, Color c3)
        {
            Color c;

            if (val > x1) c = c1;
            else if (val > x2) c = c2;
            else c = c3;

            Bitmap bmp = new Bitmap(rad * 2 + 2, rad * 2 + 2);

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillEllipse(new SolidBrush(c), 0, 0, rad * 2, rad * 2);

            return bmp;
        }

        public static Image CreateTLImage(Evaluation eval, double val, int rad, float x1, float x2, Color c1, Color c2, Color c3)
        {
            // 5...x1 "red"
            // x1..x2 "yellow"
            // x2...1 "green"

            Color c;

            if (val == -1) c = Color.LightGray;
            else if (val < x2) c = c3;
            else if (val < x1) c = c2;
            else c = c1;

            LogHelper.GetLogger().Info(
                    String.Format("Creating traffic light for value '{0}' with color '{1}'; x1='{2}', x2='{3}'",
                    val, c, x1, x2));

            Bitmap bmp = new Bitmap(rad * 2+2, rad * 2+2);

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillEllipse(new SolidBrush(c), 0, 0, rad * 2, rad * 2);

            return bmp;
        }

        public static Image CreateExclamationImage(Evaluation eval, double val, int radius, float x1, float x2, Color c1, Color c2, Color c3)
        {
            // 5...x1 "red"
            // x1..x2 "yellow"
            // x2...1 "green"

            Color c;
            
            if (val == -1) c = Color.LightGray;
            else if (val < x2) c = c3;
            else if (val < x1) c = c2;
            else c = c1;

            radius = 25;


            Bitmap bmp = new Bitmap(radius, radius);
          

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SolidBrush colorBrush = new SolidBrush(c);

            float pad = radius / 4;
            float rad = radius / 4;

            //draw triangle
            g.FillPolygon(colorBrush, new[] { new PointF(pad, 0), new PointF(radius - pad, 0), new PointF(radius / 2, radius - radius / 3) });

            //draw dot
            g.FillEllipse(colorBrush, radius / 2 - rad / 2, radius - radius / 4, rad, radius / 4);

            return bmp;
        }

        private static Bitmap rotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }

        public static Image CreateTrendArrow(Color col, float angle, int size, int style, Color tlbColor)
        {
            Bitmap bmp = new Bitmap(size, size);

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;


            float s = (float)size - 2;
            SolidBrush b = new SolidBrush(col);
            SolidBrush w = new SolidBrush(Color.White);

            if (style == 0)
            {
                g.FillRectangle(b, 1, s / 4 + 1, (s / 3) * 2, s / 2);
                g.FillPolygon(b, new PointF[] { new PointF(s / 2 +1, 1), new PointF(s +1, s / 2+1), new PointF(s / 2 +1, s+1) });
            }
            else if (style == 1)
            {
                float inneroffset = s/15f;
                float aoffset = s/20f;
                
                g.DrawEllipse(new Pen(col), 1, 1, s, s);
                
                g.FillEllipse(b, inneroffset+1, inneroffset+1, s - (inneroffset * 2), s - (inneroffset * 2));

                g.FillRectangle(w, 4 * aoffset + 1, 8 * aoffset + 1, 8 * aoffset, 4 * aoffset);
                g.FillPolygon(w, new PointF[] { new PointF(11*aoffset + 1, 5*aoffset +1), new PointF(17*aoffset + 1, s/2 + 1), new PointF(11*aoffset + 1, s-(5*aoffset))});
            }
            else if (style == 2)
            {
                float inneroffset = s / 15f;
                float aoffset = s / 20f;

                //g.DrawEllipse(new Pen(tlbColor), 1, 1, s, s);

                g.FillEllipse(new SolidBrush(tlbColor), 1, 1, s, s);
                g.FillEllipse(w, inneroffset + 1, inneroffset + 1, s - (inneroffset * 2), s - (inneroffset * 2));

                g.FillRectangle(b, 4 * aoffset + 1, 8 * aoffset + 1, 8 * aoffset, 4 * aoffset);
                g.FillPolygon(b, new PointF[] { new PointF(11 * aoffset + 1, 5 * aoffset + 1), new PointF(17 * aoffset + 1, s / 2 + 1), new PointF(11 * aoffset + 1, s - (5 * aoffset)) });
            }

            

            return rotateImage(bmp, angle);
        }

        public static FieldStyle GetFieldStyle(Microsoft.Office.Interop.Word.Field f)
        {
            FieldStyle fs = new FieldStyle();

            Range r = f.Code;

            fs.font = r.Font;

            return fs;
        }

        public static void SetFieldStyle(Range r, FieldStyle fs)
        {
            r.Font = fs.font;
        }



        public static object GetWordDocumentPropertyValue(Microsoft.Office.Interop.Word.Document document, string propertyName)
        {
            object propertyValue = null;
            try
            {
                object pname = (object) propertyName;
                propertyValue = document.Variables.get_Item(ref pname).Value;
                
                /*object builtInProperties = document.BuiltInDocumentProperties;
                Type builtInPropertiesType = builtInProperties.GetType();
                object property = builtInPropertiesType.InvokeMember("Item", BindingFlags.GetProperty, null, builtInProperties, new object[] { propertyName });
                Type propertyType = property.GetType();
                propertyValue = propertyType.InvokeMember("Value", BindingFlags.GetProperty, null, property, new object[] { });
                 * */
                //MessageBox.Show(propertyName + ":" + (string)propertyValue, "READ");
            }
            catch
            {
                //MessageBox.Show(e.Message, "READ");
            }
          return propertyValue;
        }


        public static void SetWordDocumentPropertyValue(Microsoft.Office.Interop.Word.Document document, string propertyName, string propertyValue)
        {
            try
            {
                object pval = (object)propertyValue;
                bool found = false;
                foreach (Microsoft.Office.Interop.Word.Variable var in document.Variables)
                {
                    if (var.Name.Equals(propertyName)) { var.Value = (string)pval; found = true; }
                }

                if (!found) { document.Variables.Add(propertyName, ref pval); }
                /*
          object builtInProperties = document.BuiltInDocumentProperties;
          Type builtInPropertiesType = builtInProperties.GetType();
          object property = builtInPropertiesType.InvokeMember("Item", System.Reflection.BindingFlags.GetProperty, null, builtInProperties, new object[] { propertyName });
          Type propertyType = property.GetType();
          propertyType.InvokeMember("Value", BindingFlags.SetProperty, null, property, new object[] { propertyValue });
                 * */
          //MessageBox.Show(propertyName + ":" + propertyValue, "STORE");
              }
              catch
              {
                  //MessageBox.Show(e.Message, "STORE");
              }
        }

        public static void SetPPtDocumentPropertyValue(Microsoft.Office.Interop.PowerPoint.Presentation document, string propertyName, string propertyValue)
        {
            document.Tags.Delete(propertyName);
            document.Tags.Add(propertyName, propertyValue);
        }

        public static string GetPPtDocumentPropertyValue(Microsoft.Office.Interop.PowerPoint.Presentation document, string propertyName)
        {
            return document.Tags[propertyName];
        }





        public static TargetData Cross(Evaluation eval, TargetData td, Question q, int a)
        {
            try
            {
                TargetData cr = new TargetData("", td.Name + ", " + q.ID + "." + a, "");

                string answer = q.AnswerList[a];

                Question Cross = td.GetQuestion(q.ID, eval);

                ArrayList UIDs = new ArrayList();
                foreach (Result r in Cross.Results)
                {
                    if (Cross.Display.Equals("multi"))
                    {
                        foreach (string ra in r.TextAnswer.Split(';'))
                        {
                            if (ra.Equals(answer))
                            {
                                UIDs.Add(r.UserID);
                                break;
                            }
                        }
                    }
                    else if (r.SelectedAnswer == a || r.TextAnswer.Equals(answer))
                    {
                        UIDs.Add(r.UserID);
                    }
                }

                cr.Questions = new Question[td.Questions.Length];

                int j = 0;
                foreach (Question oq in td.Questions)
                {
                    Question nq = new Question(oq);
                    foreach (int uid in UIDs)
                    {
                        Result rs = oq.GetResultByUserID(uid);
                        if (rs != null)
                            nq.Results.Add(rs.Copy);
                    }
                    cr.Questions[j++] = nq;
                }

                return cr;
            }
            catch
            {
                return null;
            }
        }
    }
}
