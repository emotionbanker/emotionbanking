using System;
using System.Collections.Generic;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Texts.TopFlop.Wizard.WizardPages;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.TopFlop.Wizard
{
    public class TopFlopWizard : BaseWizard
    {
        private readonly Evaluation _eval;

        private readonly TopFlopSettingsWizardPage _settings;

        public Int32 Columns
        {
            get
            {
                if (_settings.ResultSorting == ResultSorting.CurrentOnly)
                {
                    return 2;
                }
                else
                {
                    return 4;
                }
            }
        }

        public TopFlopWizard(Evaluation eval)
        {
            _eval = eval;

            PageHeadImage = Pictures.insert_table;

            Text = "Top/Flop Wizard";

            _settings = new TopFlopSettingsWizardPage(_eval);
            _settings.AllowFinish = true;
            AddWizardPage(_settings);
        }

        public List<List<String>> GetXml()
        {
            List<List<String>> retVal = new List<List<string>>();

            for (int i = 0; i < _settings.NumResults; i++)
            {
                switch (_settings.ResultSorting)
                {
                    case ResultSorting.CurrentOnly:
                        retVal.Add(new List<string>
                                       {
                                           GetTextXml(_settings.ResultOrdering, i, _settings.ResultType, _settings.ResultSorting,_settings.QuestionTopFlop),
                                           GetCurrentXml(_settings.ResultOrdering, i, _settings.ResultType, _settings.ResultSorting,_settings.QuestionTopFlop)
                                       });
                        break;

                    default:
                        retVal.Add(new List<string>
                                       {
                                           GetTextXml(_settings.ResultOrdering, i, _settings.ResultType, _settings.ResultSorting,_settings.QuestionTopFlop),
                                           GetCurrentXml(_settings.ResultOrdering, i, _settings.ResultType, _settings.ResultSorting,_settings.QuestionTopFlop),
                                           GetHistoricXml(_settings.ResultOrdering, i, _settings.ResultType, _settings.ResultSorting, _settings.QuestionTopFlop),
                                           GetChangeXml(_settings.ResultOrdering, i, _settings.ResultType, _settings.ResultSorting,_settings.QuestionTopFlop)
                                       });
                        break;
                }
            }

            return retVal;
        }

        private String GetTextXml(ResultOrdering ordering,
            Int32 pos,
            ResultType resultType,
            ResultSorting sorting, QuestionTopFlop topflop)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "topflop");

            root.AppendChild(doc.CreateElement("topflopType")).InnerText = "TEXT";
            root.AppendChild(doc.CreateElement("ResultSorting")).InnerText = Enum.GetName(typeof(ResultSorting), sorting);
            root.AppendChild(doc.CreateElement("ResultOrdering")).InnerText = Enum.GetName(typeof(ResultOrdering), ordering);
            root.AppendChild(doc.CreateElement("Position")).InnerText = pos.ToString();
            root.AppendChild(doc.CreateElement("ResultType")).InnerText = Enum.GetName(typeof(ResultType), resultType);
            root.AppendChild(doc.CreateElement("UserGroup")).InnerText = _settings.UserGroup.ToString();
            root.AppendChild(doc.CreateElement("GapUserGroup")).InnerText = _settings.GapUserGroup != null
                                                                                ? _settings.GapUserGroup.ToString()
                                                                                : "";
            root.AppendChild(doc.CreateElement("History")).InnerText = _settings.History != null ?  _settings.History .ToString() : "";
            root.AppendChild(doc.CreateElement("TopFlopQuestion")).InnerText = Enum.GetName(typeof(QuestionTopFlop), topflop);

            return root.OuterXml;
        }

        private String GetChangeXml(ResultOrdering ordering,
            Int32 pos,
            ResultType resultType,
            ResultSorting sorting, QuestionTopFlop topflop)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "topflop");
            root.AppendChild(doc.CreateElement("topflopType")).InnerText = "CHANGE";
            root.AppendChild(doc.CreateElement("ResultSorting")).InnerText = Enum.GetName(typeof(ResultSorting), sorting);
            root.AppendChild(doc.CreateElement("ResultOrdering")).InnerText = Enum.GetName(typeof(ResultOrdering), ordering);
            root.AppendChild(doc.CreateElement("Position")).InnerText = pos.ToString();
            root.AppendChild(doc.CreateElement("ResultType")).InnerText = Enum.GetName(typeof (ResultType), resultType);
            root.AppendChild(doc.CreateElement("UserGroup")).InnerText = _settings.UserGroup.ToString();
            root.AppendChild(doc.CreateElement("GapUserGroup")).InnerText = _settings.GapUserGroup != null
                                                                                ? _settings.GapUserGroup.ToString()
                                                                                : "";
            root.AppendChild(doc.CreateElement("History")).InnerText = _settings.History != null ? _settings.History.ToString() : "";
            root.AppendChild(doc.CreateElement("TopFlopQuestion")).InnerText = Enum.GetName(typeof(QuestionTopFlop), topflop);

            return root.OuterXml;
        }

        private String GetHistoricXml(ResultOrdering ordering,
            Int32 pos,
            ResultType resultType,
            ResultSorting sorting, QuestionTopFlop topflop)
        {
             XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "topflop");

            root.AppendChild(doc.CreateElement("topflopType")).InnerText = "HISTORIC";

            root.AppendChild(doc.CreateElement("ResultSorting")).InnerText = Enum.GetName(typeof(ResultSorting), sorting);
            root.AppendChild(doc.CreateElement("ResultOrdering")).InnerText = Enum.GetName(typeof(ResultOrdering), ordering);
            root.AppendChild(doc.CreateElement("Position")).InnerText = pos.ToString();
            root.AppendChild(doc.CreateElement("ResultType")).InnerText = Enum.GetName(typeof (ResultType), resultType);
            root.AppendChild(doc.CreateElement("UserGroup")).InnerText = _settings.UserGroup.ToString();
            root.AppendChild(doc.CreateElement("GapUserGroup")).InnerText = _settings.GapUserGroup != null
                                                                                ? _settings.GapUserGroup.ToString()
                                                                                : "";
            root.AppendChild(doc.CreateElement("History")).InnerText = _settings.History != null ? _settings.History.ToString() : "";
            root.AppendChild(doc.CreateElement("TopFlopQuestion")).InnerText = Enum.GetName(typeof (QuestionTopFlop), topflop);

            return root.OuterXml;
        }

        private String GetCurrentXml(ResultOrdering ordering,
            Int32 pos,
            ResultType resultType,
            ResultSorting sorting,QuestionTopFlop topflop)
        
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", "topflop");

            root.AppendChild(doc.CreateElement("topflopType")).InnerText = "CURRENT";

            root.AppendChild(doc.CreateElement("ResultSorting")).InnerText = Enum.GetName(typeof(ResultSorting), sorting);
            root.AppendChild(doc.CreateElement("ResultOrdering")).InnerText = Enum.GetName(typeof(ResultOrdering), ordering);
            root.AppendChild(doc.CreateElement("Position")).InnerText = pos.ToString();
            root.AppendChild(doc.CreateElement("ResultType")).InnerText = Enum.GetName(typeof (ResultType), resultType);
            root.AppendChild(doc.CreateElement("UserGroup")).InnerText = _settings.UserGroup.ToString();
            root.AppendChild(doc.CreateElement("GapUserGroup")).InnerText = _settings.GapUserGroup != null
                                                                                ? _settings.GapUserGroup.ToString()
                                                                                : "";
            root.AppendChild(doc.CreateElement("TopFlopQuestion")).InnerText = Enum.GetName(typeof(QuestionTopFlop), topflop);

            return root.OuterXml;
        }
    }
}
