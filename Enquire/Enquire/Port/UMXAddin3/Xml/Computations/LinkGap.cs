using System;
using System.Xml;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Gap = Compucare.Enquire.Common.Calculation.Texts.Gaps.Gap;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class LinkGap : IXmlText
    {

        private readonly XmlDocument _doc;
        private readonly TargetData _td;
        private readonly Evaluation _eval;

        public LinkGap(XmlDocument doc, TargetData td, Evaluation eval)
        {
            _doc = doc;
            _td = td;
            _eval = eval;
        }


        public string Compute()
        {
                Gap gap = new Gap();
                gap.Type = "Average";
                gap.Precision = (Int32)XmlHelper.GetPrecision(_doc.DocumentElement);
                QuestionDataItem q1 = XmlHelper.GetQuestion(_doc.DocumentElement, "Question1", _eval);
                QuestionDataItem q2 = XmlHelper.GetQuestion(_doc.DocumentElement, "Question2", _eval);
                try
                {
                    gap.Type = (String)XmlHelper.GetInnerText(_doc.DocumentElement, "ResultType");
                }
                catch
                {
                    gap.Type = "Average";
                }
                
                if(gap.Type.Equals("Percent")){
                    //hier die Berechnung

                    gap.ValueA = q1.ComputePercent2(_td, _eval, gap.Precision);
                    gap.ValueB = q2.ComputePercent2(_td, _eval, gap.Precision);
                    gap.Compute();

                    return gap.Result.ToString();
                }else{
                    gap.ValueA = q1.ComputeAverage(_td, _eval);
                    gap.ValueB = q2.ComputeAverage(_td, _eval);

                    gap.Compute();

                    return gap.Result.ToString();
                }
        }//end Compute
    }
}
