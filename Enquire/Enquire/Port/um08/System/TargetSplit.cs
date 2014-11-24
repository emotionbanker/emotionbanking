using System;
using System.Collections;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
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

        public TargetData[] ComputeSplitTargetOpen(Evaluation eval)
        {
            TargetData[] res = null;
            return res;
        }

        public TargetData[] ComputeSplitTarget(Evaluation eval)
        {
            bool ok = false;

            TargetData[] res = null;
            try
            {
                res = new TargetData[splitter.AnswerList.Length]; //anzahl der Zieldaten ist gleich anzahl der Anworten 
                int i = 0;

                splitter = master.GetQuestion(splitter, eval); //Frage wird aus Eval geholt
                if (splitter == null)
                {
                    splitter = master.GetQuestionbyId(splitter.ID, eval);
                    ok = true;
                }

                //MessageBox.Show(splitter.AnswerList.Length.ToString());
                //MessageBox.Show("Question: "+splitter.Text+"\nListengroese: "+splitter.AnswerList.Length);
                foreach (string answer in splitter.AnswerList)//durchauft alle Antworten
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
                        Question nq = new Question(q);
                        foreach (int uid in UIDs)
                        {
                            Result rs = q.GetResultByUserID(uid);
                            if (rs != null) nq.Results.Add(rs.Copy);
                        }
                        split.Questions[j++] = nq;
                    }

                    //MessageBox.Show("Childsplits: "+ChildSplits.Count);
                    split.Splits = ChildSplits;

                    split.masterSplit = this;

                    if (ok == false)
                    {
                        split.ComputeSplits(eval);
                    }


                    res[i++] = split;


                }//end foreach

                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }//end ComputeSplitTarget


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eval"></param>
        /// <returns>TargetData</returns>
        public TargetData[] ComputeSplitTarget_Original(Evaluation eval)
        {
            TargetData[] res = null;
            try
            {
                res = new TargetData[splitter.AnswerList.Length];
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
                        Question nq = new Question(q);
                        foreach (int uid in UIDs)
                        {
                            Result rs = q.GetResultByUserID(uid);
                            if (rs != null) nq.Results.Add(rs.Copy);
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
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message+"\n"+ex.StackTrace);
                return res;
            }
        }//end ComputeSplitTarget
    }
}
