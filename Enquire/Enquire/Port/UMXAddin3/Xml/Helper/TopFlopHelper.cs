using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Calculation.Texts.TopFlop;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Helper
{
    public class TopFlopHelper
    {
        private readonly Evaluation _eval;
        private readonly TargetData _td;
        private readonly PersonSetting _userg;
        private readonly PersonSetting _usergap;
        private readonly ResultOrdering _ordering;
        private readonly ResultSorting _sorting;
        private readonly ResultType _type;
        private readonly HistoricData _history;
        private readonly QuestionTopFlop _questiontopflop;

        public TopFlopHelper(Evaluation eval, 
            TargetData td, PersonSetting userg, PersonSetting usergap, ResultOrdering ordering, ResultSorting sorting,
            ResultType type, HistoricData history, QuestionTopFlop questiontopflop)
        {
            _eval = eval;
            _td = td;
            _userg = userg;
            _usergap = usergap;
            _ordering = ordering;
            _sorting = sorting;
            _type = type;
            _history = history;
            _questiontopflop = questiontopflop;
        }

        public List<TopFlopValue> GetOrderedList()
        {
            List<TopFlopValue> list = ComputeList();
            list.Sort(new TopFlopValueComparer());
            return list;
        }


        public List<TopFlopValue> ComputeList()
        {
            List<TopFlopValue> retVal = new List<TopFlopValue>();
            int counter = 0;
            /*try
            {
                MessageBox.Show("" + _td.getSelectedQuestions().Length);
            }
            catch
            {
                MessageBox.Show("Exception TopflopHelper");
            }*/
            
            foreach (Question q in _td.Questions)
            {
                counter++;
                if (q.Display != "radio")
                {
                    continue;
                }

                TopFlopValue val = new TopFlopValue();
                val.Id = q.SID;
                val.Text = q.Text;
                val.ordering = _ordering;
                val.sorting = _sorting;
                

                if (_type == ResultType.Averages)
                {
                    val.Value = q.GetAverageByPersonAsMark(_eval, _userg);
                    if (val.Value == -1) continue;
                }
                else
                {
                    float v1 = q.GetAverageByPersonAsMark(_eval, _userg);
                    float v2 = q.GetAverageByPersonAsMark(_eval, _usergap);

                    if (v1 == -1 || v2 == -1) continue;
                    val.Value = Math.Abs(v1 - v2);
                }

                if (_history != null)
                {
                    foreach (TargetData td in _history.Eval.Targets)
                    {
                        if (td.Name == _td.Name)
                        {
                            Question hq = td.GetQuestion(q, _history.Eval);
                            if (_type == ResultType.Averages)
                            {
                                val.HistValue = hq.GetAverageByPersonAsMark(_history.Eval, _userg);
                            }
                            else
                            {
                                float v1 = hq.GetAverageByPersonAsMark(_history.Eval, _userg);
                                float v2 = hq.GetAverageByPersonAsMark(_history.Eval, _usergap);

                                val.Value = Math.Abs(v1 - v2);
                            }
                        }
                    }

                    val.diff = val.Value - val.HistValue;
                }

                retVal.Add(val);
            }// end foreach
            return retVal;
        }
    }
}
