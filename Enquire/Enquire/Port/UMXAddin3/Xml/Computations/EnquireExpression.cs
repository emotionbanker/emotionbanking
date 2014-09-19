using System;
using System.Xml;
using Compucare.Enquire.Legacy.Umfrage2Lib.Script;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class EnquireExpression : IXmlText
    {
        private readonly XmlDocument _doc;
        private readonly TargetData _td;
        private readonly Evaluation _eval;

        public EnquireExpression(XmlDocument doc, TargetData td, Evaluation eval)
        {
            _doc = doc;
            _td = td;
            _eval = eval;
        }

        public string Compute()
        {
            String expression = XmlHelper.GetInnerText(_doc.DocumentElement, "Expression");

            String usergString = XmlHelper.GetInnerText(_doc.DocumentElement, "UserGroup");

            PersonSetting userg = null;
            foreach (PersonSetting ps in _eval.CombinedPersons)
            {
                if (ps.ToString() == usergString)
                {
                    userg = ps;
                    break;
                }
            }

            EnquireScript script = new EnquireScript(_eval, _td);
            script.SetUserGroup(userg);
            return script.Evaluate(expression);
        }
    }
}
