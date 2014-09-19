using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Contains Question Settings and Results
	/// </summary>
	/// 
	[Serializable]
	public class Question : ISerializable
	{
        //questions 2008 style
        //
        //in order to achieve target based average combo questions
        //and considerably speed up computation, create a question
        //result buffer - compute once, then use the buffer for the
        //rest of the session

        //buffer variables

        [NonSerialized] 
        private Hashtable averageByPerson = new Hashtable();

        private void WBufferAverageByPerson(PersonSetting ps, float val)
        { averageByPerson[ps] = val; }

        private bool InBufferAverageByPerson(PersonSetting ps)
        { return (averageByPerson.ContainsKey(ps)); }

        private float RBufferAverageByPerson(PersonSetting ps)
        { return (float)averageByPerson[ps]; }

        [NonSerialized]
        private Hashtable medianByPersonMark = new Hashtable();

        private void WBufferMedianByPersonMark(PersonSetting ps, float val)
        { medianByPersonMark[ps] = val; }

        private bool InBufferMedianByPersonMark(PersonSetting ps)
        { return (medianByPersonMark.ContainsKey(ps)); }

        private float RBufferMedianByPersonMark(PersonSetting ps)
        { return (float)medianByPersonMark[ps]; }

        [NonSerialized]
        private Hashtable nByPerson = new Hashtable();

        private void WBufferNByPerson(PersonSetting ps, int val)
        { nByPerson[ps] = val; }

        private void WBufferNByPerson(int id, int val)
        { nByPerson[id] = val; }

        private bool InBufferNByPerson(PersonSetting ps)
        { return (nByPerson.ContainsKey(ps)); }

        private bool InBufferNByPerson(int id)
        { return (nByPerson != null && nByPerson.ContainsKey(id)); }

        private int RBufferNByPerson(PersonSetting ps)
        { return (int)nByPerson[ps]; }

        private int RBufferNByPerson(int id)
        { return (int)nByPerson[id]; }

        [NonSerialized]
        private Hashtable averageByPersonMark = new Hashtable();

        private void WBufferAverageByPersonMark(PersonSetting ps, int val)
        { averageByPersonMark[ps] = val; }

        private void WBufferAverageByPersonMark(int id, int val)
        { averageByPersonMark[id] = val; }

        private bool InBufferAverageByPersonMark(PersonSetting ps)
        { return (averageByPersonMark != null && averageByPersonMark.ContainsKey(ps)); }

        private bool InBufferAverageByPersonMark(int id)
        { return (averageByPersonMark != null && averageByPersonMark.ContainsKey(id)); }

        private int RBufferAverageByPersonMark(PersonSetting ps)
        { return (int)averageByPersonMark[ps]; }

        private int RBufferAverageByPersonMark(int id)
        { return (int)averageByPersonMark[id]; }


		// DATABASE

		/// <summary>
		/// Question ID as in Database
		/// </summary>
		public int ID;
		/// <summary>
		/// Question Body
		/// </summary>
		public string Text;
		/// <summary>
		/// Type of Question (radio, multi, text, etc)
		/// </summary>
		public string Display = String.Empty;
		/// <summary>
		/// List of possible Answers
		/// </summary>
		public string Answers;
		/// <summary>
		/// Search Shortcut
		/// </summary>
		public string Shortcut; 

		public string[] AnswerList
		{
			get
			{
				return Answers.Split(';');
			}
		}
		// CONFIGURATION 

		/// <summary>
		/// Scoring Category of Question
		/// </summary>
		private string Category;

        public Hashtable TextAlii;

		public string SID
		{
			get
			{
                if (IsCombo) return "C" + ((ID + 100) * -1);
                else if (IsAlternate) return "A" + ((ID + 5000) * -1);
                else if (IsAnswerCombo) return "K" + ((ID + 10000) * -1);
                else if (IsPlaceholder) return "P" + ((ID + 100000) * -1);
                else return ID.ToString();
					
			}
		}

	    public bool IsMulti
	    {
            get { return Display == "multi"; }
	    }

		public bool IsCombo
		{
			get {return (ID <= -100 && ID > -5000);}
		}

        public bool IsAlternate
        {
            get { return (ID <= -5000 && ID > -10000); }
        }

        public bool IsPlaceholder
        {
            get { return (ID <= -100000); }
        }

        public bool IsAnswerCombo
        {
            get { return (ID <= -10000 && ID > -100000); }
        }

		public float Average
		{
			get
			{
				float total = 0;

				foreach (Result r in Results)
					total += r.SelectedAnswer;

				return total / ((float)Results.Count);
			}	
		}

        public Question Clone
        {
            get { return (Question)this.MemberwiseClone(); }
        }

		public ArrayList Results;

        public int NullAnswers = 0;

        private ArrayList Alt;

        public bool Multipart;

        

        public int GetUniqueUserCount()
        {
            ArrayList ar = new ArrayList();

            foreach (Result r in Results)
                if (!ar.Contains(r.UserID)) ar.Add(r.UserID);

            return ar.Count;
        }

		public Question()
		{
			ID     = -1;
			Text   = Display = Answers = Shortcut = Category = string.Empty;

			Results = new ArrayList();

            Alt = new ArrayList();

            Multipart = false;
		}


        public ArrayList Alternates;

        public Question(Question template)
        {
            ID = template.ID;
            Text = template.Text;
            Display = template.Display;
            Shortcut = template.Shortcut;
            Answers = template.Answers;
            NullAnswers = template.NullAnswers;

            Results = new ArrayList();

            Alternates = (ArrayList)template.Alternates.Clone();

            Alt = new ArrayList();

            Multipart = template.Multipart;
        }

		public Question(int QuestionID, string QuestionText, string QuestionDisplay, string QuestionAnswers, string QuestionShortcut, int na)
		{
			ID       = QuestionID;
			Text     = QuestionText;
			Display  = QuestionDisplay;
			Shortcut = QuestionShortcut;
			Answers  = QuestionAnswers;
            NullAnswers = na;

			Results = new ArrayList();

            Alternates = new ArrayList();

            Alt = new ArrayList();

            Multipart = false;

            TextAlii = new Hashtable();
		}

        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
            info.AddValue("Answers", Answers);
            info.AddValue("Category", Category);
            info.AddValue("Display", Display);
            info.AddValue("ID", ID);
            info.AddValue("Multipart", Multipart);

            if (!Multipart) info.AddValue("Results", Results);

            info.AddValue("Shortcut", Shortcut);
            info.AddValue("Text", Text);

            info.AddValue("Alternates", Alternates);
            info.AddValue("NullAnswers", NullAnswers);

            info.AddValue("TextAlii", TextAlii);
		}

		public Question(SerializationInfo info, StreamingContext ctxt)
		{
            try { Multipart = info.GetBoolean("Multipart"); }
            catch { Multipart = false; }

            Answers = info.GetString("Answers");
            Category = info.GetString("Category");
            Display = info.GetString("Display");
            ID = info.GetInt32("ID");

            if (!Multipart) Results = (ArrayList)info.GetValue("Results", typeof(ArrayList));
            else Results = new ArrayList();
            
            Shortcut = info.GetString("Shortcut");
            Text = info.GetString("Text");

            try { Alternates = (ArrayList)info.GetValue("Alternates", typeof(ArrayList)); }
            catch { Alternates = new ArrayList(); }

            Alt = new ArrayList();

            try
            {
                NullAnswers = info.GetInt32("NullAnswers");
            }
            catch { NullAnswers = 0; }

            try { TextAlii = (Hashtable)info.GetValue("TextAlii", typeof(Hashtable)); }
            catch { TextAlii = new Hashtable(); }
		}

        public static void SetMultipart(Question q, bool val)
        {
            if (q != null) q.Multipart = val;
        }

        public static void SetMultipartArray(Question[] res, bool val)
        {
            if (res == null) return;

            foreach (Question q in res)
                if (q != null) Question.SetMultipart(q, val);
        }

		public override string ToString()
		{
            string s = "";

            if (IsCombo)
            {
                s = "C" + ((ID + 100) * -1) + " (" + Text + ")";   
            }
            else if (IsAlternate)
            {
                s = "A" + ((ID + 5000) * -1) + " (" + Text + ")";
            }
            else if (IsAnswerCombo)
            {
                s = "K" + ((ID + 10000) * -1) + " (" + Text + ")";
            }
            else if (IsPlaceholder)
            {
                s = "P" + ((ID + 100000) * -1) + " (" + Text + ")";
            }
            else
            {
                s = ID.ToString();
                foreach (int a in Alternates) s += " - " + a + "";
                s += " (" + Text + ")";
            }

            return s;
		}


        public void ClearAlternates()
        {
            Alt.Clear();
        }

        public void LoadAlternate(Question a)
        {
            Alt.Add(a);
        }

		public Result[] GetResultsByPerson(PersonSetting personS, Evaluation eval)
		{
			ArrayList rs = new ArrayList();

			try
			{
				Person person = (Person) personS;

				foreach (Result r in Results)
				{
					if (eval.GetPersonIdByUser(r.UserID) == person.ID)
					{
						rs.Add(r);
					}
				}
			}
			catch {}

			try
			{
				PersonCombo person = (PersonCombo) personS;

				foreach (Result r in Results)
				{
					if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
					{
						rs.Add(r);
					}
				}
			}
			catch {}

			Result[] res = new Result[rs.Count];

			int i = 0;
			foreach (Result r in rs)
				res[i++] = r;

            return res;

            /*
            //ALT
            if (res.Length > 0)
    			return res;
            else 
            {
                foreach (Question aq in Alt)
                {
                    res = aq.GetResultsByPerson(personS, eval);

                    if (res.Length > 0)
                        return res;
                }
            }
             * */

            return new Result[0];
		}

		public int GetAnswerId(string answer)
		{
            if (answer.Trim().Equals(string.Empty))
            {
                answer = "Keine Antwort";
            }

			for (int i = 0; i < AnswerList.Length; i++)
				if (AnswerList[i].Trim().Equals(answer.Trim()))
					return i;

            return -1;
		}

		public Result GetResultByUserID(int UID)
		{
			foreach (Result r in Results)
				if (r.UserID == UID)
					return r;
            /*
            //ALT
            foreach (Question aq in Alt)
            {
                Result res = aq.GetResultByUserID(UID);

                if (res != null) return res;
            }
             * */
            

			return null;
		}

		public int GetAnswerCount(string answer)
		{
			int i; 
			for (i = 0; i < AnswerList.Length; i++)
				if (AnswerList[i].Trim().Equals(answer.Trim()))
					break;

			if (i == AnswerList.Length)
				return 0;

			int count = 0;
			foreach (Result r in Results)
			{
				if (this.Display.ToLower().Equals("radio"))
				{
					if (r.SelectedAnswer == i)
						count ++;
				}
				else
				{
					if (r.TextAnswer.Equals(answer))
						count++;
				}
			}

			return count;
		}

		public bool ContainsPerson(Evaluation eval, PersonSetting personS)
		{
			try
			{
				Person person = (Person) personS;

				foreach (Result r in Results)
				{
					if (eval.GetPersonIdByUser(r.UserID) == person.ID)
					{
						return true;
					}
				}
			}
			catch {}

			try
			{
				PersonCombo person = (PersonCombo) personS;

				foreach (Result r in Results)
				{
					if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
					{
						return true;
					}
				}
			}
			catch {}

			return false;
		}

		public float GetAverageAnswersByUser(Evaluation eval, PersonSetting personS)
		{
			ArrayList vals = new ArrayList();
			ArrayList uids = new ArrayList();
			try
			{
				Person person = (Person) personS;

				foreach (Result r in Results)
				{
					if (eval.GetPersonIdByUser(r.UserID) == person.ID)
					{
						vals.Add(r);
					}
				}
			}
			catch {}

			try
			{
				PersonCombo person = (PersonCombo) personS;

				foreach (Result r in Results)
				{
					if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
					{
						vals.Add(r);
					}
				}
			}
			catch {}

			float users = 0;
			float answers = 0;

			foreach (Result r in vals)
			{
				if (!uids.Contains(r.UserID))
				{
					uids.Add(r.UserID);
					users++;
				}

				if (Display.Equals("multi"))
				{
					answers += r.TextAnswer.Split(';').Length;
				}
				else
					answers++;
			}

			if (users == 0 || answers == 0)
				return 0;
			else
				return answers/users;

		}

        public float GetAnswerOppositePercentByPerson(int index, Evaluation eval, PersonSetting personS)
        {
            if (index < AnswerList.Length)
                return GetAnswerOppositePercentByPerson(AnswerList[index], eval, personS);
            else
                return 0;
        }

        public float GetAnswerOppositePercentByPerson(string a, Evaluation eval, PersonSetting personS)
        {
            ArrayList vals = new ArrayList();

            int totalPersons = 0;

            try
            {
                Person person = (Person)personS;

                foreach (Result r in Results)
                {
                    if (eval.GetPersonIdByUser(r.UserID) == person.ID)
                    {
                        if (this.Display.Equals("multi"))
                        {
                            bool added = false;
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                int c = 0;
                                foreach (string s in AnswerList)
                                {
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
                                    {
                                        vals.Add(c);
                                        added = true;
                                    }
                                    c++;
                                }
                            }
                            if (added)
                                totalPersons++;
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
                            {
                                vals.Add(r.SelectedAnswer);
                                totalPersons++;
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                PersonCombo person = (PersonCombo)personS;

                foreach (Result r in Results)
                {
                    if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
                    {
                        if (this.Display.Equals("multi"))
                        {
                            bool added = false;
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                int c = 0;
                                foreach (string s in AnswerList)
                                {
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
                                    {
                                        vals.Add(c);
                                        added = true;
                                    }
                                    c++;
                                }
                            }
                            if (added)
                                totalPersons++;
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
                            {
                                vals.Add(r.SelectedAnswer);
                                totalPersons++;
                            }
                        }
                    }
                }
            }
            catch { }

            int[] ivals = new int[AnswerList.Length];

            foreach (int i in vals)
                ivals[i]++;

            int n = GetAnswerId(a);

            //Console.WriteLine("vals= " + vals.Count + ", ivals= " + ivals[n]);

            Console.WriteLine("[" + this.ID + "]\tBASE/Oo=" + totalPersons);

            if (vals.Count > 0 && ivals[n] > 0)
                return (    ( (float)totalPersons - (float)ivals[n] ) / (float)totalPersons) * 100f;
            else
                return 0;

        }

		public float GetAnswerPercentByPerson(int index, Evaluation eval, PersonSetting personS)
		{
			if (index < AnswerList.Length)
				return GetAnswerPercentByPerson(AnswerList[index], eval, personS);
			else
				return 0;
		}

		public float GetAnswerPercentByPerson(string a, Evaluation eval, PersonSetting personS)
		{
			ArrayList vals = new ArrayList();

			int totalPersons = 0;
			
			try
			{
				Person person = (Person) personS;

				foreach (Result r in Results)
				{
					if (eval.GetPersonIdByUser(r.UserID) == person.ID)
					{
						if (this.Display.Equals("multi"))
						{
							bool added = false;
							foreach (string sa in r.TextAnswer.Split(';'))
							{
								int c = 0;
								foreach (string s in AnswerList)
								{
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
									{
										vals.Add(c);
										added = true;
									}
									c++;
								}
							}
							if (added)
								totalPersons++;
						}
						else
						{
							if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
							{
								vals.Add(r.SelectedAnswer);
								totalPersons++;
							}
						}
					}
				}
			}
			catch {}

			try
			{
				PersonCombo person = (PersonCombo) personS;

				foreach (Result r in Results)
				{
					if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
					{
						if (this.Display.Equals("multi"))
						{
							bool added = false;
							foreach (string sa in r.TextAnswer.Split(';'))
							{
								int c = 0;
								foreach (string s in AnswerList)
								{
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
									{
										vals.Add(c);
										added = true;
									}
									c++;
								}
							}
							if (added)
								totalPersons++;
						}
						else
						{
							if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
							{
								vals.Add(r.SelectedAnswer);
								totalPersons++;
							}
						}
					}
				}
			}
			catch {}

			int[] ivals = new int[AnswerList.Length];

			foreach (int i in vals)
				ivals[i]++;

			int n = GetAnswerId(a);

			//Console.WriteLine("vals= " + vals.Count + ", ivals= " + ivals[n]);
            //Console.WriteLine("[" + this.ID + "]\tBASE/On=" + totalPersons);

            Console.WriteLine("got " + n + " for '"+a+"'");

			if (vals.Count > 0 && ivals[n] > 0)
				return ((float)ivals[n] / (float)totalPersons) * 100f;
			else
				return 0;
			
		}

        public float GetAnswerCountByPerson(int index, Evaluation eval, PersonSetting personS)
        {
            if (index < AnswerList.Length)
                return GetAnswerCountByPerson(AnswerList[index], eval, personS);
            else
                return 0;
        }

        public float GetAnswerCountByPerson(string a, Evaluation eval, PersonSetting personS)
        {
            ArrayList vals = new ArrayList();

            int totalPersons = 0;

            try
            {
                Person person = (Person)personS;

                foreach (Result r in Results)
                {
                    if (eval.GetPersonIdByUser(r.UserID) == person.ID)
                    {
                        if (this.Display.Equals("multi"))
                        {
                            bool added = false;
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                int c = 0;
                                foreach (string s in AnswerList)
                                {
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
                                    {
                                        vals.Add(c);
                                        added = true;
                                    }
                                    c++;
                                }
                            }
                            if (added)
                                totalPersons++;
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
                            {
                                vals.Add(r.SelectedAnswer);
                                totalPersons++;
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                PersonCombo person = (PersonCombo)personS;

                foreach (Result r in Results)
                {
                    if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
                    {
                        if (this.Display.Equals("multi"))
                        {
                            bool added = false;
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                int c = 0;
                                foreach (string s in AnswerList)
                                {
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
                                    {
                                        vals.Add(c);
                                        added = true;
                                    }
                                    c++;
                                }
                            }
                            if (added)
                                totalPersons++;
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
                            {
                                vals.Add(r.SelectedAnswer);
                                totalPersons++;
                            }
                        }
                    }
                }
            }
            catch { }

            int[] ivals = new int[AnswerList.Length];

            foreach (int i in vals)
                ivals[i]++;

            int n = GetAnswerId(a);

            if (vals.Count > 0 && ivals[n] > 0)
                return ((float)ivals[n]);
            else
                return 0;

        }

        public float GetAnswerPercentByPersonWithBase(int index, Evaluation eval, PersonSetting personS, Question Base)
        {
            if (index < AnswerList.Length)
                return GetAnswerPercentByPersonWithBase(AnswerList[index], eval, personS, Base);
            else
                return 0;
        }

        public float GetAnswerPercentByPersonWithBase(string a, Evaluation eval, PersonSetting personS, Question Base)
        {
            

            int totalPersons = 0;

            //get total persons of base

            try
            {
                Person person = (Person)personS;

                foreach (Result r in Base.Results)
                {
                    if (eval.GetPersonIdByUser(r.UserID) == person.ID)
                    {
                        if (Base.Display.Equals("multi"))
                        {
                            bool added = false;
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                foreach (string s in Base.AnswerList)
                                {
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
                                    {
                                        added = true;
                                        break;
                                    }
                                }
                            }
                            if (added)
                                totalPersons++;
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < Base.AnswerList.Length)
                            {
                                totalPersons++;
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                PersonCombo person = (PersonCombo)personS;

                foreach (Result r in Base.Results)
                {
                    if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
                    {
                        if (Base.Display.Equals("multi"))
                        {
                            bool added = false;
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                foreach (string s in Base.AnswerList)
                                {
                                    if (s.Replace("/ ", "/").Replace(" /", "/").Trim().Equals(sa.Replace("/ ", "/").Replace(" /", "/").Trim()))
                                    {
                                        added = true;
                                        break;
                                    }
                                }
                            }
                            if (added)
                                totalPersons++;
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < Base.AnswerList.Length)
                            {
                                totalPersons++;
                            }
                        }
                    }
                }
            }
            catch { }


            //get values

            ArrayList vals = new ArrayList();
            try
            {
                Person person = (Person)personS;

                foreach (Result r in Results)
                {
                    if (eval.GetPersonIdByUser(r.UserID) == person.ID)
                    {
                        if (this.Display.Equals("multi"))
                        {
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                int c = 0;
                                foreach (string s in AnswerList)
                                {
                                    if (s.Trim().Equals(sa.Trim()))
                                    {
                                        vals.Add(c);
                                    }
                                    c++;
                                }
                            }
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
                            {
                                vals.Add(r.SelectedAnswer);
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                PersonCombo person = (PersonCombo)personS;

                foreach (Result r in Results)
                {
                    if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
                    {
                        if (this.Display.Equals("multi"))
                        {
                            foreach (string sa in r.TextAnswer.Split(';'))
                            {
                                int c = 0;
                                foreach (string s in AnswerList)
                                {
                                    if (s.Trim().Equals(sa.Trim()))
                                    {
                                        vals.Add(c);
                                    }
                                    c++;
                                }
                            }
                        }
                        else
                        {
                            if (r.SelectedAnswer >= 0 && r.SelectedAnswer < AnswerList.Length)
                            {
                                vals.Add(r.SelectedAnswer);
                            }
                        }
                    }
                }
            }
            catch { }

            int[] ivals = new int[AnswerList.Length];

            foreach (int i in vals)
                ivals[i]++;

            int n = GetAnswerId(a);

            //Console.WriteLine("vals= " + vals.Count + ", ivals= " + ivals[n]);

            Console.WriteLine("["+this.ID+"]\tBASE/N=" + totalPersons);

            if (vals.Count > 0 && ivals[n] > 0)
                return ((float)ivals[n] / (float)totalPersons) * 100f;
            else
                return 0;

        }

		public float GetAverageByPersonAsMark(Evaluation eval, PersonSetting personS)
		{
            if (InBufferAverageByPersonMark(personS)) return RBufferAverageByPersonMark(personS);

			try
			{
				Person person = (Person) personS;

				float total = 0;
				float count = 0;

				foreach (Result r in Results)
				{
					if (eval.GetPersonIdByUser(r.UserID) == person.ID)
					{
						if (r.SelectedAnswer >= 0 && r.SelectedAnswer <= 4)
						{
							total += r.SelectedAnswer;
							count++;
						}
					}
				}

				if (count != 0)
					return (total / count) + 1;
				else
					return -1;
			}
			catch
			{
			}

			try
			{
				PersonCombo combo = (PersonCombo) personS;

				float total = 0;
				float count = 0;

				foreach (Result r in Results)
				{
					if (combo.ContainsID(eval.GetPersonIdByUser(r.UserID)))
					{
						if (r.SelectedAnswer >= 0 && r.SelectedAnswer <= 4)
						{
							total += r.SelectedAnswer;
							count++;
						}
					}
				}

				if (count != 0)
					return (total / count) + 1;
				else
					return -1;
			}
			catch
			{
			}

			return -1;
		}

		public float GetAverageByPersonAsMark(Evaluation eval, PersonSetting personS, int Round)
		{
			return (float)Math.Round(GetAverageByPersonAsMark(eval, personS),Round);	
		}

		public float GetMedianByPersonAsMark(Evaluation eval, PersonSetting personS, int Round)
		{
			ArrayList vals = new ArrayList();
			
			try
			{
				Person person = (Person) personS;

				foreach (Result r in Results)
				{
					if (eval.GetPersonIdByUser(r.UserID) == person.ID)
					{
						if (r.SelectedAnswer >= 0 && r.SelectedAnswer <= 4)
						{
							vals.Add(r.SelectedAnswer);
						}
					}
				}
			}
			catch {}

			try
			{
				PersonCombo person = (PersonCombo) personS;

				foreach (Result r in Results)
				{
					if (person.ContainsID(eval.GetPersonIdByUser(r.UserID)))
					{
						if (r.SelectedAnswer >= 0 && r.SelectedAnswer <= 4)
						{
							vals.Add(r.SelectedAnswer);
						}
					}
				}
			}
			catch {}

			vals.Sort();

			if (vals.Count > 0)
			{
				if (vals.Count%2 == 0)
				{
					return (float)(int)vals[vals.Count/2]+1;
				}
				else
				{
					if (vals.Count != 1)
					{
						float a = (float)(int)vals[(vals.Count-1)/2]+1;
						float b = (float)(int)vals[(vals.Count+1)/2]+1;
						return (a+b)/2;
					}
					else
						return (float)(int)vals[0];
				}
			}
			return -1;
		}

        public int NAnswersByPerson(Evaluation eval, int ID)
        {
            int count = 0;

			foreach (Result r in Results)
			{
				if (eval.GetPersonIdByUser(r.UserID) == ID)
				{
					if (r.SelectedAnswer >= 0)
					{
						count++;
					}
				}
			}

            return count;
        }

        public int NAnswersByPerson(Evaluation eval, PersonSetting personS)
        {
            try
            {
                Person person = (Person)personS;

                int count = 0;

                foreach (Result r in Results)
                {
                    if (eval.GetPersonIdByUser(r.UserID) == person.ID)
                    {
                        if (r.SelectedAnswer >= 0)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
            catch
            {
            }

            try
            {
                PersonCombo combo = (PersonCombo)personS;

                int count = 0;

                foreach (Result r in Results)
                {
                    if (combo.ContainsID(eval.GetPersonIdByUser(r.UserID)))
                    {
                        if (r.SelectedAnswer >= 0)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
            catch
            {
            }

            return 0;
        }

		public float GetAverageByPersonAsMark(Evaluation eval, int ID)
		{
            if (InBufferAverageByPersonMark(ID)) return RBufferAverageByPersonMark(ID);

			float total = 0;
			float count = 0;

			foreach (Result r in Results)
			{
				if (eval.GetPersonIdByUser(r.UserID) == ID)
				{
					if (r.SelectedAnswer >= 0 && r.SelectedAnswer <= 4)
					{
						total += r.SelectedAnswer;
						count++;
					}
				}
			}

			if (count != 0)
				return (total / count) + 1;
			else
				return -1;
		}

        public float GetAverageByPersons(Evaluation eval, PersonSetting[] personS)
        {
            float total = 0;
            float count = 0;

            foreach (Result r in Results)
            {
                foreach (PersonSetting ps in personS)
                {
                    if (ps.GetType().Equals(typeof(Person)))
                    {
                        if (eval.GetPersonIdByUser(r.UserID) == ((Person)ps).ID)
                        {
                            if (r.SelectedAnswer != -1)
                            {
                                total += r.SelectedAnswer;
                                count++;
                            }
                        }
                    }
                    else if (ps.GetType().Equals(typeof(PersonCombo)))
                    {
                        if (((PersonCombo)ps).ContainsID(eval.GetPersonIdByUser(r.UserID)))
                        {
                            if (r.SelectedAnswer != -1)
                            {
                                total += r.SelectedAnswer;
                                count++;
                            }
                        }
                    }
                }
            }

            if (count != 0)
                return total / count;
            else
                return -1;
        }

		public float GetAverageByPerson(Evaluation eval, PersonSetting personS)
		{
            if (InBufferAverageByPerson(personS)) return RBufferAverageByPerson(personS);

			try
			{
				Person person = (Person) personS;

				float total = 0;
				float count = 0;

				foreach (Result r in Results)
				{
					if (eval.GetPersonIdByUser(r.UserID) == person.ID)
					{
						if (r.SelectedAnswer != -1)
						{
							total += r.SelectedAnswer;
							count++;
						}
					}
				}

				if (count != 0)
					return total / count;

				else
					return -1;
			}
			catch
			{
			}

			try
			{
				PersonCombo combo = (PersonCombo) personS;

				float total = 0;
				float count = 0;

				foreach (Result r in Results)
				{
					if (combo.ContainsID(eval.GetPersonIdByUser(r.UserID)))
					{
						if (r.SelectedAnswer != -1)
						{
							total += r.SelectedAnswer;
							count++;
						}
					}
				}

				if (count != 0)
					return total / count;
				else
					return -1;
			}
			catch
			{
			}

			return -1;
		}
	}
}
