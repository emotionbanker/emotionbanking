using System;
using System.Drawing;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;
using Compucare.Enquire.Common.Calculation.Texts.Script.Wizard.WizardPages;
using Compucare.Enquire.Legacy.Umfrage2Lib;
namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard
{
    public class ExpressionMarkWizard : BaseWizard
    {
        public readonly ExpressionWizardPage _expr;
        public readonly TrafficLightRangeWizardPage _range;
        public readonly AdvancedComparisonWizardPage _advanced;

        private readonly Evaluation _eval;

        public ExpressionMarkWizard(Evaluation eval, TargetData td, Evaluation [] mEval)
        {
            _eval = eval;

            PageHeadImage = Pictures.office_chart_bar_48;

            Text = "Expression Traffic Light Wizard";

            _expr = new ExpressionWizardPage(eval, td, mEval);
            AddWizardPage(_expr);

            _range = new TrafficLightRangeWizardPage();
            AddWizardPage(_range);


            _range.AllowFinish = true;
         
            _range.RangeControl.ColorHigh = Color.Green;
            _range.RangeControl.ColorMid = Color.Yellow;
            _range.RangeControl.ColorLow = Color.Red;
            _range.SelectedSize = 16;

        }

        protected override void OnBeforeSetPage()
        {
            _range.Preset();
        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "expressionIndicatorIcon");

            root.AppendChild(doc.CreateElement("Range")).InnerXml = _range.RangeControl.ToXml();
            root.AppendChild(doc.CreateElement("Size")).InnerText = _range.SelectedSize.ToString();
            root.AppendChild(doc.CreateElement("Expression")).InnerText = _expr.Expression;
            root.AppendChild(doc.CreateElement("UserGroup")).InnerText = _expr.UserGroup.ToString();
            root.AppendChild(doc.CreateElement("GraphicType")).InnerText = _expr.GraphicType();
            root.AppendChild(doc.CreateElement("ComparisonValue")).InnerText = _expr.ComparisonValue().ToString();
            root.AppendChild(doc.CreateElement("ComparisonValueIndex")).InnerText = _expr.ComparisonValueIndex().ToString();
            return root.OuterXml;
        }
    }
}
