using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for QuestionCombo.
	/// </summary>
	/// 
	[Serializable]
	public class QuestionCombo : ISerializable
	{
		public const int TYPE_COMBO = 0;
		public const int TYPE_SPLIT = 1;
        public const int TYPE_ACOMB = 2;

		public int[] QuestionList;

        public Hashtable ACombTable;

		public string Text;

		public int ID;

		private Evaluation eval;

		public int Type = 0;
		public int SplitInterval = 1;

		public QuestionCombo(Evaluation eval)
		{
			QuestionList = new int[0];
            ACombTable = new Hashtable();
			Text = string.Empty;
			ID = 0;
			this.eval = eval;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("QuestionList", QuestionList);
			info.AddValue("Text", Text);
			info.AddValue("ID", ID);
			info.AddValue("eval", eval);
			info.AddValue("Type", Type);
			info.AddValue("SplitInterval", this.SplitInterval);
            info.AddValue("ACombTable", this.ACombTable);

		}

		public QuestionCombo(SerializationInfo info, StreamingContext ctxt)
		{
			this.QuestionList = (int[])info.GetValue("QuestionList", typeof(int[]));
			this.Text = info.GetString("Text");
			this.ID = info.GetInt32("ID");
			this.eval = (Evaluation)info.GetValue("eval", typeof(Evaluation));
			try
			{
				this.Type = info.GetInt32("Type");
			}
			catch
			{
				this.Type = QuestionCombo.TYPE_COMBO;
			}

			try
			{
				this.SplitInterval = info.GetInt32("SplitInterval");
			}
			catch
			{
				this.SplitInterval = 1;
			}


            try
            {
                this.ACombTable =(Hashtable)info.GetValue("ACombTable", typeof(Hashtable));
            }
            catch
            {
                this.ACombTable = new Hashtable();
            }
		}

		public void AddID(int id)
		{
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
			Question quest = new Question((ID*-1)-100, Text, "", "", "", 0);

			ArrayList answers = new ArrayList();
			
			for (i = 0; i < QuestionList.Length; i++)
			{
                //Console.WriteLine("[COMBO]\tcombining " + QuestionList[i]);
				Question q = td.GetQuestion(QuestionList[i], eval);
                if (q == null) continue;
                quest.NullAnswers += q.NullAnswers;

				if (q == null) continue;

				foreach (string a in q.AnswerList)
					if (!answers.Contains(a.ToLower()))
						answers.Add(a.ToLower());

				foreach (Result r in q.Results)
				{
					int sel = r.SelectedAnswer;
					if (r.SelectedAnswer != -1 && r.SelectedAnswer >= 0 && r.SelectedAnswer < q.AnswerList.Length)
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
					quest.Results.Add(new Result(r.TextAnswer,sel,r.UserID));
				}
				//quest.Answers = q.Answers;
				
				

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
			switch(this.Type)
			{
				case QuestionCombo.TYPE_COMBO:	return GetCombo(td);
				case QuestionCombo.TYPE_SPLIT:	return GetSplit(td);
                case QuestionCombo.TYPE_ACOMB:  return GetAComb(td);
				default: return GetCombo(td);
			}

		}

        public Question GetAComb(TargetData td)
        {
            if (QuestionList.Length == 0)
                return null;

            //new answerlist

            string list = string.Empty;
            StringCollection ina = new StringCollection();
            foreach (string l in ACombTable.Values)
            {
                if (!ina.Contains(l))
                {
                    ina.Add(l);
                    list += l;

                    list += ";";
                }
            }

            list = list.Substring(0, list.Length - 1);

            Question orig = td.GetQuestion(QuestionList[0], eval);

            Question quest = new Question((ID * -1) - 100, Text, orig.Display, list, "", 0);

            foreach (Result r in orig.Results)
            {
                if (!(r.SelectedAnswer >= 0 && r.SelectedAnswer < orig.AnswerList.Length))
                    continue;
                string nval = (string)ACombTable[orig.AnswerList[r.SelectedAnswer]];
                
                int val = -1;
                int j = 0;
                foreach (string l in ina)
                {
                    if (l.Equals(nval)) val = j;
                    j++;
                }

                if (val != -1)
                {
                    Result rn = new Result(r.TextAnswer, val, r.UserID);
                    quest.Results.Add(rn);
                }
            }

            return quest;
        }

        public Question GetSplit(TargetData td)
		{
			if (QuestionList.Length == 0)
				return null;

			Question quest = new Question((ID*-1)-100, Text, "", "", "", 0);

			Question orig = td.GetQuestion(QuestionList[0], eval);

			Hashtable acounts = new Hashtable();
			Hashtable uids = new Hashtable();

			int max = 0;
			foreach (Result r in orig.Results)
			{
				if (orig.Display.Equals("multi"))
				{
					int cnt = r.TextAnswer.Split(';').Length;

					if (cnt > max) max = cnt;

					if (acounts.ContainsKey(cnt))
						acounts[cnt] = (int)acounts[cnt] + 1;
					else
						acounts[cnt] = 1;
				}
			}

			int numans = (int)Math.Ceiling( ((double)max)/((double)this.SplitInterval));
			string answers = string.Empty;

			Hashtable res = new Hashtable();

			Hashtable numsin = new Hashtable();

			int i ;
			
			for (i = 0; i <= max; i++)
			{
				int a = i/this.SplitInterval;

				res[i] = a;

				if (!numsin.ContainsKey(a))
					numsin[a] = new ArrayList();

				((ArrayList)numsin[a]).Add(i);
			}

			int klen = 0;
			foreach (int k in numsin.Keys)
			{
				int kmin = int.MaxValue;
				int kmax = int.MinValue;

				foreach (int val in (ArrayList)numsin[k])
				{
					if (val < kmin) kmin = val;
					if (val > kmax) kmax = val;
				}

				if (kmin != kmax)
					answers = kmin + " - " + kmax + answers;
				else
					answers = "" + kmin + answers;

				klen ++;

				if (klen < numsin.Keys.Count)
					answers = ";" + answers;
			}
			
			quest.Answers = answers;
			quest.Display = "radio";
			
			foreach (Result r in orig.Results)
			{
				if (r == null) continue;
				if (orig.Display.Equals("multi"))
				{
					int cnt = r.TextAnswer.Split(';').Length;

					Console.WriteLine("adding " + cnt + " to " + (int)res[cnt]);

					quest.Results.Add(new Result((int)res[cnt], r.UserID));
				}
			}

			return quest;
		}

		public override string ToString()
		{
			return "C" + ID + " (" + Text + ")";
		}

     }
}
