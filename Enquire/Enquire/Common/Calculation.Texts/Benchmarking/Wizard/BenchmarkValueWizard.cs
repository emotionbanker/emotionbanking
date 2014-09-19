using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;
using System.Xml;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Common.Calculation.Graphics;
using Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages;

namespace Compucare.Enquire.Common.Calculation.Texts.Benchmarking.Wizard.WizardPages
{
    public class BenchmarkValueWizard : BaseWizard
    {
        private readonly BenchmarkValueWizardPage _benchmark;
        private readonly BenchmarkingTypeWizardPage _type;

        public BenchmarkValueWizard(Evaluation eval, TargetData targetData)
        {
            PageHeadImage = Pictures.office_chart_bar_48;
            Text = "Benchmarking Wizard";

            _type = new BenchmarkingTypeWizardPage();
            AddWizardPage(_type);

            _benchmark = new BenchmarkValueWizardPage(eval, targetData);
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

            root.SetAttribute("type", "comparativeBenchmarkvalue");

            root.AppendChild(doc.CreateElement("Comparison")).InnerXml = _benchmark.GetSeparatorItem().ToXml();
            return root.OuterXml;
        }


        private String CreateSimpleBenchmark()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));

            root.SetAttribute("type", "benchmarkvalue");

            root.AppendChild(doc.CreateElement("Question")).InnerXml = _benchmark.GetItem().ToXml();
            return root.OuterXml;
        }
    }
}
