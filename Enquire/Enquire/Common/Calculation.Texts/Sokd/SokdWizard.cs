using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Common.Calculation.Texts.Sokd.Wizard;
using System.Xml;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;



namespace Compucare.Enquire.Common.Calculation.Texts.Sokd
{
    public class SokdWizard : BaseWizard
    {
        private readonly SokdWizardPage _page;
       

        public SokdWizard(Evaluation eval)
        {
            PageHeadImage = Pictures.sokd;
            Text = "SOKD Wizard";
            _page = new SokdWizardPage(eval);
            AddWizardPage(_page);

            _page.AllowNext = true;
            _page.AllowBack = true;
            _page.AllowFinish = true;        
        }

        public bool GetTypeofSokd()
        {
            return _page.GetTypeofSokd();
        }



        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "sokd");
            root.AppendChild(doc.CreateElement("Value")).InnerXml = _page.GetItem();
            return root.OuterXml;
        }

    }
}
