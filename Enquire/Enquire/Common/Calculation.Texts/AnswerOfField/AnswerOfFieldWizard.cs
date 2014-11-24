using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;
using Compucare.Enquire.Common.Calculation.Texts.Sokd.Wizard;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Xml;

namespace Compucare.Enquire.Common.Calculation.Texts.AnswerOfField
{
    public class AnswerOfFieldWizard : BaseWizard
    {
        private readonly AnswerOfFieldPage _page;

        public AnswerOfFieldWizard(Evaluation eval)
        {
            PageHeadImage = Pictures.gap32_2;
            //Text = "Antworttext von Fragen";
            _page = new AnswerOfFieldPage(eval);
            AddWizardPage(_page);

            _page.AllowNext = true;
            _page.AllowBack = true;
            _page.AllowFinish = true;        
        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "answerOfField");
            root.AppendChild(doc.CreateElement("Value")).InnerXml = _page.GetItem();
            return root.OuterXml;
        }
    }
}
