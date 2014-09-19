using System;
using System.Drawing;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Graves.Wizard.WizardPages;
using Compucare.Enquire.Common.Calculation.Template.Wizard;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.Graves.Wizard
{
    public class GravesWizard : BaseWizard
    {
        public static String TEMPLATE_IDENTIFIER = "graves";

        private readonly Evaluation _eval;

        private readonly TemplateWizardPage _template;

        private readonly GravesWizardPage _page1;
        private readonly GravesWizardPage _page2;
        private readonly GravesWizardPage _page3;
        private readonly GravesWizardPage _page4;
        private readonly GravesWizardPage _page5;
        private readonly GravesWizardPage _page6;
        private readonly GravesWizardPage _page7;
        private readonly GravesWizardPage _page8;

        public GravesWizard(Evaluation eval)
        {
            _eval = eval;

            _template = new TemplateWizardPage("Spiral: Template Settings", TEMPLATE_IDENTIFIER);
            AddWizardPage(_template);

            _page1 = new GravesWizardPage(_eval, Color.FromArgb(100,0, 93, 168), "Top Level");
            _page1.Header += " - Top Level";
            AddWizardPage(_page1);

            _page2 = new GravesWizardPage(_eval, Color.FromArgb(100, 255, 237, 0), "Second Level");
            _page2.Header += " - Second Level";
            AddWizardPage(_page2);

            _page3 = new GravesWizardPage(_eval, Color.FromArgb(100, 56, 169, 98), "Third Level");
            _page3.Header += " -Third Level";
            AddWizardPage(_page3);

            _page4 = new GravesWizardPage(_eval, Color.FromArgb(100, 105, 139, 113), "Fourth Level");
            _page4.Header += " - Fourth Level";
            AddWizardPage(_page4);

            _page5 = new GravesWizardPage(_eval, Color.FromArgb(100, 14, 114, 181), "Fifth Level");
            _page5.Header += " - Fifth Level";
            AddWizardPage(_page5);

            _page6 = new GravesWizardPage(_eval, Color.FromArgb(100, 204, 7, 30), "Sixth Level");
            _page6.Header += " - Sixth Level";
            AddWizardPage(_page6);

            _page7 = new GravesWizardPage(_eval, Color.FromArgb(100, 192, 0, 123), "Seventh Level");
            _page7.Header += " - Seventh Level";
            AddWizardPage(_page7);

            _page8 = new GravesWizardPage(_eval, Color.FromArgb(100, 179, 156, 104), "Bottom Level");
            _page8.Header += " - Bottom Level";
            _page8.AllowFinish = true;
            AddWizardPage(_page8);

        }

        protected override void OnBeforeNext()
        {
            if (CurrentPage == _template)
            {
                if (_template.LoadFromFile)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_template.LoadPath);
                    FromXml(doc);
                }
            }
        }
      

        private void FromXml(XmlDocument doc)
        {
            XmlElement dataItem = doc.DocumentElement;
            _page1.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level1")[0]);
            _page2.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level2")[0]);
            _page3.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level3")[0]);
            _page4.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level4")[0]);
            _page5.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level5")[0]);
            _page6.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level6")[0]);
            _page7.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level7")[0]);
            _page8.LoadFromXml((XmlElement)dataItem.GetElementsByTagName("Level8")[0]);
        }

        private XmlDocument GetXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", TEMPLATE_IDENTIFIER);

            root.AppendChild(doc.CreateElement("Level1")).InnerXml = _page1.GetXml();
            root.AppendChild(doc.CreateElement("Level2")).InnerXml = _page2.GetXml();
            root.AppendChild(doc.CreateElement("Level3")).InnerXml = _page3.GetXml();
            root.AppendChild(doc.CreateElement("Level4")).InnerXml = _page4.GetXml();
            root.AppendChild(doc.CreateElement("Level5")).InnerXml = _page5.GetXml();
            root.AppendChild(doc.CreateElement("Level6")).InnerXml = _page6.GetXml();
            root.AppendChild(doc.CreateElement("Level7")).InnerXml = _page7.GetXml();
            root.AppendChild(doc.CreateElement("Level8")).InnerXml = _page8.GetXml();

            return doc;
        }

        public String GetXml()
        {
            return GetXmlDocument().OuterXml;
        }

        protected override void OnFinish()
        {
            if (_template.SaveToFile)
            {
                GetXmlDocument().Save(_template.SavePath);
            }
        }
    }
}
