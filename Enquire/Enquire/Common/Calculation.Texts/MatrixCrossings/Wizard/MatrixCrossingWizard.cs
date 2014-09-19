using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Texts.MatrixCrossings.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.MatrixCrossings.Wizard
{
    public class MatrixCrossingWizard : BaseWizard
    {
        private readonly MatrixCrossingWizardPage _page;

        public MatrixCrossingWizard(Evaluation eval)
        {
            PageHeadImage = Pictures.office_chart_bar_48;
            Text = "Matrix Crossing Wizard";

            _page = new MatrixCrossingWizardPage(eval);
            AddWizardPage(_page);
            _page.AllowFinish = true;
        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));

            root.SetAttribute("type", "matrixCrossing");

            root.AppendChild(doc.CreateElement("Horizontal")).InnerXml = _page.GetHorizontalItem().ToXml();
            root.AppendChild(doc.CreateElement("Vertical")).InnerXml = _page.GetVerticalItem().ToXml();
            root.AppendChild(doc.CreateElement("Factor")).InnerText = _page.GetFactor().ToString();
            root.AppendChild(doc.CreateElement("ValueItemX")).InnerText = _page.GetValueItem().X.ToString();
            root.AppendChild(doc.CreateElement("ValueItemY")).InnerText = _page.GetValueItem().Y.ToString();

            return root.OuterXml;
        }
    }
}
