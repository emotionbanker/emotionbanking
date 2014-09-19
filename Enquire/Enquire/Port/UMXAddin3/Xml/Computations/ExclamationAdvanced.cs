using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class ExclamationAdvanced : IXmlGraphic
    {
        private String _tempFile;

        public Size Size { get; set; }

        public string Store()
        {
            return _tempFile;
        }

        public ExclamationAdvanced(XmlDocument doc, TargetData td, Evaluation eval)
        {
            try
            {
                int precision = (Int32)XmlHelper.GetPrecision(doc.DocumentElement);

                QuestionDataItem q1 = XmlHelper.GetQuestion(doc.DocumentElement, "Question1", eval);
                QuestionDataItem q2 = XmlHelper.GetQuestion(doc.DocumentElement, "Question2", eval);

                double itval1 = q1.ComputeAverage(td, eval, precision);
                double itval2 = q2.ComputeAverage(td, eval, precision);

                double itval = itval1 - itval2;
                //MessageBox.Show(itval1 + " - " + itval2 + " = " + itval);

                String range = XmlHelper.GetInnerText(doc.DocumentElement, "Range");

                string[] dat = range.Split(':');

                float x1 = float.Parse(dat[3]);
                float x2 = float.Parse(dat[4]);

                string[] dss = dat[0].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[1].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[2].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[5]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";

                ExclamationMark mark = new ExclamationMark();
                mark.ColorHigh = c1;
                mark.ColorMiddle = c2;
                mark.ColorLow = c3;

                mark.Value = itval;

                mark.RangeDelimiterHigh = x1;
                mark.RangeDelimiterLow = x2;

                mark.ImageSize = rad;

                mark.Compute();

                ((Image)mark.Result).Save(itfname, ImageFormat.Png);

                Size = ((Image) mark.Result).Size;
                _tempFile = itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                _tempFile = "";
            }
        }
    }
}
