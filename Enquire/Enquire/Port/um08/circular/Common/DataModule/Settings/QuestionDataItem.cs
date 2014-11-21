using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Compucare.Enquire.Common.DataModule.Computations;
using Compucare.Enquire.Common.DataModule.Xml;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;
using Compucare.Enquire.Legacy;

namespace Compucare.Enquire.Common.DataModule.Settings
{
    public class QuestionDataItem : IXmlTransformable
    {
        public const String TagRoot = "QuestionSettings";
        public const String TagQuestion = "QuestionId";
        public const String TagUserGroups = "UserGroups";
        public const String TagCross = "Cross";
        public const String TagCrossQuestion = "Question";
        public const String TagCrossAnswer = "Answer";
        public const String TagGroupId = "Group";
        public const String TagValueIndex = "ValueIndex";
        private readonly Evaluation _ev;
        private Int32 _questionId;
        private static Int32 _valueIndex;
        private PersonSetting[] _persons;
        

        public Int32 QuestionId { get { return _questionId; } }
        public PersonSetting[] Persons { get { return _persons; } }

        public Int32 QuestionCrossing { get; set; }
        public Boolean Cross { get; set; }
        public String CrossAnswer { get; set; }

        public QuestionDataItem(int qId, PersonSetting[] persons)
        {
            _questionId = qId;
            _persons = persons;
        }

        public QuestionDataItem(String xml, Evaluation eval)
        {
            _ev = eval;
            FromXml(xml, eval);
        }

        public QuestionDataItem()
        { 
            
        }

        public void setValueIndex(int value_index)
        {
            _valueIndex = value_index;
        }
        
        public Int32 GetValueIndex()
        {
            return _valueIndex;
        }

        public Int32 GetPersonId(Evaluation eval)
        {
            for (int i = 0; i < eval.CombinedPersons.Count(); i++)
            {
                if (eval.CombinedPersons[i] == Persons[0]) return i;
            }

            return -1;
        }

        /*
         * @return: NPS Berechnung in XML Format 
         */
        public string ToXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement(TagRoot));

            //comparativeBenchmarkvalue
            root.AppendChild(doc.CreateElement(TagQuestion)).InnerText = _questionId.ToString();
            XmlElement users = (XmlElement) root.AppendChild(doc.CreateElement(TagUserGroups));

            foreach (PersonSetting setting in _persons)
            {
                users.AppendChild(doc.CreateElement(TagGroupId)).InnerText = setting.ToString();
            }

           
            XmlElement cross = (XmlElement) root.AppendChild(doc.CreateElement(TagCross));
            cross.SetAttribute("enabled", Cross.ToString());
            
            if (Cross)
            {
                cross.AppendChild(doc.CreateElement(TagCrossQuestion)).InnerText = QuestionCrossing.ToString();
                XmlElement answer = (XmlElement) cross.AppendChild(doc.CreateElement(TagCrossAnswer));
                answer.AppendChild(doc.CreateCDataSection(CrossAnswer));
            }


