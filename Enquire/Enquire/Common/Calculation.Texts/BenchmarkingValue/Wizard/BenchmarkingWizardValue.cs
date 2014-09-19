using System;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard
{
    public class BenchmarkingWizard : BaseWizard
    {
        private readonly BenchmarkWizardPage _benchmark;
        private readonly BenchmarkingTypeWizardPage _type;

        public BenchmarkingWizard(Evaluation eval, TargetData targetData)
        {
            PageHeadImage = Pictures.office_chart_bar_48;
            Text = "Benchmarking Wizard";

            _type = new BenchmarkingTypeWizardPage();
            AddWizardPage(_type);

            _benchmark = new BenchmarkWizardPage(eval, targetData);
            _benchmark.AllowFinish = true;
            AddWizardPage(_benchmark);
        }

        protected override void OnAfterSetPage()
        {
            _benchmark.SetType(_type.Type);
        }

        public String GetXml()
        {
            if (_type.Type == BenchmarkingType.Simple)
            {
                return CreateSimpleBenchmark();
            }
            
            return CreateComparativeBenchmark();
        }

        private string CreateComparativeBenchmark()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));

            root.SetAttribute("type", "comparativeBenchmark");

            root.AppendChild(doc.CreateElement("Comparison")).InnerXml = _benchmark.GetSeparatorItem().ToXml();
            return root.OuterXml;
        }


        private String CreateSimpleBenchmark()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));

            root.SetAttribute("type", "benchmark");

            root.AppendChild(doc.CreateElement("Question")).InnerXml = _benchmark.GetItem().ToXml();
            return root.OuterXml;
        }
    }
}
