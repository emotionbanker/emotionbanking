using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Texts.AnswerOfField;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class AnswerOfField : IXmlText  
    {
        private readonly Evaluation _eval;
        private readonly XmlDocument _doc;
        private readonly TargetData _td;

        public AnswerOfField(Evaluation eval, XmlDocument doc, TargetData td)
        {
            this._eval = eval;
            this._doc = doc;
            this._td = td;
        }

        public string Compute()
        {

            try
            {
                String p = XmlHelper.GetInnerText(_doc.DocumentElement, "Personengruppe");
                Int32 qId = Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement, "Frage"));

                Question q = _td.GetQuestion(qId, _eval);
                //MessageBox.Show("Zielbank: "+_td.Name+"\nAnzahl der Resultate: "+q.Results.Count);

                PersonSetting personS = null;

                foreach (PersonSetting ps in _eval.CombinedPersons)
                {
                    if (ps.ToString() == p)
                    {
                        personS = ps;
                        break;
                    }
                }

                if (personS == null) return "k.A.";

                if (q.Display.Equals("text"))
                {
                    string ret = "";
                    if (personS.GetType() == typeof(Person))
                    {
                        Person person = (Person)personS;
                        foreach (Result r in q.Results)
                        {
                            if (_eval.GetPersonIdByUser(r.UserID) == person.ID)
                            {
                                ret += r.TextAnswer + "\n";
                            }
                        }
                        return ret;
                    }
                    else
                    {
                        PersonCombo combo = (PersonCombo)personS;
                        foreach (Result r in q.Results)
                        {
                            if (combo.ContainsID(_eval.GetPersonIdByUser(r.UserID)))
                            {
                                ret += r.TextAnswer + "\n";
                            }
                        }
                        return ret;
                    }
                }
                else if (q.Display.Equals("radio"))
                {
                    int[] answerCount = new int[q.AnswerList.Length];
                    if (personS.GetType() == typeof(Person))
                    {
                        Person person = (Person)personS;

                        foreach (Result r in q.Results)
                        {
                            if (_eval.GetPersonIdByUser(r.UserID) == person.ID)
                            {
                                answerCount[r.SelectedAnswer]++;
                                //return q.AnswerList[r.SelectedAnswer].ToString();
                            }//end if
                        }//end foreach

                        //finde im array maxCount und retourniere
                        int maxValue = answerCount.Max();
                        int maxIndex = answerCount.ToList().IndexOf(maxValue);

                        return q.AnswerList[maxIndex].ToString();
                    }
                    else
                    {
                        PersonCombo combo = (PersonCombo)personS;
                        foreach (Result r in q.Results)
                        {
                            if (combo.ContainsID(_eval.GetPersonIdByUser(r.UserID)))
                            {
                                //return q.AnswerList[r.SelectedAnswer].ToString();
                                answerCount[r.SelectedAnswer - 1]++;
                            }//end if
                        }//end foreach
                        int maxValue = answerCount.Max();
                        int maxIndex = answerCount.ToList().IndexOf(maxValue);
                        return q.AnswerList[maxIndex].ToString();
                    }//end else
                }
                else if (q.Display.Equals("multi"))
                {
                    string ret = "";
                    if (personS.GetType() == typeof(Person))
                    {
                        Person person = (Person)personS;
                        foreach (Result r in q.Results)
                        {
                            if (_eval.GetPersonIdByUser(r.UserID) == person.ID)
                            {
                                string[] split = r.TextAnswer.Split(';');
                                foreach (string sp in split)
                                    ret += sp + "\n";
                            }
                        }
                        return ret;
                    }
                    else
                    {
                        PersonCombo combo = (PersonCombo)personS;
                        foreach (Result r in q.Results)
                        {
                            if (combo.ContainsID(_eval.GetPersonIdByUser(r.UserID)))
                            {
                                string[] split = r.TextAnswer.Split(';');
                                foreach (string sp in split)
                                    ret += sp + "\n";
                            }
                        }
                        return ret;
                    }
                }//end elseif
                return "k.A.";
            }
            catch(Exception e)
            {
                return "k.A.";
            }
        }//end Compute
    }
}
