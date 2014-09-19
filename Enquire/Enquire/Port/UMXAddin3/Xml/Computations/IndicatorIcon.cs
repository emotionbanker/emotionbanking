using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using log4net;
using Compucare.Enquire.Common.Tools.Logging;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class IndicatorIcon : IXmlGraphic
    {
        private static readonly ILog _logger = LogHelper.GetLogger();
   
        private String _tempFile;

        public Size Size { get; set; }

        public string Store()
        {
            return _tempFile;
        }

        private double GetValue(QuestionDataItem item, ResultType resultType, TargetData td, Evaluation eval, Int32 precision)
        {
            if (resultType == ResultType.Average)
            {
                return item.ComputeAverage(td, eval, precision);
            }
            else if (resultType == ResultType.Nps)
            {
                return item.ComputeNps(td, eval, precision);
            }
            else if (resultType == ResultType.Percent)
            {
                MessageBox.Show("IndicatorIcon Prozent wurde ausgewählt");
               
                return item.ComputePercent(td, eval, precision);
            }

            return 0;
        }

        public IndicatorIcon(XmlDocument doc, TargetData td, Evaluation eval)
        {
            try
            {
                int precision = (Int32)XmlHelper.GetPrecision(doc.DocumentElement);
                int rad = Int32.Parse(XmlHelper.GetInnerText(doc.DocumentElement, "Size"));
                TripleColorRangeControl temp = new TripleColorRangeControl();
                temp.FromXml(XmlHelper.GetInnerXml(doc.DocumentElement, "Range"));

                IndicatorGraphics graphicsType = (IndicatorGraphics)Enum.Parse(typeof (IndicatorGraphics), XmlHelper.GetInnerText(doc.DocumentElement, "GraphicsType"));

                String mode = XmlHelper.GetInnerText(doc.DocumentElement, "Mode");

                ResultType resultType = ResultType.Average;
                try
                {
                   resultType = (ResultType)Enum.Parse(typeof(ResultType), XmlHelper.GetInnerText(doc.DocumentElement, "ResultType"));

                }
                catch (Exception)
                {
                    resultType = ResultType.Average;
                }

                double itval = 0;

                QuestionDataItem q1 = XmlHelper.GetQuestion(doc.DocumentElement, "Question1", eval);


                if (mode == "Single")
                {
                    itval = GetValue(q1, resultType, td, eval, precision);
                }
                else
                {
                    QuestionDataItem q2 = XmlHelper.GetQuestion(doc.DocumentElement, "Question2", eval);

                    double itval1 = GetValue(q1, resultType, td, eval, precision);
                    double itval2 = GetValue(q2, resultType, td, eval, precision);

                    itval = itval1 - itval2;
                    
                }

                if (mode == "Gap")
                {
                    itval = Math.Abs(itval);
                }

                string itfname = System.IO.Path.GetTempFileName() + ".png";

                if (graphicsType == IndicatorGraphics.ExclamationMark)
                {
                    ExclamationMark mark = new ExclamationMark();
                    mark.ColorHigh = temp.ColorHigh;
                    mark.ColorMiddle = temp.ColorMid;
                    mark.ColorLow = temp.ColorLow;

                    mark.Value = itval;

                    mark.RangeDelimiterHigh = temp.RangeHigh;
                    mark.RangeDelimiterLow = temp.RangeMid;

                    mark.ImageSize = rad;

                    mark.Compute();

                    ((Image)mark.Result).Save(itfname, ImageFormat.Png);

                    Size = ((Image)mark.Result).Size;
                    _tempFile = itfname;
                }
                else if (graphicsType == IndicatorGraphics.TrafficLight)
                {
                    TrafficLight mark = new TrafficLight();
                    mark.ColorHigh = temp.ColorHigh;
                    mark.ColorMiddle = temp.ColorMid;
                    mark.ColorLow = temp.ColorLow;

                    mark.Value = itval;

                    mark.RangeDelimiterHigh = temp.RangeHigh;
                    mark.RangeDelimiterLow = temp.RangeMid;

                    mark.ImageSize = rad;

                    mark.Compute();

                    ((Image)mark.Result).Save(itfname, ImageFormat.Png);

                    Size = ((Image)mark.Result).Size;
                    _tempFile = itfname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                _tempFile = "";
            }
        }
    }
}
