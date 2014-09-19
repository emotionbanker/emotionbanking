using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Texts.TopFlop;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Legacy.UMXAddin3.Xml.Helper;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class TopFlopItem : IXmlText
    {
        private readonly XmlDocument _doc;
        private readonly TargetData _td;
        private readonly Evaluation _eval;

        public TopFlopItem(XmlDocument doc, TargetData td, Evaluation eval)
        {
            _doc = doc;
            _td = td;
            _eval = eval;
        }

        public string Compute()
        {
            Int32 pos = Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement, "Position"));
            String topFlopType = XmlHelper.GetInnerText(_doc.DocumentElement, "topflopType");
            ResultSorting sorting = (ResultSorting)Enum.Parse(typeof(ResultSorting), XmlHelper.GetInnerText(_doc.DocumentElement, "ResultSorting"));
            ResultOrdering ordering = (ResultOrdering)Enum.Parse(typeof(ResultOrdering), XmlHelper.GetInnerText(_doc.DocumentElement, "ResultOrdering"));
            ResultType type = (ResultType)Enum.Parse(typeof(ResultType), XmlHelper.GetInnerText(_doc.DocumentElement, "ResultType"));
            QuestionTopFlop questionTopflop = (QuestionTopFlop)Enum.Parse(typeof(QuestionTopFlop), XmlHelper.GetInnerText(_doc.DocumentElement, "TopFlopQuestion"));
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

            String usergapString = XmlHelper.GetInnerText(_doc.DocumentElement, "GapUserGroup");
            PersonSetting usergap = null;
            foreach (PersonSetting ps in _eval.CombinedPersons)
            {
                if (ps.ToString() == usergapString)
                {
                    usergap = ps;
                    break;
                }
            }

            HistoricData history = null;
            try
            {

                String historyString = XmlHelper.GetInnerText(_doc.DocumentElement, "History");


                foreach (HistoricData hd in _eval.History)
                {
                    if (hd.ToString() == historyString)
                    {
                        history = hd;
                        break;
                    }
                }
            }
            catch (Exception) { } //no history




            //compute lists
            TopFlopHelper helper = new TopFlopHelper(_eval, _td, userg, usergap, ordering, sorting, type, history, questionTopflop);
            List<TopFlopValue> list = helper.GetOrderedList();

            TopFlopValue val = list[pos];
            switch (topFlopType)
            {
                case "CURRENT":
                    return Math.Round(val.Value, 2).ToString();
                    break;
                case "HISTORIC":
                    return Math.Round(val.HistValue, 2).ToString();
                    break;
                case "CHANGE":
                    return Math.Round(val.diff, 2).ToString();
                    break;
                case "TEXT":
                    return val.Text;
                    break;
            }

            return "n.A.";
        }
    }
}
