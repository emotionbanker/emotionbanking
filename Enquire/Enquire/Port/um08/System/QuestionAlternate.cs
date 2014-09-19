using System;
using System.Collections;
using System.Runtime.Serialization;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
    /// <summary>
    /// Summary description for QuestionCombo.
    /// </summary>
    /// 
    [Serializable]
    public class QuestionAlternate : ISerializable
    {
        public int Master;
        public int[] QuestionList;

        public string Text;
        private Evaluation eval;

        public QuestionAlternate(Evaluation eval)
        {
            Master = -1;
            QuestionList = new int[0];
            Text = string.Empty;
            this.eval = eval;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("QuestionList", QuestionList);
            info.AddValue("Text", Text);
            info.AddValue("eval", eval);
            info.AddValue("Master", Master);
        }

        public QuestionAlternate(SerializationInfo info, StreamingContext ctxt)
        {
            this.QuestionList = (int[])info.GetValue("QuestionList", typeof(int[]));
            this.Text = info.GetString("Text");
            this.eval = (Evaluation)info.GetValue("eval", typeof(Evaluation));
            this.Master = info.GetInt32("Master");
        }

        public void AddID(int id)
        {
            Console.WriteLine("[ADDID]\toldlen=" + QuestionList.Length);
            foreach (int i in QuestionList)
                if (i == id)
                    return;

            int[] nq = new int[QuestionList.Length + 1];

            int c = 0;
            foreach (int i in QuestionList)
            {
                nq[c++] = i;
            }
            nq[c] = id;

            QuestionList = nq;

            Console.WriteLine("[ADDID]\tadded " + id);
            Console.WriteLine("[ADDID]\tnewlen=" + QuestionList.Length);
        }

        public void RemoveID(int id)
        {
            bool inc = false;
            foreach (int i in QuestionList)
                if (i == id)
                    inc = true;

            if (!inc)
                return;

            int[] nq = new int[QuestionList.Length - 1];

            int c = 0;
            foreach (int i in QuestionList)
            {
                if (i != id)
                    nq[c++] = i;
            }

            QuestionList = nq;
        }

        public Question GetCombo(TargetData td)
        {
            if (QuestionList.Length == 0)
                return null;

            int i;
            Question quest = Question.Create((Master * -1) - 5000, Text, "", "", "", 0);

            ArrayList answers = new ArrayList();

            int[] QList = new int[QuestionList.Length + 1];
            for (i = 0; i < QuestionList.Length; i++) QList[i+1] = QuestionList[i];
            QList[0] = Master;

            for (i = 0; i < QList.Length; i++)
            {
                Console.WriteLine("[ALTERNATE]\tcombining " + QList[i]);
                Question q = td.GetQuestion(QList[i], eval);

                if (q == null) continue;

                foreach (string a in q.AnswerList)
                    if (!answers.Contains(a.ToLower()))
                        answers.Add(a.ToLower());

                foreach (Result r in q.Results)
                {
                    int sel = r.SelectedAnswer;
                    if (r.SelectedAnswer != -1)
                    {
                        string ra = q.AnswerList[r.SelectedAnswer].ToLower();

                        int an = 0;
                        foreach (string a in answers)
                        {
                            if (a.ToLower().Equals(ra)) break;
                            an++;
                        }

                        sel = an;
                    }
                    quest.Results.Add(r.Copy);
                }

                quest.Display = q.Display;
            }

            quest.Answers = string.Empty;
            for (int j = 0; j < answers.Count; j++)
            {
                quest.Answers += answers[j];
                if (j < answers.Count - 1)
                    quest.Answers += ";";
            }

            return quest;
        }


        public Question GetQuestion(TargetData td)
        {
            return GetCombo(td);

        }

        public override string ToString()
        {
            string r = "A" + Master;
            
            foreach (int q in this.QuestionList)
                r += "/" + q;

            r += " (" + Text + ")";

            return r;
        }

        public void Debug(string msg)
        {
            string s = "[" + msg.ToUpper() + "]\tA" + Master + " --> ";
            foreach (int i in QuestionList)
                s += i + "/";
            Console.WriteLine(s);
        }

    }
}