            if (_valueIndex != 0)
            {
                XmlElement valueIn = (XmlElement)root.AppendChild(doc.CreateElement(TagValueIndex));
                valueIn.AppendChild(doc.CreateElement(TagValueIndex)).InnerText = Convert.ToString(_valueIndex);
            }
            
            
            return doc.OuterXml;
        }

        /**
         * 
         */
        public void FromXml(string xmlString, Evaluation eval)
        {
            // erstellt ein Xml Dokument
            XmlDocument doc = new XmlDocument();
            
            //wandelt xmlString in ein XmlDokument um
            doc.LoadXml(xmlString);

            //definiert den wurzel element
            XmlElement root = doc.DocumentElement;

            try
            {
                //holt sich valueindex aus xmlString
                _valueIndex = Int32.Parse(root.GetElementsByTagName(TagValueIndex)[0].InnerText);
            }
            catch
            {

            }

            //holt sich fragenIdxmlString
            _questionId = Int32.Parse(root.GetElementsByTagName(TagQuestion)[0].InnerText); 
            

            XmlElement users = (XmlElement)root.GetElementsByTagName(TagUserGroups)[0];
            

            List<PersonSetting> settings = new List<PersonSetting>();
            foreach (XmlElement userg in users.GetElementsByTagName(TagGroupId))
            {
                String usergString = userg.InnerText;

                foreach (PersonSetting ps in eval.CombinedPersons)
                {
                    if (ps.ToString() == usergString)
                    {
                        settings.Add(ps);
                        break;
                    }
                }
            }

            _persons = settings.ToArray();

            if (root.GetElementsByTagName(TagCross).Count > 0)
            {
                XmlElement cross = (XmlElement) root.GetElementsByTagName(TagCross)[0];
                Cross = Boolean.Parse(cross.GetAttribute("enabled"));

                if (Cross)
                {
                    QuestionCrossing = Int32.Parse(cross.GetElementsByTagName(TagCrossQuestion)[0].InnerText);

                    CrossAnswer = cross.GetElementsByTagName(TagCrossAnswer)[0].InnerText;

                }
            }
        }//FromXml

        public Double ComputeAverage(TargetData td, Evaluation eval)
        {
            return ComputeAverage(td, eval, -1);
        }

        public Double ComputeAverage(TargetData td, Evaluation eval, Int32 precision)
        {
            TargetData computeTd = td;
            
            if (Cross)
            {
                computeTd = CrossHelper.Cross(td, eval, QuestionCrossing, CrossAnswer, _questionId);
            }

            if (precision > 0)
            {
                return Math.Round(computeTd.GetQuestion(_questionId, eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[GetPersonId(eval)]), precision);
            }

            Question pqn = computeTd.GetQuestion(_questionId, eval);
            PersonSetting ps = eval.CombinedPersons[GetPersonId(eval)];
            //MessageBox.Show("Average: "+pqn.GetAverageByPersonAsMark(eval, ps).ToString());
            //double result = Math.Round(((5f - pqn.GetAverageByPersonAsMark(eval, ps)) / 4f) * 100, precision);

            return computeTd.GetQuestion(_questionId, eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[GetPersonId(eval)]);
        }

        public Double ComputeNps(TargetData td, Evaluation eval, Int32 precision)
        {
            TargetData computeTd = td;
            if (Cross)
            {
                computeTd = CrossHelper.Cross(td, eval, QuestionCrossing, CrossAnswer, _questionId);
            }
            
            Question pqn = computeTd.GetQuestion(_questionId, eval);
            PersonSetting ps = eval.CombinedPersons[GetPersonId(eval)];
            
            double pcnt1 = pqn.GetAnswerPercentByPerson(0, eval, ps);
            double pcnt3 = pqn.GetAnswerPercentByPerson(2, eval, ps);
            double pcnt4 = pqn.GetAnswerPercentByPerson(3, eval, ps);
            double pcnt5 = pqn.GetAnswerPercentByPerson(4, eval, ps);

            double nps = (pcnt1 - (pcnt3 + pcnt4 + pcnt5));

            return Math.Round(nps, precision);
        }

        public Double ComputePercent(TargetData td, Evaluation eval, Int32 precision)
        {
            MessageBox.Show("Computepercent");
            TargetData computeTd = td;
            if (Cross)
            {
                computeTd = CrossHelper.Cross(td, eval, QuestionCrossing, CrossAnswer, _questionId);
            }

            Question pqn = computeTd.GetQuestion(_questionId, eval);
            PersonSetting ps = eval.CombinedPersons[GetPersonId(eval)];

            return Math.Round(
                (
                    (5f -
                     pqn.GetAverageByPersonAsMark(
                         eval, ps)) / 4f) * 100, precision);
        }


        public Double ComputePercent2(TargetData td, Evaluation eval, Int32 precision)
        {
            TargetData computeTd = td;
            int totalresults = 0;
            Question pqn = null;
            double result = 0.0;

            if (Cross)
            {
                computeTd = CrossHelper.Cross2(td, eval, QuestionCrossing, CrossAnswer, _questionId);
                pqn = computeTd.GetQuestionbyId(QuestionCrossing, eval); //Zielteilung mit der Resultate der ausgewählten Antwort
            }
            else
            {
                pqn = computeTd.GetQuestion(_questionId, eval);
            }
            PersonSetting ps = eval.CombinedPersons[GetPersonId(eval)];

            if (Cross)
            {
                double allAnswersCount = 0.0;
                for (int i = 0; i < pqn.AnswerList.Length; i++)
                {
                    allAnswersCount += Math.Round(pqn.GetAveragePercentByPersonAsMark(eval, ps, pqn, pqn.AnswerList[i].ToString()), precision);
                }
                double crossAnswerCount = Math.Round(pqn.GetAveragePercentByPersonAsMark(eval, ps, pqn, CrossAnswer), precision);
                return (100 / allAnswersCount * crossAnswerCount);
            }else{
                result = Math.Round((
                    (5f -
                     pqn.GetAverageByPersonAsMark(
                         eval, ps)) / 4f) * 100, precision);
            }
            //MessageBox.Show(cross.AnswerList.Length.ToString());
            return result;
        }
    }
}
