using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.DataModule.Computations
{
    public static class CrossHelper
    {
        public static TargetData Cross2(TargetData td, Evaluation eval, Int32 crossQ, String crossAnswer, Int32 targetQ)
        {
            TargetData retVal = new TargetData("", Output.CleanString(td.Name + ", " + crossAnswer), "");
           
            Question cross = td.GetQuestion(crossQ, eval);

            int aid = 0;
            Boolean found = false;
            foreach (String a in cross.AnswerList)
            {
                if (a.Equals(crossAnswer))
                {
                    found = true;
                    break;
                }

                aid++;
            }
            

            if (!found) return null;

            List<Int32> uids = new List<Int32>();

            //MessageBox.Show("Anzahl der Resultate: " + cross.Results.Count.ToString());
            foreach (Result r in cross.Results)//durchlaeuft alle Ergebnisse der gekreuten Frage
			{
				if (cross.Equals("multi"))
				{
					foreach (string ra in r.TextAnswer.Split(';'))
					{
						if (ra.Equals(crossAnswer))
						{
							uids.Add(r.UserID);
							break;
						}
					}
				}
				else if (r.SelectedAnswer == aid || r.TextAnswer.Equals(crossAnswer))
				{
					uids.Add(r.UserID);
				}


			}//end foreach
            //MessageBox.Show("UID Count : " + uids.Count.ToString());

			retVal.Questions = new Question[1]; //neues Ziel erstellte Frage einfügen 

            foreach (Question q in td.Questions)
            {
                if (q.ID != targetQ)
                {
                    continue;
                }
                else
                {
                    Question nq = new Question(q); //Frage wird dupliziert
                    foreach (int uid in uids)
                    {
                        Result rs = q.GetResultByUserID(uid);
                        if (rs != null)
                        {
                            nq.Results.Add(rs.Copy);
                        }
                    }
                    retVal.Questions[0] = nq;
                }
            }
            //MessageBox.Show("Last: " + retVal.Questions[0].Results.Count.ToString());

            return retVal;
        }//


        public static TargetData Cross(TargetData td, Evaluation eval, Int32 crossQ, String crossAnswer, Int32 targetQ)
        {
            TargetData retVal = new TargetData("", Output.CleanString(td.Name + ", " + crossAnswer), "");

            Question cross = td.GetQuestion(crossQ, eval);

            int aid = 0;
            Boolean found = false;
            foreach (String a in cross.AnswerList)
            {
                if (a == crossAnswer)
                {
                    found = true;
                    break;
                }
                aid++;
            }

            if (!found) return null;

            List<Int32> uids = new List<Int32>();

            foreach (Result r in cross.Results)
            {
                if (cross.Equals("multi"))
                {
                    foreach (string ra in r.TextAnswer.Split(';'))
                    {
                        if (ra.Equals(crossAnswer))
                        {
                            uids.Add(r.UserID);
                            break;
                        }
                    }
                }
                else if (r.SelectedAnswer == aid || r.TextAnswer.Equals(crossAnswer))
                {
                    uids.Add(r.UserID);
                }
            }

            retVal.Questions = new Question[1];

            foreach (Question q in td.Questions)
            {
                if (q.ID != targetQ) continue;

                Question nq = new Question(q);
                foreach (int uid in uids)
                {
                    Result rs = q.GetResultByUserID(uid);
                    if (rs != null)
                        nq.Results.Add(rs.Copy);
                }
                retVal.Questions[0] = nq;
            }

            return retVal;
        }//end TargetData Cross2
    }
}
