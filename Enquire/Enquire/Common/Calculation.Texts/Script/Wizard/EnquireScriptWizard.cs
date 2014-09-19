using System;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Texts.Script.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.Script.Wizard
{
    public class EnquireScriptWizard : BaseWizard
    {
        private readonly Evaluation _eval;
        private readonly TargetData _targetData;
        private readonly ExpressionWizardPage _expr;

        public EnquireScriptWizard(Evaluation eval, TargetData targetData)
        {
            _eval = eval;
            _targetData = targetData;

            Text = "Expression Wizard";

            PageHeadImage = Pictures.math;

            _expr = new ExpressionWizardPage(_eval,_targetData);
            _expr.AllowFinish = true;
            AddWizardPage(_expr);
        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "expression");

            root.AppendChild(doc.CreateElement("Expression")).InnerText = _expr.Expression;
            root.AppendChild(doc.CreateElement("UserGroup")).InnerText = _expr.UserGroup.ToString();

            return root.OuterXml;
        }
    }
}
