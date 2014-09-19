using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Compucare.Enquire.System
{
    [Serializable]
    public class TargetSplit
    {
        public TargetData master;
        public Question splitter;
        public ArrayList ChildSplits;

        public TargetSplit(TargetData master, Question splitter)
        {
            this.master = master;
            this.splitter = splitter;

            ChildSplits = new ArrayList();
        }

        public override string ToString()
        {
            return master.Name + "/" + splitter.SID;
        }
        
        public TargetData[] ComputeSplitTarget(Evaluation eval)
        {
            TargetData[] res = new TargetData[splitter.AnswerList.Length];
            int i = 0;

            splitter = master.GetQuestion(splitter, eval);

            foreach (string answer in splitter.AnswerList)
            {
                TargetData split = new TargetData(master.ID + "_" + splitter.SID + "_" + i, master.Name + "_" + splitter.SID + "_" + answer, master.Class);

                ArrayList UIDs = new ArrayList();
                foreach (Result r in splitter.Results)
                {
                    if (splitter.Display.Equals("multi"))
                    {
                        foreach (string ra in r.TextAnswer.Split(';'))
                        {
                            if (ra.Equals(answer))
                            {
                                UIDs.Add(r.UserID);
                                break;
                            }
                        }
                    }
                    else if (r.SelectedAnswer == i || r.TextAnswer.Equals(answer))
                    {
                        UIDs.Add(r.UserID);
                    }
                }

                split.Questions = new Question[master.Questions.Length];

                int j = 0;
                foreach (Question q in master.Questions)
                {
                    Question nq = new Question(q.ID, q.Text, q.Display, q.Answers, q.Shortcut, 0);
                    foreach (int uid in UIDs)
                    {
                        Result rs = q.GetResultByUserID(uid);
                        if (rs != null) nq.Results.Add(new Result(rs.TextAnswer, rs.SelectedAnswer, rs.UserID));
                    }
                    split.Questions[j++] = nq;
                }

                split.Splits = ChildSplits;
                
                split.masterSplit = this;
                
                split.ComputeSplits(eval);

                res[i++] = split;

                
            }

            return res;
        }
    }
}
