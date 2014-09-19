using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Compucare.Enquire.System
{
    public class   QuestionSplit
    {
        public Question master;
        public Question splitter;

        public QuestionSplit(Question master, Question splitter)
        {
            this.master = master;
            this.splitter = splitter;
        }

        public Question[] ComputeQuestionSplits(Evaluation eval)
        {
            Question[] res = new Question[splitter.AnswerList.Length];
            int i = 0;

            foreach (string answer in splitter.AnswerList)
            {
                Question split = new Question(i, answer, master.Display, master.Answers, master.Shortcut, 0);

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

                
                foreach (int uid in UIDs)
                {
                    Result rs = master.GetResultByUserID(uid);
                    if (rs != null) split.Results.Add(new Result(rs.TextAnswer, rs.SelectedAnswer, rs.UserID));
                }


                res[i++] = split;
            }

            return res;
        }
    }
}
