using System;
using System.Drawing;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard
{
    public enum IndicatorGraphics
    {
        TrafficLight,
        ExclamationMark
    }

    public class ExclamationMarkWizard : BaseWizard
    {
        public readonly ExclamationTypeWizardPage _type;
        public readonly TrafficLightRangeWizardPage _range;
        public readonly AdvancedComparisonWizardPage _advanced;

        private readonly Evaluation _eval;
        private readonly IndicatorGraphics _graphicsType;

        public ExclamationMarkWizard(Evaluation eval, Boolean singleMode, IndicatorGraphics graphicsType)
        {
            _eval = eval;
            _graphicsType = graphicsType;

            PageHeadImage = Pictures.office_chart_bar_48;

            if (graphicsType == IndicatorGraphics.ExclamationMark)
            {
                Text = "Exclamation Mark Wizard";
            }
            else if (graphicsType == IndicatorGraphics.TrafficLight)
            {
                Text = "Traffic Light Wizard";
            }
            _type = new ExclamationTypeWizardPage(graphicsType);
            AddWizardPage(_type);

            _range = new TrafficLightRangeWizardPage();
            AddWizardPage(_range);

            _advanced = new AdvancedComparisonWizardPage(_eval);

            _advanced.AllowFinish = true;
            AddWizardPage(_advanced);

            _range.RangeControl.ColorHigh = Color.Red;
            _range.RangeControl.ColorMid = Color.White;
            _range.RangeControl.ColorLow = Color.Green;
            _range.SelectedSize = 32;

            if (singleMode)
            {
                _advanced.EnablePrecision = true;
            }
        }

        protected override void OnBeforeSetPage()
        {
            if (CurrentPage == _range)
            {
                _range.Preset(_type.Type, _type.ResultType);
            }
           
            if (CurrentPage == _advanced)
            {
                _advanced.EnableQuestion2 = _type.Type != ExclamationType.Single;
            }
        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "indicatorIcon");

            root.AppendChild(doc.CreateElement("Precision")).InnerText = _advanced.Precision.ToString();
            root.AppendChild(doc.CreateElement("Range")).InnerXml = _range.RangeControl.ToXml();
            root.AppendChild(doc.CreateElement("Size")).InnerText = _range.SelectedSize.ToString();

            root.AppendChild(doc.CreateElement("GraphicsType")).InnerText = Enum.GetName(typeof(IndicatorGraphics), _graphicsType);


            root.AppendChild(doc.CreateElement("Mode")).InnerText = Enum.GetName(typeof(ExclamationType), _type.Type);

            root.AppendChild(doc.CreateElement("ResultType")).InnerText = Enum.GetName(typeof (ResultType),
                                                                                       _type.ResultType);

            root.AppendChild(doc.CreateElement("Question1")).InnerXml = _advanced.GetItems()[0].ToXml();
            if (_type.Type != ExclamationType.Single)
            {
                root.AppendChild(doc.CreateElement("Question2")).InnerXml = _advanced.GetItems()[1].ToXml();
            }

            return root.OuterXml;
        }
    }
}
