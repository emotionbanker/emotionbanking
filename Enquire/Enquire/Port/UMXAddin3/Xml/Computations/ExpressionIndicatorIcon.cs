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
using Compucare.Enquire.Legacy.Umfrage2Lib.Script;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class ExpressionIndicatorIcon : IXmlGraphic
    {
        private static readonly ILog _logger = LogHelper.GetLogger();
   
        private String _tempFile;

        public Size Size { get; set; }

        public string Store()
        {
            return _tempFile;
        }

        private double GetValue(String expression, String usergString, Evaluation eval, TargetData td)
        {
            PersonSetting userg = null;
            foreach (PersonSetting ps in eval.CombinedPersons)
            {
                if (ps.ToString() == usergString)
                {
                    userg = ps;
                    break;
                }
            }

            EnquireScript script = new EnquireScript(eval, td);
            script.SetUserGroup(userg);
            double ret = Double.Parse(script.Evaluate(expression));
            return ret;
        }

        public ExpressionIndicatorIcon(XmlDocument doc, TargetData td, Evaluation eval, Evaluation [] mEval)
        {
            try
            {
                int rad = Int32.Parse(XmlHelper.GetInnerText(doc.DocumentElement, "Size"));
                TripleColorRangeControl temp = new TripleColorRangeControl();
                temp.FromXml(XmlHelper.GetInnerXml(doc.DocumentElement, "Range"));
                String expression = XmlHelper.GetInnerText(doc.DocumentElement, "Expression");
                String usergString = XmlHelper.GetInnerText(doc.DocumentElement, "UserGroup");
                String graphicType = XmlHelper.GetInnerText(doc.DocumentElement, "GraphicType");
                bool comparisonValue = false;
                int comparisonValueIndex = 1;
                Evaluation eva = null;
                try
                {
                    comparisonValue = Convert.ToBoolean(XmlHelper.GetInnerText(doc.DocumentElement, "ComparisonValue"));
                    comparisonValueIndex = Convert.ToInt32(XmlHelper.GetInnerText(doc.DocumentElement, "ComparisonValueIndex"));
                    eva = mEval[comparisonValueIndex];
                   
                }catch{

                }

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                if (graphicType == "Ampel")
                {
                    TrafficLight mark = new TrafficLight();
                    mark.ColorHigh = temp.ColorHigh;
                    mark.ColorMiddle = temp.ColorMid;
                    mark.ColorLow = temp.ColorLow;

                    if (comparisonValue == false)
                    {
                        mark.Value = GetValue(expression, usergString, eval, td);
                    }
                    else
                    {
                        double firstValue = GetValue(expression, usergString, eval, td);
                        double secondValue = GetValue(expression, usergString, eva, eva.getSelectedTargetData());
                        mark.Value = firstValue-secondValue;
                    }

                    mark.RangeDelimiterHigh = temp.RangeHigh;
                    mark.RangeDelimiterLow = temp.RangeMid;

                    mark.ImageSize = rad;

                    mark.Compute();

                    ((Image)mark.Result).Save(itfname, ImageFormat.Png);

                    Size = ((Image)mark.Result).Size;
                    _tempFile = itfname;
                }
                else if (graphicType == "Rufzeichen")
                {
                    ExclamationMark mark = new ExclamationMark();
                    mark.ColorHigh = temp.ColorHigh;
                    mark.ColorMiddle = temp.ColorMid;
                    mark.ColorLow = temp.ColorLow;

                    if (comparisonValue == false)
                    {
                        mark.Value = GetValue(expression, usergString, eval, td);
                    }
                    else
                    {
                        double firstValue = GetValue(expression, usergString, eval, td);
                        double secondValue = GetValue(expression, usergString, eva, eva.getSelectedTargetData());
                        mark.Value = firstValue - secondValue;
                    }

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
