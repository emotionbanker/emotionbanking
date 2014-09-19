using System;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Percentbar.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.Percentbar.Wizard
{
    public class PercentBarWizard : BaseWizard
    {
        private readonly Evaluation _eval;
        private readonly PercentBarWizardPage _percentBar;

        public PercentBarWizard(Evaluation eval)
        {
            _eval = eval;

            PageHeadImage = Pictures.office_chart_bar_48;
            Text = "Percent Bar Wizard";

            _percentBar = new PercentBarWizardPage(eval);
            _percentBar.AllowFinish = true;
            AddWizardPage(_percentBar);


        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "percentbar");

            root.AppendChild(doc.CreateElement("Question")).InnerXml = _percentBar.GetItem().ToXml();
            root.AppendChild(doc.CreateElement("C1")).InnerXml = _percentBar.GetColors()[1].ToArgb().ToString();
            root.AppendChild(doc.CreateElement("C2")).InnerXml = _percentBar.GetColors()[2].ToArgb().ToString();
            root.AppendChild(doc.CreateElement("C3")).InnerXml = _percentBar.GetColors()[3].ToArgb().ToString();
            root.AppendChild(doc.CreateElement("C4")).InnerXml = _percentBar.GetColors()[4].ToArgb().ToString();
            root.AppendChild(doc.CreateElement("C5")).InnerXml = _percentBar.GetColors()[5].ToArgb().ToString();

            return root.OuterXml;
        }
    }
}
