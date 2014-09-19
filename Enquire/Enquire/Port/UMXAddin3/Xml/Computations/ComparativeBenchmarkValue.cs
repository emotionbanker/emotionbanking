using System;
using System.Drawing;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Benchmarking;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Common.Calculation.Texts.Benchmarking.Wizard.WizardPages;
using Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages;
using System.Windows.Forms;
using System.Collections;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class ComparativeBenchmarkValue : IXmlText
    {
        private readonly Evaluation _eval;
        private readonly XmlDocument _doc;
        private readonly TargetData _td;
        public Size Size { get; set; }
        private int QuestionListLength = 0;
        

        public ComparativeBenchmarkValue(Evaluation eval, XmlDocument doc, TargetData td)
        {
            _eval = eval;
            _doc = doc;
            _td = td;
        }

        public string Compute()
        {
            QuestionDataItem item = XmlHelper.GetQuestion(_doc.DocumentElement, "Comparison", _eval);
            Benchmarking bm = new Benchmarking();
           
            Question allQ = _td.GetQuestion(item.QuestionId, _eval);
            
            Question splitQ = _td.GetQuestion(item.QuestionCrossing, _eval);
            
            bm.Evaluation = _eval;

            bm.OwnValue = allQ.GetAverageByPersonAsMark(_eval, item.Persons[0]);

            if (allQ.IsCombo) 
            {
                QuestionCombo combo = _td.GetCombo(allQ.ID,_eval);
                QuestionListLength = combo.QuestionListCount();
                bm.Average = GetAvgCombo(item.CrossAnswer, allQ, splitQ, item.Persons[0], QuestionListLength);
            }
            else
            {
                bm.Average = GetAvg(item.CrossAnswer, allQ, splitQ, item.Persons[0]);
            }
            
            bm.HistoricBest = float.MaxValue;
            bm.HistoricWorst = float.MinValue;
            foreach (String answer in splitQ.AnswerList)
            {
                float val;
                if (allQ.IsCombo)
                    val = GetAvgCombo(answer, allQ, splitQ, item.Persons[0],QuestionListLength);
                else
                    val = GetAvg(answer, allQ, splitQ, item.Persons[0]);

                if (val == -1)
                {
                    continue;
                }

                if (val > bm.HistoricWorst)
                {
                    bm.HistoricWorst = val;
                }
                if (val < bm.HistoricBest)
                {
                    bm.HistoricBest = val;
                }
            }

            bm.BestValue = 10;
            bm.WorstValue = 10;
            double wert=0.0;

            //string tmp = "Neu\nHistorisch Best: " + Math.Round(bm.HistoricBest, 1) + "\nHistorisch Worst: " + Math.Round(bm.HistoricWorst, 1) + "\nEigener Wert: " + Math.Round(bm.OwnValue, 1) + "\nDurchschnit: " + Math.Round(bm.Average, 1);
            if (item.GetValueIndex() == 1)
            {
                wert = Math.Round(bm.HistoricBest, 1);
            }
            else if (item.GetValueIndex() == 2)
            {
                wert = Math.Round(bm.HistoricWorst, 1);
            }
            else if (item.GetValueIndex() == 3)
            {
                wert = Math.Round(bm.OwnValue, 1);
            }
            else if (item.GetValueIndex() == 4)
            {
                wert = Math.Round(bm.Average, 1);
            }
            else
            {
                return "null";
            }

            item.setValueIndex(0);
            //MessageBox.Show(tmp);
            return wert.ToString();
             
        }

        private float GetAvgCombo(String answerSplit, Question q1, Question splitQ, PersonSetting ps, int counter)
        {
            float d = 0, count = 0;
            int id = splitQ.GetAnswerId(answerSplit);

            Result [] results =  splitQ.GetResultsByPerson(ps, _eval);

            foreach (Result r in results)
            {
                if (r.SelectedAnswer != id)
                {
                    continue;
                }

             

                for (int i = 1; i <= counter; i++)
                {
                    float res = q1.GetResultByUserIDCombo(r.UserID, i) != null ? q1.GetResultByUserIDCombo(r.UserID,i).SelectedAnswer : -1;

                    if (res != -1 && res < 5)
                    {
                        d += res;
                        count++;
                    }
                }//end for
            }//end foreach

            return count > 0 ? (d/count)+1 : -1;
        }//end GetAvgCombo

        private float GetAvg(String answerSplit, Question q1, Question splitQ, PersonSetting ps)
        {
            float d = 0, count = 0;
            int id = splitQ.GetAnswerId(answerSplit);

            foreach (Result r in splitQ.GetResultsByPerson(ps, _eval))
            {
                if (r.SelectedAnswer != id)
                {
                    continue;
                }

                float res = q1.GetResultByUserID(r.UserID) != null ? q1.GetResultByUserID(r.UserID).SelectedAnswer : -1;

                if (res != -1 && res < 5)
                {
                    d += res;
                    count++;
                }

            }
            return count > 0 ? (d / count) + 1 : -1;
        }//GetAvg

    }//end class
}//end namespace
