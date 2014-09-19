using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Texts.Gaps.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;
using umfrage2;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Calculation.Texts.Gaps.Wizard
{
    public class GapWizard : BaseWizard
    {
        public readonly GapWizardPage _gapPage;

        private readonly Evaluation _eval;

        public GapWizard(Evaluation eval)
        {
            _eval = eval;

            PageHeadImage = Pictures.office_chart_bar_48;

            Text = "Gap Wizard";

            _gapPage = new GapWizardPage(_eval);
            _gapPage.AllowFinish = true;
            AddWizardPage(_gapPage);
        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "gap");
            root.AppendChild(doc.CreateElement("Precision")).InnerText = _gapPage.Precision.ToString();
            root.AppendChild(doc.CreateElement("Question1")).InnerXml = _gapPage.GetItems()[0].ToXml();
            root.AppendChild(doc.CreateElement("Question2")).InnerXml = _gapPage.GetItems()[1].ToXml();
            root.AppendChild(doc.CreateElement("ResultType")).InnerText = _gapPage.Type.ToString();
            return root.OuterXml;
        }
    }
}
